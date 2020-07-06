using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Threading;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Diagnostics;


namespace WindowsFormsApplication13
{
    public partial class frmIPV6Disable : Form
    {
        public frmIPV6Disable()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\TCPIP6\Parameters");

                key.SetValue("DisabledComponents", unchecked((int)0xffffffff), RegistryValueKind.DWord);

                MessageBox.Show("Done, Please Restart The System ---- >>>> PRESS RESTART BUTTON FOR RESTART NOW ");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Registry Disabled Error " + ex.ToString());
                this.Dispose();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure want to Restart The System", "RESTART", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.WindowStyle = ProcessWindowStyle.Hidden;
                proc.FileName = "cmd";
                proc.Arguments = "/C shutdown -f -r -t 5";
                Process.Start(proc);
            }
        }
    }
}
