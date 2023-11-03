namespace Kiosk_UI
{
    partial class PayCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.custom_panel1 = new Kiosk_UI.Custom.Custom_panel();
            this.Yesbutton = new Kiosk_UI.Custom.Custom_button();
            this.Nobutton = new Kiosk_UI.Custom.Custom_button();
            this.paygrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custom_panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paygrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Moccasin;
            this.label1.Location = new System.Drawing.Point(110, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "결제하시겠습니까?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // custom_panel1
            // 
            this.custom_panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.custom_panel1.BackColor = System.Drawing.Color.White;
            this.custom_panel1.BorderColor = System.Drawing.Color.White;
            this.custom_panel1.Controls.Add(this.Yesbutton);
            this.custom_panel1.Controls.Add(this.Nobutton);
            this.custom_panel1.Controls.Add(this.paygrid);
            this.custom_panel1.Edge = 20;
            this.custom_panel1.Location = new System.Drawing.Point(0, 107);
            this.custom_panel1.Margin = new System.Windows.Forms.Padding(0);
            this.custom_panel1.Name = "custom_panel1";
            this.custom_panel1.Size = new System.Drawing.Size(484, 654);
            this.custom_panel1.TabIndex = 9;
            // 
            // Yesbutton
            // 
            this.Yesbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yesbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(73)))), ((int)(((byte)(72)))));
            this.Yesbutton.FlatAppearance.BorderSize = 0;
            this.Yesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yesbutton.ForeColor = System.Drawing.Color.White;
            this.Yesbutton.Location = new System.Drawing.Point(268, 543);
            this.Yesbutton.Name = "Yesbutton";
            this.Yesbutton.Size = new System.Drawing.Size(176, 63);
            this.Yesbutton.TabIndex = 8;
            this.Yesbutton.Text = "custom_button2";
            this.Yesbutton.UseVisualStyleBackColor = false;
            // 
            // Nobutton
            // 
            this.Nobutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Nobutton.BackColor = System.Drawing.Color.IndianRed;
            this.Nobutton.FlatAppearance.BorderSize = 0;
            this.Nobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nobutton.ForeColor = System.Drawing.Color.White;
            this.Nobutton.Location = new System.Drawing.Point(46, 543);
            this.Nobutton.Name = "Nobutton";
            this.Nobutton.Size = new System.Drawing.Size(176, 63);
            this.Nobutton.TabIndex = 7;
            this.Nobutton.Text = "custom_button1";
            this.Nobutton.UseVisualStyleBackColor = false;
            this.Nobutton.Click += new System.EventHandler(this.Nobutton_Click);
            // 
            // paygrid
            // 
            this.paygrid.AllowUserToAddRows = false;
            this.paygrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paygrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.paygrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.paygrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paygrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.paygrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔스퀘어", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paygrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.paygrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paygrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paygrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.paygrid.EnableHeadersVisualStyles = false;
            this.paygrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.paygrid.Location = new System.Drawing.Point(46, 48);
            this.paygrid.Name = "paygrid";
            this.paygrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans KR", 16F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.paygrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.paygrid.RowTemplate.Height = 23;
            this.paygrid.Size = new System.Drawing.Size(398, 450);
            this.paygrid.TabIndex = 6;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "음식";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "개수";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "금액";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // PayCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(93)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.custom_panel1);
            this.Name = "PayCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayCheck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.PayCheck_Shown);
            this.custom_panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paygrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView paygrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Custom.Custom_panel custom_panel1;
        private Custom.Custom_button Yesbutton;
        private Custom.Custom_button Nobutton;
        private System.Windows.Forms.Label label1;
    }
}