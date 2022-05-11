using System;
using System.Windows.Forms;
using LazyFingers.Properties;

namespace LazyFingers
{
    public enum KeyPressed
    {
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12
    }
    public partial class FrmButtonSetting : Form
    {
        private readonly KeyPressed _keyPressed;

        public FrmButtonSetting(KeyPressed keyPressed)
        {
            InitializeComponent();
            _keyPressed = keyPressed;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            switch (_keyPressed)
            {
                case KeyPressed.F1:
                    Settings.Default.F1 = TxtTemplate.Text.Trim();
                    Settings.Default.F1_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F2:
                    Settings.Default.F2 = TxtTemplate.Text.Trim();
                    Settings.Default.F2_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F3:
                    Settings.Default.F3 = TxtTemplate.Text.Trim();
                    Settings.Default.F3_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F4:
                    Settings.Default.F4 = TxtTemplate.Text.Trim();
                    Settings.Default.F4_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F5:
                    Settings.Default.F5 = TxtTemplate.Text.Trim();
                    Settings.Default.F5_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F6:
                    Settings.Default.F6 = TxtTemplate.Text.Trim();
                    Settings.Default.F6_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F7:
                    Settings.Default.F7 = TxtTemplate.Text.Trim();
                    Settings.Default.F7_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F8:
                    Settings.Default.F8 = TxtTemplate.Text.Trim();
                    Settings.Default.F8_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F9:
                    Settings.Default.F9 = TxtTemplate.Text.Trim();
                    Settings.Default.F9_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F10:
                    Settings.Default.F10 = TxtTemplate.Text.Trim();
                    Settings.Default.F10_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F11:
                    Settings.Default.F11 = TxtTemplate.Text.Trim();
                    Settings.Default.F11_Title = TxtTitle.Text.Trim();
                    break;
                case KeyPressed.F12:
                    Settings.Default.F12 = TxtTemplate.Text.Trim();
                    Settings.Default.F12_Title = TxtTitle.Text.Trim();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Settings.Default.Save();
            Close();
        }

        private void FrmButtonSetting_Load(object sender, EventArgs e)
        {
            switch (_keyPressed)
            {
                case KeyPressed.F1:
                    TxtTemplate.Text = Settings.Default.F1;
                    TxtTitle.Text = Settings.Default.F1_Title;
                    break;
                case KeyPressed.F2:
                    TxtTemplate.Text = Settings.Default.F2;
                    TxtTitle.Text = Settings.Default.F2_Title;
                    break;
                case KeyPressed.F3:
                    TxtTemplate.Text = Settings.Default.F3;
                    TxtTitle.Text = Settings.Default.F3_Title;
                    break;
                case KeyPressed.F4:
                    TxtTemplate.Text = Settings.Default.F4;
                    TxtTitle.Text = Settings.Default.F4_Title;
                    break;
                case KeyPressed.F5:
                    TxtTemplate.Text = Settings.Default.F5;
                    TxtTitle.Text = Settings.Default.F5_Title;
                    break;
                case KeyPressed.F6:
                    TxtTemplate.Text = Settings.Default.F6;
                    TxtTitle.Text = Settings.Default.F6_Title;
                    break;
                case KeyPressed.F7:
                    TxtTemplate.Text = Settings.Default.F7;
                    TxtTitle.Text = Settings.Default.F7_Title;
                    break;
                case KeyPressed.F8:
                    TxtTemplate.Text = Settings.Default.F8;
                    TxtTitle.Text = Settings.Default.F8_Title;
                    break;
                case KeyPressed.F9:
                    TxtTemplate.Text = Settings.Default.F9;
                    TxtTitle.Text = Settings.Default.F9_Title;
                    break;
                case KeyPressed.F10:
                    TxtTemplate.Text = Settings.Default.F10;
                    TxtTitle.Text = Settings.Default.F10_Title;
                    break;
                case KeyPressed.F11:
                    TxtTemplate.Text = Settings.Default.F11;
                    TxtTitle.Text = Settings.Default.F11_Title;
                    break;
                case KeyPressed.F12:
                    TxtTemplate.Text = Settings.Default.F12;
                    TxtTitle.Text = Settings.Default.F12_Title;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void FrmButtonSetting_Shown(object sender, EventArgs e)
        {
           TxtTemplate.SelectionLength = 0;
           TxtTitle.SelectionLength = 0;
        }
    }
}
