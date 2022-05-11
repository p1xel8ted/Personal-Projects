using System;
using System.Text;
using System.Windows.Forms;
using LazyFingers.Properties;
using Microsoft.Win32;

namespace LazyFingers
{
    public partial class FrmMain : Form
    {
        private const string NoTemplateMessage = @"You have no template set for this button!";
        private const string NoTemplateMessageCaption = @"Hmmm";
        private readonly GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();

        public FrmMain()
        {
            InitializeComponent();
        }

        private static void UpdateTooltipText()
        {
            var longString = new StringBuilder();
            longString.AppendLine("F1: " + Settings.Default.F1_Title);
            longString.AppendLine("F2: " + Settings.Default.F2_Title);
            longString.AppendLine("F3: " + Settings.Default.F3_Title);
            longString.AppendLine("F4: " + Settings.Default.F4_Title);
            longString.AppendLine("F5: " + Settings.Default.F5_Title);
            longString.AppendLine("F6: " + Settings.Default.F6_Title);
            longString.AppendLine("F7: " + Settings.Default.F7_Title);
            longString.AppendLine("F8: " + Settings.Default.F8_Title);
            longString.AppendLine("F9: " + Settings.Default.F9_Title);
            longString.AppendLine("F10: " + Settings.Default.F10_Title);
            longString.AppendLine("F11: " + Settings.Default.F11_Title);
            longString.AppendLine("F12: " + Settings.Default.F12_Title);
            var message = longString.ToString();
            MessageBox.Show(message, @"Quick Guide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        
        public static void ToggleApplicationToStartup(bool add)
        {
            if (add)
            {
                using (var key =
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key?.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"");
                }
            }
            else
            {
                using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key?.DeleteValue(Application.ProductName, false);
                }
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            ShowInTaskbar = false;
            Hide();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Opacity = 100;
            ShowInTaskbar = true;
            Show();
            BringToFront();
            Focus();
            WindowState = FormWindowState.Normal;
        }

        private void SetStartPosition(Form form)
        {
            if (TrayIcon.Visible) form.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnF1_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F1)
            {
                Text = @"F1 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF2_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F2)
            {
                Text = @"F2 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF3_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F3)
            {
                Text = @"F3 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF4_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F4)
            {
                Text = @"F4 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF5_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F5)
            {
                Text = @"F5 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF6_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F6)
            {
                Text = @"F6 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF7_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F7)
            {
                Text = @"F7 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF8_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F8)
            {
                Text = @"F8 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF9_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F9)
            {
                Text = @"F9 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF10_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F10)
            {
                Text = @"F10 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF11_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F11)
            {
                Text = @"F11 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private void BtnF12_Click(object sender, EventArgs e)
        {
            var buttonSetting = new FrmButtonSetting(KeyPressed.F12)
            {
                Text = @"F12 Text"
            };
            SetStartPosition(buttonSetting);
            buttonSetting.ShowDialog();
        }

        private static void WriteToLog(string message)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "/log.txt", DateTime.Now + @": - " + message + Environment.NewLine);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            WriteToLog("test");
            ChkStartMini.Checked = Settings.Default.StartMinimized;
            ChkStartWindows.Checked = Settings.Default.StartWindows;

            try
            {
                _keyboardHook.HookedKeys.Add(Keys.Oemtilde);
                _keyboardHook.HookedKeys.Add(Keys.F1);
                _keyboardHook.HookedKeys.Add(Keys.F2);
                _keyboardHook.HookedKeys.Add(Keys.F3);
                _keyboardHook.HookedKeys.Add(Keys.F4);
                _keyboardHook.HookedKeys.Add(Keys.F5);
                _keyboardHook.HookedKeys.Add(Keys.F6);
                _keyboardHook.HookedKeys.Add(Keys.F7);
                _keyboardHook.HookedKeys.Add(Keys.F8);
                _keyboardHook.HookedKeys.Add(Keys.F9);
                _keyboardHook.HookedKeys.Add(Keys.F10);
                _keyboardHook.HookedKeys.Add(Keys.F11);
                _keyboardHook.HookedKeys.Add(Keys.F12);
                _keyboardHook.KeyDown += KeyboardHook_KeyDown;
                _keyboardHook.KeyUp += KeyboardHook_KeyUp;
                WriteToLog("Listening on keys F1 - F12");
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message);
            }

            if (!Settings.Default.StartMinimized) return;
            ShowInTaskbar = false;
            Hide();
            Opacity = 0;
        }

        private static void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = true;
                WriteToLog(e.KeyCode + " Key Intercepted");
            }
            catch (Exception exc)
            {
                WriteToLog(exc.Message);
               // throw;
            }
        }

        private static void ShowEmptyMsg()
        {
            MessageBox.Show(NoTemplateMessage, NoTemplateMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private static void PerformPaste(string template, KeyEventArgs e)
        {
            try
            {
                var clipboardBackup = Clipboard.GetText();
                WriteToLog("Clipboard contents backed up.");
                Clipboard.Clear();
                WriteToLog("Clipboard contents cleared.");
                Clipboard.SetText(template);
                WriteToLog(e.KeyCode + " template copied to clipboard.");
                SendKeys.Send("^v");
                WriteToLog(e.KeyCode + " template text pasted.");
                Clipboard.Clear();
                WriteToLog("Clipboard contents cleared.");
                if (clipboardBackup != string.Empty) Clipboard.SetText(clipboardBackup);
                WriteToLog("Clipboard backup restored.");
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message);
            }
        }

        private static void KeyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
                switch (e.KeyCode)
            {
                    case Keys.Oemtilde:
                        UpdateTooltipText();
                        break;
                case Keys.F1:
                    if (Settings.Default.F1.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F1, e);
                    break;
                case Keys.F2:
                    if (Settings.Default.F2.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F2, e);
                    break;
                case Keys.F3:
                    if (Settings.Default.F3.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F3, e);
                    break;
                case Keys.F4:
                    if (Settings.Default.F4.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F4, e);
                    break;
                case Keys.F5:
                    if (Settings.Default.F5.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F5, e);
                    break;
                case Keys.F6:
                    if (Settings.Default.F6.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F6, e);
                    break;
                case Keys.F7:
                    if (Settings.Default.F7.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F7, e);
                    break;
                case Keys.F8:
                    if (Settings.Default.F8.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F8, e);
                    break;
                case Keys.F9:
                    if (Settings.Default.F9.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F9, e);
                    break;
                case Keys.F10:
                    if (Settings.Default.F10.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F10, e);
                    break;
                case Keys.F11:
                    if (Settings.Default.F11.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F11, e);
                    break;
                case Keys.F12:
                    if (Settings.Default.F12.Length <= 0)
                        ShowEmptyMsg();
                    else
                        PerformPaste(Settings.Default.F12, e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message);
            }
        }

        private void ChkStartMini_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.StartMinimized = ChkStartMini.Checked;
            Settings.Default.Save();
            WriteToLog("Start Minimized: " + ChkStartMini.Checked);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure you want to exit?", @"Bail?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                TrayIcon.Icon.Dispose();
                TrayIcon.Dispose();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs eventArgs)
        {
            var result = MessageBox.Show(@"Are you sure you want to exit?", @"Bail?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result != DialogResult.Yes) return;
            TrayIcon.Icon.Dispose();
            TrayIcon.Dispose();
            Application.Exit();
        }

        private void MenuItemRestore_Click(object sender, EventArgs e)
        {
            TrayIcon_DoubleClick(sender, e);
        }

        private void MenuItemF2_Click(object sender, EventArgs e)
        {
            BtnF2_Click(sender, e);
        }

        private void MenuItemF3_Click(object sender, EventArgs e)
        {
            BtnF3_Click(sender, e);
        }

        private void MenuItemF4_Click(object sender, EventArgs e)
        {
            BtnF4_Click(sender, e);
        }

        private void MenuItemF5_Click(object sender, EventArgs e)
        {
            BtnF5_Click(sender, e);
        }

        private void MenuItemF6_Click(object sender, EventArgs e)
        {
            BtnF6_Click(sender, e);
        }

        private void MenuItemF7_Click(object sender, EventArgs e)
        {
            BtnF7_Click(sender, e);
        }

        private void MenuItemF8_Click(object sender, EventArgs e)
        {
            BtnF8_Click(sender, e);
        }

        private void MenuItemF9_Click(object sender, EventArgs e)
        {
            BtnF9_Click(sender, e);
        }

        private void MenuItemF10_Click(object sender, EventArgs e)
        {
            BtnF10_Click(sender, e);
        }

        private void MenuItemF11_Click(object sender, EventArgs e)
        {
            BtnF11_Click(sender, e);
        }

        private void MenuItemF12_Click(object sender, EventArgs e)
        {
            BtnF12_Click(sender, e);
        }

        private void MenuItemF1_Click(object sender, EventArgs e)
        {
            BtnF1_Click(sender, e);
        }

        private void ChkStartWindows_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.StartWindows = ChkStartWindows.Checked;
            Settings.Default.Save();
            WriteToLog("Start With Windows: " + ChkStartWindows.Checked);
            ToggleApplicationToStartup(Settings.Default.StartWindows);
        }

        private void FrmMain_DoubleClick(object sender, EventArgs e)
        {
            var logForm = new FrmLog();
            logForm.ShowDialog();
        }

        private void ChkStartMini_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = @"Toggle whether the application starts on the system tray.";
        }

        private void ChkStartMini_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void ChkStartWindows_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = @"Toggle whether the application starts with Windows.";
        }

        private void ChkStartWindows_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF1_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F1_Title;
        }

        private void BtnF1_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF2_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F2_Title;
        }

        private void BtnF2_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF3_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F3_Title;
        }

        private void BtnF3_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF4_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F4_Title;
        }

        private void BtnF4_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF5_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F5_Title;
        }

        private void BtnF5_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF6_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F6_Title;
        }

        private void BtnF6_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF7_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F7_Title;
        }

        private void BtnF7_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF8_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F8_Title;
        }

        private void BtnF8_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF9_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F9_Title;
        }

        private void BtnF9_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF10_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F10_Title;
        }

        private void BtnF10_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF11_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F11_Title;
        }

        private void BtnF11_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void BtnF12_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = Settings.Default.F12_Title;
        }

        private void BtnF12_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }
    }
}