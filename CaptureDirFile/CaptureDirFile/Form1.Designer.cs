namespace CaptureDirFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_srcPath = new System.Windows.Forms.TextBox();
            this.btn_source = new System.Windows.Forms.Button();
            this.txt_destPath = new System.Windows.Forms.TextBox();
            this.btn_destination = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_srcPath
            // 
            this.txt_srcPath.Location = new System.Drawing.Point(65, 14);
            this.txt_srcPath.Name = "txt_srcPath";
            this.txt_srcPath.Size = new System.Drawing.Size(233, 22);
            this.txt_srcPath.TabIndex = 0;
            // 
            // btn_source
            // 
            this.btn_source.Location = new System.Drawing.Point(313, 12);
            this.btn_source.Name = "btn_source";
            this.btn_source.Size = new System.Drawing.Size(55, 23);
            this.btn_source.TabIndex = 1;
            this.btn_source.Text = "Select";
            this.btn_source.UseVisualStyleBackColor = true;
            this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
            // 
            // txt_destPath
            // 
            this.txt_destPath.Location = new System.Drawing.Point(65, 47);
            this.txt_destPath.Name = "txt_destPath";
            this.txt_destPath.Size = new System.Drawing.Size(233, 22);
            this.txt_destPath.TabIndex = 2;
            // 
            // btn_destination
            // 
            this.btn_destination.Location = new System.Drawing.Point(313, 45);
            this.btn_destination.Name = "btn_destination";
            this.btn_destination.Size = new System.Drawing.Size(56, 23);
            this.btn_destination.TabIndex = 3;
            this.btn_destination.Text = "Select";
            this.btn_destination.UseVisualStyleBackColor = true;
            this.btn_destination.Click += new System.EventHandler(this.btn_destination_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Src Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dst Path:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 84);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_destination);
            this.Controls.Add(this.txt_destPath);
            this.Controls.Add(this.btn_source);
            this.Controls.Add(this.txt_srcPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CapFileMove";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_srcPath;
        private System.Windows.Forms.Button btn_source;
        private System.Windows.Forms.TextBox txt_destPath;
        private System.Windows.Forms.Button btn_destination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

