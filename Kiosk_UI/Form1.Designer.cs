namespace Kiosk_UI
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
    private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.VoiceButton = new Kiosk_UI.Custom_button.Custom_button();
            this.DessertButton = new Kiosk_UI.Custom_button.Custom_button();
            this.DrinkButton = new Kiosk_UI.Custom_button.Custom_button();
            this.AllmenuButton = new Kiosk_UI.Custom_button.Custom_button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new Kiosk_UI.Custom_button.Custom_panel();
            this.SelectbarPanel = new System.Windows.Forms.Panel();
            this.CartPanel = new Kiosk_UI.Custom_button.Custom_panel();
            this.panel1.SuspendLayout();
            this.SelectbarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.VoiceButton);
            this.panel1.Controls.Add(this.DessertButton);
            this.panel1.Controls.Add(this.DrinkButton);
            this.panel1.Controls.Add(this.AllmenuButton);
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 397);
            this.panel1.TabIndex = 3;
            // 
            // VoiceButton
            // 
            this.VoiceButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.VoiceButton.FlatAppearance.BorderSize = 0;
            this.VoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VoiceButton.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VoiceButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.VoiceButton.Location = new System.Drawing.Point(0, 324);
            this.VoiceButton.Name = "VoiceButton";
            this.VoiceButton.Size = new System.Drawing.Size(107, 56);
            this.VoiceButton.TabIndex = 8;
            this.VoiceButton.Text = "음성검색";
            this.VoiceButton.UseVisualStyleBackColor = false;
            this.VoiceButton.Click += new System.EventHandler(this.VoiceButton_Click);
            // 
            // DessertButton
            // 
            this.DessertButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.DessertButton.FlatAppearance.BorderSize = 0;
            this.DessertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DessertButton.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DessertButton.ForeColor = System.Drawing.Color.White;
            this.DessertButton.Location = new System.Drawing.Point(0, 224);
            this.DessertButton.Name = "DessertButton";
            this.DessertButton.Size = new System.Drawing.Size(107, 56);
            this.DessertButton.TabIndex = 7;
            this.DessertButton.Text = "디저트";
            this.DessertButton.UseVisualStyleBackColor = false;
            this.DessertButton.Click += new System.EventHandler(this.DessertButton_Click);
            // 
            // DrinkButton
            // 
            this.DrinkButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.DrinkButton.FlatAppearance.BorderSize = 0;
            this.DrinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrinkButton.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DrinkButton.ForeColor = System.Drawing.Color.White;
            this.DrinkButton.Location = new System.Drawing.Point(0, 124);
            this.DrinkButton.Name = "DrinkButton";
            this.DrinkButton.Size = new System.Drawing.Size(107, 56);
            this.DrinkButton.TabIndex = 6;
            this.DrinkButton.Text = "음료";
            this.DrinkButton.UseVisualStyleBackColor = false;
            this.DrinkButton.Click += new System.EventHandler(this.DrinkButton_Click);
            // 
            // AllmenuButton
            // 
            this.AllmenuButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.AllmenuButton.FlatAppearance.BorderSize = 0;
            this.AllmenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllmenuButton.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AllmenuButton.ForeColor = System.Drawing.Color.White;
            this.AllmenuButton.Location = new System.Drawing.Point(0, 24);
            this.AllmenuButton.Name = "AllmenuButton";
            this.AllmenuButton.Size = new System.Drawing.Size(107, 56);
            this.AllmenuButton.TabIndex = 0;
            this.AllmenuButton.Text = "모든메뉴";
            this.AllmenuButton.UseVisualStyleBackColor = false;
            this.AllmenuButton.Click += new System.EventHandler(this.AllmenuButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(163)))), ((int)(((byte)(138)))));
            this.TopPanel.Location = new System.Drawing.Point(9, 12);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(468, 37);
            this.TopPanel.TabIndex = 2;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.AutoScroll = true;
            this.MenuPanel.BackColor = System.Drawing.Color.White;
            this.MenuPanel.BorderColor = System.Drawing.Color.White;
            this.MenuPanel.Edge = 20;
            this.MenuPanel.Location = new System.Drawing.Point(125, 132);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(352, 417);
            this.MenuPanel.TabIndex = 4;
            // 
            // SelectbarPanel
            // 
            this.SelectbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectbarPanel.BackColor = System.Drawing.Color.Transparent;
            this.SelectbarPanel.Controls.Add(this.panel1);
            this.SelectbarPanel.Location = new System.Drawing.Point(9, 132);
            this.SelectbarPanel.Name = "SelectbarPanel";
            this.SelectbarPanel.Size = new System.Drawing.Size(113, 417);
            this.SelectbarPanel.TabIndex = 1;
            // 
            // CartPanel
            // 
            this.CartPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartPanel.BackColor = System.Drawing.Color.Silver;
            this.CartPanel.BorderColor = System.Drawing.Color.Transparent;
            this.CartPanel.Edge = 20;
            this.CartPanel.Location = new System.Drawing.Point(9, 555);
            this.CartPanel.Name = "CartPanel";
            this.CartPanel.Size = new System.Drawing.Size(468, 194);
            this.CartPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.CartPanel);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SelectbarPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.SelectbarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel panel1;
        private Custom_button.Custom_button AllmenuButton;
        private Custom_button.Custom_button DrinkButton;
        private Custom_button.Custom_button VoiceButton;
        private Custom_button.Custom_button DessertButton;
        private Custom_button.Custom_panel MenuPanel;
        private System.Windows.Forms.Panel SelectbarPanel;
        private Custom_button.Custom_panel CartPanel;
    }
}

