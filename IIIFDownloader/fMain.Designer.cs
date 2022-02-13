
namespace IIIFDownloader
{
    partial class fMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lManifest = new System.Windows.Forms.Label();
            this.tManifest = new System.Windows.Forms.TextBox();
            this.bDownload = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lManifest
            // 
            this.lManifest.AutoSize = true;
            this.lManifest.Location = new System.Drawing.Point(12, 9);
            this.lManifest.Name = "lManifest";
            this.lManifest.Size = new System.Drawing.Size(50, 13);
            this.lManifest.TabIndex = 0;
            this.lManifest.Text = "Manifest:";
            // 
            // tManifest
            // 
            this.tManifest.Location = new System.Drawing.Point(68, 6);
            this.tManifest.Name = "tManifest";
            this.tManifest.Size = new System.Drawing.Size(373, 20);
            this.tManifest.TabIndex = 1;
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(447, 4);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(75, 23);
            this.bDownload.TabIndex = 2;
            this.bDownload.Text = "Download";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(15, 53);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(507, 23);
            this.pbProgress.TabIndex = 3;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(12, 79);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(16, 13);
            this.lStatus.TabIndex = 4;
            this.lStatus.Text = "...";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 99);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.tManifest);
            this.Controls.Add(this.lManifest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "IIIF Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lManifest;
        private System.Windows.Forms.TextBox tManifest;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lStatus;
    }
}

