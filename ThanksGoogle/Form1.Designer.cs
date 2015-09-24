namespace ThanksGoogle
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBX_West = new System.Windows.Forms.TextBox();
            this.TBX_North = new System.Windows.Forms.TextBox();
            this.TBX_East = new System.Windows.Forms.TextBox();
            this.TBX_South = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBL_TolalPages = new System.Windows.Forms.Label();
            this.LBL_Process = new System.Windows.Forms.Label();
            this.TBX_ExportPath = new System.Windows.Forms.TextBox();
            this.BTN_ExportPath = new System.Windows.Forms.Button();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TBX_ServerUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(43, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "精細度(越大越細):";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(281, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(87, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "影像類型:";
            // 
            // TBX_West
            // 
            this.TBX_West.Location = new System.Drawing.Point(21, 40);
            this.TBX_West.Name = "TBX_West";
            this.TBX_West.Size = new System.Drawing.Size(100, 22);
            this.TBX_West.TabIndex = 4;
            this.TBX_West.Text = "119";
            this.TBX_West.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBX_North
            // 
            this.TBX_North.Location = new System.Drawing.Point(127, 27);
            this.TBX_North.Name = "TBX_North";
            this.TBX_North.Size = new System.Drawing.Size(100, 22);
            this.TBX_North.TabIndex = 5;
            this.TBX_North.Text = "26";
            this.TBX_North.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBX_East
            // 
            this.TBX_East.Location = new System.Drawing.Point(233, 40);
            this.TBX_East.Name = "TBX_East";
            this.TBX_East.Size = new System.Drawing.Size(100, 22);
            this.TBX_East.TabIndex = 6;
            this.TBX_East.Text = "122";
            this.TBX_East.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBX_South
            // 
            this.TBX_South.Location = new System.Drawing.Point(127, 54);
            this.TBX_South.Name = "TBX_South";
            this.TBX_South.Size = new System.Drawing.Size(100, 22);
            this.TBX_South.TabIndex = 7;
            this.TBX_South.Text = "21";
            this.TBX_South.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TBX_West);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TBX_North);
            this.groupBox1.Controls.Add(this.TBX_South);
            this.groupBox1.Controls.Add(this.TBX_East);
            this.groupBox1.Location = new System.Drawing.Point(14, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "範圍(WGS84經緯)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "下";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "右";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "上";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "左";
            // 
            // LBL_TolalPages
            // 
            this.LBL_TolalPages.AutoSize = true;
            this.LBL_TolalPages.Location = new System.Drawing.Point(12, 247);
            this.LBL_TolalPages.Name = "LBL_TolalPages";
            this.LBL_TolalPages.Size = new System.Drawing.Size(68, 12);
            this.LBL_TolalPages.TabIndex = 9;
            this.LBL_TolalPages.Text = "預估總張數:";
            // 
            // LBL_Process
            // 
            this.LBL_Process.AutoSize = true;
            this.LBL_Process.Location = new System.Drawing.Point(12, 271);
            this.LBL_Process.Name = "LBL_Process";
            this.LBL_Process.Size = new System.Drawing.Size(56, 12);
            this.LBL_Process.TabIndex = 10;
            this.LBL_Process.Text = "剩餘張數:";
            // 
            // TBX_ExportPath
            // 
            this.TBX_ExportPath.Location = new System.Drawing.Point(71, 153);
            this.TBX_ExportPath.Name = "TBX_ExportPath";
            this.TBX_ExportPath.Size = new System.Drawing.Size(221, 22);
            this.TBX_ExportPath.TabIndex = 11;
            // 
            // BTN_ExportPath
            // 
            this.BTN_ExportPath.Location = new System.Drawing.Point(298, 152);
            this.BTN_ExportPath.Name = "BTN_ExportPath";
            this.BTN_ExportPath.Size = new System.Drawing.Size(75, 23);
            this.BTN_ExportPath.TabIndex = 12;
            this.BTN_ExportPath.Text = "瀏覽...";
            this.BTN_ExportPath.UseVisualStyleBackColor = true;
            this.BTN_ExportPath.Click += new System.EventHandler(this.BTN_ExportPath_Click);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Location = new System.Drawing.Point(298, 260);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(75, 23);
            this.BTN_Start.TabIndex = 13;
            this.BTN_Start.Text = "開始";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "輸出目錄:";
            // 
            // TBX_ServerUrl
            // 
            this.TBX_ServerUrl.Location = new System.Drawing.Point(71, 182);
            this.TBX_ServerUrl.Name = "TBX_ServerUrl";
            this.TBX_ServerUrl.Size = new System.Drawing.Size(221, 22);
            this.TBX_ServerUrl.TabIndex = 15;
            this.TBX_ServerUrl.Text = "http://127.0.0.1:8080";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "轉座標:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 295);
            this.Controls.Add(this.TBX_ServerUrl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BTN_Start);
            this.Controls.Add(this.BTN_ExportPath);
            this.Controls.Add(this.TBX_ExportPath);
            this.Controls.Add(this.LBL_Process);
            this.Controls.Add(this.LBL_TolalPages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "感謝谷歌";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBX_West;
        private System.Windows.Forms.TextBox TBX_North;
        private System.Windows.Forms.TextBox TBX_East;
        private System.Windows.Forms.TextBox TBX_South;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBL_TolalPages;
        private System.Windows.Forms.Label LBL_Process;
        private System.Windows.Forms.TextBox TBX_ExportPath;
        private System.Windows.Forms.Button BTN_ExportPath;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBX_ServerUrl;
        private System.Windows.Forms.Label label10;
    }
}

