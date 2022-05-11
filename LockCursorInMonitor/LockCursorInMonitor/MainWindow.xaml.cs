using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Configs;
using Gma.System.MouseKeyHook;
using LockCursorInMonitor.Configurations;
using LockCursorInMonitor.Interop;
using Microsoft.Win32;
using ModernWpf.Controls;
using Application = System.Windows.Application;

namespace LockCursorInMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow
    {
        private IKeyboardMouseEvents _mGlobalHook;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CursorLockingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //ApplyConfigurations();
        }

        private void CursorLockingWindow_Initialized(object sender, EventArgs e)
        {
            ApplyConfigurations();

            #region Hide at startup
            var runsAtStartup = RunsAtStartup();
            if (runsAtStartup)
            {
                CursorLockingWindow.Visibility = Visibility.Hidden;
            }
            #endregion
        }

        /// <summary>
        /// Applies saved settings to the UI so that the UI represents the saved settings of the user.
        /// </summary>
        public void ApplyConfigurations()
        {
            var appConfigs = ConfigsTools.GetConfigs<AppConfigs>();
            ActivatedSwitch.IsOn = appConfigs.Activated;
            var app = (App)Application.Current;
            app.ActivatedMenuItem.Checked = ActivatedSwitch.IsOn;
            var appName = Assembly.GetEntryAssembly()?.GetName().Name;
            using (var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                var rkValue = (string)rk?.GetValue(appName, "");
                RunAtStartupSwitch.IsOn = rkValue != "";
            }
        }

        private static void GlobalHookCtrlDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.LControlKey && e.KeyCode != Keys.RControlKey) return;
            if (!CursorLock.Locked)
            {
                CursorLock.LockCursor();
            }
        }

        private static void GlobalHookCtrlUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.LControlKey && e.KeyCode != Keys.RControlKey) return;
            if (CursorLock.Locked)
            {
                CursorLock.UnlockCursor();
            }
        }

        private static void GlobalHookFocusChanged(object sender, MouseEventExtArgs e)
        {
            int ctrlKeyState = Native.GetKeyState(VirtualKeyStates.VK_CONTROL);
            switch (CursorLock.Locked)
            {
                // Ctrl is pressed.
                case false when ctrlKeyState < 0:
                    CursorLock.UnlockCursor();
                    break;
                // Ctrl not pressed.
                case true when ctrlKeyState >= 0:
                    CursorLock.LockCursor();
                    break;
            }
        }

        private static void GlobalHookFocusChanged(object sender, MouseEventArgs e)
        {
            int ctrlKeyState = Native.GetKeyState(VirtualKeyStates.VK_CONTROL);
            // Ctrl is pressed.
            if (ctrlKeyState < 0)
            {
                CursorLock.UnlockCursor();
            }
            // Ctrl not pressed.
            else
            {
                CursorLock.LockCursor();
            }
        }

        private void ActivatedSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var activatedSwitch = (ToggleSwitch)sender;
            if (activatedSwitch.IsOn)
            {
                _mGlobalHook = Hook.GlobalEvents();

                _mGlobalHook.KeyDown += GlobalHookCtrlDown;
                _mGlobalHook.KeyUp += GlobalHookCtrlUp;
                _mGlobalHook.MouseMove += GlobalHookFocusChanged;
                _mGlobalHook.MouseMoveExt += GlobalHookFocusChanged;
                _mGlobalHook.MouseDown += GlobalHookFocusChanged;
                _mGlobalHook.MouseDownExt += GlobalHookFocusChanged;
                _mGlobalHook.MouseDragStarted += GlobalHookFocusChanged;
                _mGlobalHook.MouseDragStartedExt += GlobalHookFocusChanged;
            }
            else
            {
                _mGlobalHook.KeyDown -= GlobalHookCtrlDown;
                _mGlobalHook.KeyUp -= GlobalHookCtrlUp;
                _mGlobalHook.MouseMove -= GlobalHookFocusChanged;
                _mGlobalHook.MouseMoveExt -= GlobalHookFocusChanged;
                _mGlobalHook.MouseDown -= GlobalHookFocusChanged;
                _mGlobalHook.MouseDownExt -= GlobalHookFocusChanged;
                _mGlobalHook.MouseDragStarted -= GlobalHookFocusChanged;
                _mGlobalHook.MouseDragStartedExt -= GlobalHookFocusChanged;

                _mGlobalHook.Dispose();
            }
            var appConfigs = AppConfigs.GetConfigs();
            var app = (App)Application.Current;
            appConfigs.Activated = activatedSwitch.IsOn;
            app.ActivatedMenuItem.Checked = activatedSwitch.IsOn;
            appConfigs.Save();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Setting cancel to true will cancel the close request so the application is not closed.
            e.Cancel = true;
            Hide();

            base.OnClosing(e);
        }

        private void RunAtStartupSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var runAtStartupSwitch = (ToggleSwitch)sender;
            var appName = Assembly.GetEntryAssembly()?.GetName().Name;
            var executablePath = Process.GetCurrentProcess().MainModule?.FileName;
            using (var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (runAtStartupSwitch.IsOn)
                {
                    if (executablePath != null) rk?.SetValue(appName, executablePath);
                }
                else
                {
                    if (appName != null) rk?.DeleteValue(appName, false);
                }
            }
        }

        /// <summary>
        /// Checks if the app is registered in the registry to run on startup.
        /// </summary>
        /// <returns>True if the app will run at startup, false otherwise.</returns>
        public bool RunsAtStartup()
        {
            bool result;
            var appName = Assembly.GetEntryAssembly()?.GetName().Name;
            using (var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                var rkValue = (string)rk?.GetValue(appName, "");
                result = rkValue != "";
            }
            return result;
        }
    }
}
