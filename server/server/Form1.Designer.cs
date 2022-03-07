namespace server
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
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.port_Lab = new System.Windows.Forms.Label();
            this.ip_Lab = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.ip_TB = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.log_LB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 17;
            this.onlineList_LB.Location = new System.Drawing.Point(39, 116);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(214, 310);
            this.onlineList_LB.TabIndex = 17;
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.port_Lab.Location = new System.Drawing.Point(147, 25);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(40, 17);
            this.port_Lab.TabIndex = 16;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ip_Lab
            // 
            this.ip_Lab.AutoSize = true;
            this.ip_Lab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ip_Lab.Location = new System.Drawing.Point(13, 24);
            this.ip_Lab.Name = "ip_Lab";
            this.ip_Lab.Size = new System.Drawing.Size(26, 17);
            this.ip_Lab.TabIndex = 15;
            this.ip_Lab.Text = "IP :";
            this.ip_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // port_TB
            // 
            this.port_TB.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.port_TB.Location = new System.Drawing.Point(191, 21);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 25);
            this.port_TB.TabIndex = 14;
            this.port_TB.Text = "5236";
            // 
            // ip_TB
            // 
            this.ip_TB.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ip_TB.Location = new System.Drawing.Point(43, 21);
            this.ip_TB.Name = "ip_TB";
            this.ip_TB.Size = new System.Drawing.Size(100, 25);
            this.ip_TB.TabIndex = 13;
            this.ip_TB.Text = "127.0.0.1";
            // 
            // connectBtn
            // 
            this.connectBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.connectBtn.Location = new System.Drawing.Point(39, 65);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(213, 35);
            this.connectBtn.TabIndex = 11;
            this.connectBtn.Text = "建立連線";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // log_LB
            // 
            this.log_LB.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.log_LB.FormattingEnabled = true;
            this.log_LB.ItemHeight = 17;
            this.log_LB.Location = new System.Drawing.Point(306, 14);
            this.log_LB.Margin = new System.Windows.Forms.Padding(2);
            this.log_LB.Name = "log_LB";
            this.log_LB.Size = new System.Drawing.Size(367, 412);
            this.log_LB.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 455);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.ip_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.ip_TB);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.log_LB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label ip_Lab;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox ip_TB;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ListBox log_LB;
    }
}

