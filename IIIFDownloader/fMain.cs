using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIIFDownloader
{
    public partial class fMain : Form
    {
        Downloader BookDownloader;

        public fMain()
        {
            InitializeComponent();
        }

        private void CheckState()
        {
            bDownload.Enabled = (BookDownloader == null);
        }

        private void SetStatus(bool Ok, string Text)
        {
            lStatus.Text = Text;
            lStatus.ForeColor = Ok ? Color.DarkGreen : Color.DarkRed;

            if (BookDownloader != null)
            {
                if (!BookDownloader.IsRunning())
                {
                    BookDownloader = null;
                    CheckState();
                }
            }
        }

        private void bDownload_Click(object sender, EventArgs e)
        {
            if (tManifest.Text.Length > 0)
            {
                BookDownloader = new Downloader(tManifest.Text);
                BookDownloader.onStatus += BookDownloader_onStatus;

                CheckState();
            }
            else
                SetStatus(false, "Путь к манифесту не задан");
        }

        private void BookDownloader_onStatus(object sender, StatusEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                    Invoke((MethodInvoker)delegate { SetStatus(e.Ok, e.Status); });
                else
                    SetStatus(e.Ok, e.Status);
            }
            catch(Exception E)
            {

            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(BookDownloader != null)
            {
                BookDownloader.onStatus -= BookDownloader_onStatus;
                BookDownloader.Cancel();
            }
        }
    }
}
