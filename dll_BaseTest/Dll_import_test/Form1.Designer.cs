namespace Dll_import_test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txb_path = new System.Windows.Forms.TextBox();
            this.btn_Download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.ckb_autoRun = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ckb_ipl = new System.Windows.Forms.CheckBox();
            this.ckb_defpara = new System.Windows.Forms.CheckBox();
            this.ckb_spl = new System.Windows.Forms.CheckBox();
            this.ckb_otapara = new System.Windows.Forms.CheckBox();
            this.ckb_linux = new System.Windows.Forms.CheckBox();
            this.ckb_runpara = new System.Windows.Forms.CheckBox();
            this.ckb_calibration = new System.Windows.Forms.CheckBox();
            this.ckb_userdata = new System.Windows.Forms.CheckBox();
            this.ckb_rootfs = new System.Windows.Forms.CheckBox();
            this.ckb_log = new System.Windows.Forms.CheckBox();
            this.ckb_partition = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txb_path
            // 
            this.txb_path.Enabled = false;
            this.txb_path.Location = new System.Drawing.Point(12, 29);
            this.txb_path.Name = "txb_path";
            this.txb_path.Size = new System.Drawing.Size(415, 22);
            this.txb_path.TabIndex = 0;
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(107, 70);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(75, 23);
            this.btn_Download.TabIndex = 1;
            this.btn_Download.Text = "Download";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(12, 70);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_readBin_Click);
            // 
            // ckb_autoRun
            // 
            this.ckb_autoRun.AutoSize = true;
            this.ckb_autoRun.Location = new System.Drawing.Point(365, 70);
            this.ckb_autoRun.Name = "ckb_autoRun";
            this.ckb_autoRun.Size = new System.Drawing.Size(67, 16);
            this.ckb_autoRun.TabIndex = 4;
            this.ckb_autoRun.Text = "AutoRun";
            this.ckb_autoRun.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 142);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(389, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // ckb_ipl
            // 
            this.ckb_ipl.AutoSize = true;
            this.ckb_ipl.Location = new System.Drawing.Point(14, 187);
            this.ckb_ipl.Name = "ckb_ipl";
            this.ckb_ipl.Size = new System.Drawing.Size(33, 16);
            this.ckb_ipl.TabIndex = 6;
            this.ckb_ipl.Text = "ip";
            this.ckb_ipl.UseVisualStyleBackColor = true;
            // 
            // ckb_defpara
            // 
            this.ckb_defpara.AutoSize = true;
            this.ckb_defpara.Location = new System.Drawing.Point(14, 210);
            this.ckb_defpara.Name = "ckb_defpara";
            this.ckb_defpara.Size = new System.Drawing.Size(59, 16);
            this.ckb_defpara.TabIndex = 7;
            this.ckb_defpara.Text = "defpara";
            this.ckb_defpara.UseVisualStyleBackColor = true;
            // 
            // ckb_spl
            // 
            this.ckb_spl.AutoSize = true;
            this.ckb_spl.Location = new System.Drawing.Point(98, 187);
            this.ckb_spl.Name = "ckb_spl";
            this.ckb_spl.Size = new System.Drawing.Size(37, 16);
            this.ckb_spl.TabIndex = 8;
            this.ckb_spl.Text = "spl";
            this.ckb_spl.UseVisualStyleBackColor = true;
            // 
            // ckb_otapara
            // 
            this.ckb_otapara.AutoSize = true;
            this.ckb_otapara.Location = new System.Drawing.Point(98, 209);
            this.ckb_otapara.Name = "ckb_otapara";
            this.ckb_otapara.Size = new System.Drawing.Size(58, 16);
            this.ckb_otapara.TabIndex = 9;
            this.ckb_otapara.Text = "otapara";
            this.ckb_otapara.UseVisualStyleBackColor = true;
            // 
            // ckb_linux
            // 
            this.ckb_linux.AutoSize = true;
            this.ckb_linux.Location = new System.Drawing.Point(182, 187);
            this.ckb_linux.Name = "ckb_linux";
            this.ckb_linux.Size = new System.Drawing.Size(48, 16);
            this.ckb_linux.TabIndex = 10;
            this.ckb_linux.Text = "linux";
            this.ckb_linux.UseVisualStyleBackColor = true;
            // 
            // ckb_runpara
            // 
            this.ckb_runpara.AutoSize = true;
            this.ckb_runpara.Location = new System.Drawing.Point(182, 210);
            this.ckb_runpara.Name = "ckb_runpara";
            this.ckb_runpara.Size = new System.Drawing.Size(60, 16);
            this.ckb_runpara.TabIndex = 11;
            this.ckb_runpara.Text = "runpara";
            this.ckb_runpara.UseVisualStyleBackColor = true;
            // 
            // ckb_calibration
            // 
            this.ckb_calibration.AutoSize = true;
            this.ckb_calibration.Location = new System.Drawing.Point(266, 187);
            this.ckb_calibration.Name = "ckb_calibration";
            this.ckb_calibration.Size = new System.Drawing.Size(73, 16);
            this.ckb_calibration.TabIndex = 12;
            this.ckb_calibration.Text = "calibration";
            this.ckb_calibration.UseVisualStyleBackColor = true;
            // 
            // ckb_userdata
            // 
            this.ckb_userdata.AutoSize = true;
            this.ckb_userdata.Location = new System.Drawing.Point(266, 208);
            this.ckb_userdata.Name = "ckb_userdata";
            this.ckb_userdata.Size = new System.Drawing.Size(62, 16);
            this.ckb_userdata.TabIndex = 13;
            this.ckb_userdata.Text = "userdata";
            this.ckb_userdata.UseVisualStyleBackColor = true;
            // 
            // ckb_rootfs
            // 
            this.ckb_rootfs.AutoSize = true;
            this.ckb_rootfs.Location = new System.Drawing.Point(350, 186);
            this.ckb_rootfs.Name = "ckb_rootfs";
            this.ckb_rootfs.Size = new System.Drawing.Size(51, 16);
            this.ckb_rootfs.TabIndex = 14;
            this.ckb_rootfs.Text = "rootfs";
            this.ckb_rootfs.UseVisualStyleBackColor = true;
            // 
            // ckb_log
            // 
            this.ckb_log.AutoSize = true;
            this.ckb_log.Location = new System.Drawing.Point(350, 208);
            this.ckb_log.Name = "ckb_log";
            this.ckb_log.Size = new System.Drawing.Size(39, 16);
            this.ckb_log.TabIndex = 15;
            this.ckb_log.Text = "log";
            this.ckb_log.UseVisualStyleBackColor = true;
            // 
            // ckb_partition
            // 
            this.ckb_partition.AutoSize = true;
            this.ckb_partition.Location = new System.Drawing.Point(365, 93);
            this.ckb_partition.Name = "ckb_partition";
            this.ckb_partition.Size = new System.Drawing.Size(63, 16);
            this.ckb_partition.TabIndex = 16;
            this.ckb_partition.Text = "Partition";
            this.ckb_partition.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 266);
            this.Controls.Add(this.ckb_partition);
            this.Controls.Add(this.ckb_log);
            this.Controls.Add(this.ckb_rootfs);
            this.Controls.Add(this.ckb_userdata);
            this.Controls.Add(this.ckb_calibration);
            this.Controls.Add(this.ckb_runpara);
            this.Controls.Add(this.ckb_linux);
            this.Controls.Add(this.ckb_otapara);
            this.Controls.Add(this.ckb_spl);
            this.Controls.Add(this.ckb_defpara);
            this.Controls.Add(this.ckb_ipl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ckb_autoRun);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Download);
            this.Controls.Add(this.txb_path);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_path;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.CheckBox ckb_autoRun;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox ckb_ipl;
        private System.Windows.Forms.CheckBox ckb_defpara;
        private System.Windows.Forms.CheckBox ckb_spl;
        private System.Windows.Forms.CheckBox ckb_otapara;
        private System.Windows.Forms.CheckBox ckb_linux;
        private System.Windows.Forms.CheckBox ckb_runpara;
        private System.Windows.Forms.CheckBox ckb_calibration;
        private System.Windows.Forms.CheckBox ckb_userdata;
        private System.Windows.Forms.CheckBox ckb_rootfs;
        private System.Windows.Forms.CheckBox ckb_log;
        private System.Windows.Forms.CheckBox ckb_partition;
    }
}

