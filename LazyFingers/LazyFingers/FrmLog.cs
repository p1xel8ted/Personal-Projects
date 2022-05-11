using System;
using System.IO;
using System.Windows.Forms;

namespace LazyFingers
{
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            try
            {
                TxtLog.Text = File.ReadAllText(Application.StartupPath + "/log.txt");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void FrmLog_Shown(object sender, EventArgs e)
        {
            TxtLog.SelectionLength = 0;
            TxtLog.Select(TxtLog.Text.Length, 0);
            TxtLog.ScrollToCaret();
        }
    }
}
