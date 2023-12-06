namespace Kiosk_UI
{
    partial class TakeoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeoutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.custom_panel1 = new Kiosk_UI.Custom.Custom_panel();
            this.custom_flowpanel1 = new Kiosk_UI.Custom.Custom_flowpanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.takeout = new System.Windows.Forms.PictureBox();
            this.cafe = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Yesbutton = new Kiosk_UI.Custom.Custom_button();
            this.Nobutton = new Kiosk_UI.Custom.Custom_button();
            this.custom_panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.takeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cafe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Moccasin;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "매장과 포장 중 선택해주세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // custom_panel1
            // 
            this.custom_panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.custom_panel1.BackColor = System.Drawing.Color.White;
            this.custom_panel1.BorderColor = System.Drawing.Color.White;
            this.custom_panel1.Controls.Add(this.custom_flowpanel1);
            this.custom_panel1.Controls.Add(this.panel2);
            this.custom_panel1.Controls.Add(this.Yesbutton);
            this.custom_panel1.Controls.Add(this.Nobutton);
            this.custom_panel1.Edge = 20;
            this.custom_panel1.Location = new System.Drawing.Point(0, 107);
            this.custom_panel1.Margin = new System.Windows.Forms.Padding(0);
            this.custom_panel1.Name = "custom_panel1";
            this.custom_panel1.Size = new System.Drawing.Size(484, 658);
            this.custom_panel1.TabIndex = 0;
            // 
            // custom_flowpanel1
            // 
            this.custom_flowpanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.custom_flowpanel1.BackColor = System.Drawing.Color.Goldenrod;
            this.custom_flowpanel1.BorderColor = System.Drawing.Color.White;
            this.custom_flowpanel1.Edge = 20;
            this.custom_flowpanel1.Location = new System.Drawing.Point(241, 60);
            this.custom_flowpanel1.Name = "custom_flowpanel1";
            this.custom_flowpanel1.Size = new System.Drawing.Size(10, 470);
            this.custom_flowpanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.takeout);
            this.panel2.Controls.Add(this.cafe);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 255);
            this.panel2.TabIndex = 0;
            // 
            // takeout
            // 
            this.takeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.takeout.BackColor = System.Drawing.Color.White;
            this.takeout.Image = ((System.Drawing.Image)(resources.GetObject("takeout.Image")));
            this.takeout.Location = new System.Drawing.Point(12, 13);
            this.takeout.Name = "takeout";
            this.takeout.Size = new System.Drawing.Size(207, 206);
            this.takeout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.takeout.TabIndex = 11;
            this.takeout.TabStop = false;
            this.takeout.Click += new System.EventHandler(this.takeout_Click);
            // 
            // cafe
            // 
            this.cafe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cafe.BackColor = System.Drawing.Color.White;
            this.cafe.Image = ((System.Drawing.Image)(resources.GetObject("cafe.Image")));
            this.cafe.Location = new System.Drawing.Point(262, 13);
            this.cafe.Name = "cafe";
            this.cafe.Size = new System.Drawing.Size(207, 206);
            this.cafe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cafe.TabIndex = 10;
            this.cafe.TabStop = false;
            this.cafe.Click += new System.EventHandler(this.cafe_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(28, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "포장";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(266, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "매장";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yesbutton
            // 
            this.Yesbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yesbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(73)))), ((int)(((byte)(72)))));
            this.Yesbutton.FlatAppearance.BorderSize = 0;
            this.Yesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yesbutton.Font = new System.Drawing.Font("Noto Sans KR Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Yesbutton.ForeColor = System.Drawing.Color.White;
            this.Yesbutton.Location = new System.Drawing.Point(281, 547);
            this.Yesbutton.Name = "Yesbutton";
            this.Yesbutton.Size = new System.Drawing.Size(176, 63);
            this.Yesbutton.TabIndex = 1;
            this.Yesbutton.Text = "결제하기";
            this.Yesbutton.UseVisualStyleBackColor = false;
            this.Yesbutton.Click += new System.EventHandler(this.Yesbutton_Click);
            // 
            // Nobutton
            // 
            this.Nobutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Nobutton.BackColor = System.Drawing.Color.IndianRed;
            this.Nobutton.FlatAppearance.BorderSize = 0;
            this.Nobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nobutton.Font = new System.Drawing.Font("Noto Sans KR Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Nobutton.ForeColor = System.Drawing.Color.White;
            this.Nobutton.Location = new System.Drawing.Point(33, 547);
            this.Nobutton.Name = "Nobutton";
            this.Nobutton.Size = new System.Drawing.Size(176, 63);
            this.Nobutton.TabIndex = 2;
            this.Nobutton.Text = "다시 선택하기";
            this.Nobutton.UseVisualStyleBackColor = false;
            this.Nobutton.Click += new System.EventHandler(this.Nobutton_Click);
            // 
            // TakeoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(93)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.custom_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TakeoutForm";
            this.Text = "TakeoutForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.TakeoutForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeoutForm_KeyDown);
            this.custom_panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.takeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cafe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Custom.Custom_button Yesbutton;
        private Custom.Custom_button Nobutton;
        private System.Windows.Forms.Label label1;
        private Custom.Custom_flowpanel custom_flowpanel1;
        private Custom.Custom_panel custom_panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox cafe;
        private System.Windows.Forms.PictureBox takeout;
    }
}