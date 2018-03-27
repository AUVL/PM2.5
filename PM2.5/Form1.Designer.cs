namespace PM2._5
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_lng = new System.Windows.Forms.Label();
            this.label_lat = new System.Windows.Forms.Label();
            this.label_alt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_lng
            // 
            this.label_lng.AutoSize = true;
            this.label_lng.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_lng.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lng.Location = new System.Drawing.Point(17, 14);
            this.label_lng.Name = "label_lng";
            this.label_lng.Size = new System.Drawing.Size(78, 19);
            this.label_lng.TabIndex = 6;
            this.label_lng.Text = "Longitude";
            // 
            // label_lat
            // 
            this.label_lat.AutoSize = true;
            this.label_lat.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lat.Location = new System.Drawing.Point(193, 14);
            this.label_lat.Name = "label_lat";
            this.label_lat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_lat.Size = new System.Drawing.Size(65, 19);
            this.label_lat.TabIndex = 7;
            this.label_lat.Text = "Latitude";
            // 
            // label_alt
            // 
            this.label_alt.AutoSize = true;
            this.label_alt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_alt.Location = new System.Drawing.Point(349, 14);
            this.label_alt.Name = "label_alt";
            this.label_alt.Size = new System.Drawing.Size(64, 19);
            this.label_alt.TabIndex = 8;
            this.label_alt.Text = "Altitude";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_lng);
            this.panel1.Controls.Add(this.label_lat);
            this.panel1.Controls.Add(this.label_alt);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 48);
            this.panel1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_lng;
        private System.Windows.Forms.Label label_lat;
        private System.Windows.Forms.Label label_alt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
    }
}

