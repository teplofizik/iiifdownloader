using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IIIFDownloader
{
    class Downloader
    {
        public event StatusEventHandler onStatus;

        private string ManifestUrl;
        private string ManifestFile;
        private Thread DownloadThread;

        private bool Running = true;
        public bool IsRunning() => Running;

        /// <summary>
        /// Error
        /// </summary>
        private string Status = "";

        /// <summary>
        /// Is process cancelled
        /// </summary>
        private bool Cancelled = false;

        /// <summary>
        /// Manifest
        /// </summary>
        private IIIF.Manifest Manifest = null;

        public Downloader(string ManifestUrl)
        {
            this.ManifestUrl = ManifestUrl;

            DownloadThread = new Thread(ProcessThread);
            DownloadThread.Start();
        }

        void UpdateStatus(bool Ok, string Status, bool Finish = false)
        {
            this.Status = Status;
            Running = !Finish;

            onStatus?.Invoke(this, new StatusEventArgs(Ok, Status));
        }

        public void Cancel()
        {
            Cancelled = true;
        }

        bool Download()
        {
            if (IsURL(ManifestUrl))
            {
                WebClient wc = new WebClient();

                var Data = wc.DownloadData(ManifestUrl);
                ManifestFile = UTF8Encoding.UTF8.GetString(Data);
                Manifest = JsonConvert.DeserializeObject<IIIF.Manifest>(ManifestFile);
            }
            else
            {
                ManifestFile = File.ReadAllText(ManifestUrl);
                Manifest = JsonConvert.DeserializeObject<IIIF.Manifest>(ManifestFile);
            }

            return true;
        }

        bool IsURL(string Url)
        {
            Uri uriResult;
            return Uri.TryCreate(Url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttps);
        }

        void ProcessThread()
        {
            WebClient wc = new WebClient();

            UpdateStatus(false, $"Downloading {ManifestUrl}!");
            if (Download())
            {
                var Name = Manifest.Label;
                var DestDir = $"{Name}";
                if(!Directory.Exists(DestDir))
                    Directory.CreateDirectory(DestDir);

                if (!File.Exists($"{DestDir}/manifest.json"))
                    File.WriteAllText($"{DestDir}/manifest.json", ManifestFile);

                if (Manifest.Sequences.Count > 0)
                {
                    var Seq = Manifest.Sequences[0];
                    if (Seq.Canvases.Count > 0)
                    {
                        foreach(var C in Seq.Canvases)
                        {
                            bool IsDownloaded = false;

                            if(C.Images.Count > 0)
                            {
                                var Img = C.Images[0];
                                var Url = Img.Resource.Id;
                                var Ext = Path.GetExtension(Url);
                                var FN = $"{DestDir}/{C.Label}{Ext}";

                                if (!File.Exists(FN))
                                {
                                    UpdateStatus(false, $"Download page {C.Label}.");
                                    var Data = wc.DownloadData(Url);
                                    File.WriteAllBytes(FN, Data);
                                    UpdateStatus(false, $"Download page {C.Label} - ok.");

                                    IsDownloaded = true;
                                }
                            }

                            if (!Cancelled)
                            {
                                if(IsDownloaded) Thread.Sleep(4000);
                            }
                            else
                                break;
                        }

                        UpdateStatus(false, $"Completed.", true);
                    }
                    else
                        UpdateStatus(false, "No canvases in sequence.", true);
                }
                else
                    UpdateStatus(false, "No sequences.", true);
            }
            else
                UpdateStatus(false, "Download error!", true);
        }
    }

    public class StatusEventArgs : EventArgs
    {
        public bool Ok;
        public string Status;

        public StatusEventArgs(bool Ok, string Status)
        {
            this.Ok = Ok;
            this.Status = Status;
        }
    }
    public delegate void StatusEventHandler(object sender, StatusEventArgs e);
}
