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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_lng = new System.Windows.Forms.Label();
            this.label_lat = new System.Windows.Forms.Label();
            this.label_alt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Longitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Altitude";
            // 
            // label_lng
            // 
            this.label_lng.AutoSize = true;
            this.label_lng.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_lng.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lng.Location = new System.Drawing.Point(136, 71);
            this.label_lng.Name = "label_lng";
            this.label_lng.Size = new System.Drawing.Size(0, 19);
            this.label_lng.TabIndex = 6;
            // 
            // label_lat
            // 
            this.label_lat.AutoSize = true;
            this.label_lat.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lat.Location = new System.Drawing.Point(136, 99);
            this.label_lat.Name = "label_lat";
            this.label_lat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_lat.Size = new System.Drawing.Size(0, 19);
            this.label_lat.TabIndex = 7;
            // 
            // label_alt
            // 
            this.label_alt.AutoSize = true;
            this.label_alt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_alt.Location = new System.Drawing.Point(136, 127);
            this.label_alt.Name = "label_alt";
            this.label_alt.Size = new System.Drawing.Size(0, 19);
            this.label_alt.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 228);
            this.Controls.Add(this.label_alt);
            this.Controls.Add(this.label_lat);
            this.Controls.Add(this.label_lng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_lng;
        private System.Windows.Forms.Label label_lat;
        private System.Windows.Forms.Label label_alt;
    }
}

