using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace LockCursorInMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly NotifyIcon NotifyIcon;
        public ToolStripMenuItem ActivatedMenuItem;

        public App()
        {
            NotifyIcon = new NotifyIcon();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region NotifyIcon
            // Get the icon of the app.
            using (var iconStream = GetResourceStream(
                new Uri("pack://application:,,,/assets/LockCursorInMonitor.ico")).Stream)
            {
                // Set the icon of the NotifyIcon as the icon of the app.
                NotifyIcon.Icon = new Icon(iconStream);
            }
            // Set the text as the name of the app.
            NotifyIcon.Text = Assembly.GetEntryAssembly().GetName().Name;
            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            NotifyIcon.ContextMenuStrip = new ContextMenuStrip();
            // Activate toggle button.
            ActivatedMenuItem = new ToolStripMenuItem("Activated");
            ActivatedMenuItem.CheckOnClick = true;
            ActivatedMenuItem.CheckedChanged  += activatedMenuItem_CheckedChanged;
            NotifyIcon.ContextMenuStrip.Items.Add(ActivatedMenuItem);
            // Close app button.
            var closeAppMenuItem = new ToolStripMenuItem("Exit");
            closeAppMenuItem.Click += CloseAppMenuItem_Click;
            NotifyIcon.ContextMenuStrip.Items.Add(closeAppMenuItem);
            NotifyIcon.Visible = true;
            #endregion
        }

        private void CloseAppMenuItem_Click(object sender, EventArgs e)
        {
            // Close the app.
            Current.Shutdown();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // Maximize the window and bring 
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
            MainWindow.Show();
        }

        /// <summary>
        /// Runs when the button in the context menu is toggled to activate or deactivate the toggle switch that
        /// toggles the cursor locking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activatedMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // 
            var wnd = (MainWindow)MainWindow;
            wnd.ActivatedSwitch.IsOn = ((ToolStripMenuItem)sender).Checked;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // Remove the 
            NotifyIcon.Dispose();
        }
    }
}
