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
            this.components = new System.ComponentModel.Container();
            this.MenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SelectbarPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VoiceButton = new System.Windows.Forms.Button();
            this.DessertButton = new System.Windows.Forms.Button();
            this.DrinkButton = new System.Windows.Forms.Button();
            this.AllmenuButton = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CartPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu_radio = new System.Windows.Forms.RadioButton();
            this.drink_radio = new System.Windows.Forms.RadioButton();
            this.dessert_radio = new System.Windows.Forms.RadioButton();
            this.voice_radio = new System.Windows.Forms.RadioButton();
            this.SelectbarPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.AutoScroll = true;
            this.MenuPanel.BackColor = System.Drawing.Color.White;
            this.MenuPanel.Location = new System.Drawing.Point(132, 132);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(345, 417);
            this.MenuPanel.TabIndex = 0;
            // 
            // SelectbarPanel
            // 
            this.SelectbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectbarPanel.BackColor = System.Drawing.Color.White;
            this.SelectbarPanel.Controls.Add(this.panel1);
            this.SelectbarPanel.Location = new System.Drawing.Point(9, 66);
            this.SelectbarPanel.Name = "SelectbarPanel";
            this.SelectbarPanel.Size = new System.Drawing.Size(117, 483);
            this.SelectbarPanel.TabIndex = 1;
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
            this.panel1.Size = new System.Drawing.Size(111, 463);
            this.panel1.TabIndex = 3;
            // 
            // VoiceButton
            // 
            this.VoiceButton.Location = new System.Drawing.Point(0, 393);
            this.VoiceButton.Name = "VoiceButton";
            this.VoiceButton.Size = new System.Drawing.Size(110, 58);
            this.VoiceButton.TabIndex = 5;
            this.VoiceButton.Text = "음성검색";
            this.VoiceButton.UseVisualStyleBackColor = true;
            this.VoiceButton.Click += new System.EventHandler(this.VoiceButton_Click);
            // 
            // DessertButton
            // 
            this.DessertButton.Location = new System.Drawing.Point(0, 273);
            this.DessertButton.Name = "DessertButton";
            this.DessertButton.Size = new System.Drawing.Size(110, 58);
            this.DessertButton.TabIndex = 4;
            this.DessertButton.Text = "디저트";
            this.DessertButton.UseVisualStyleBackColor = true;
            this.DessertButton.Click += new System.EventHandler(this.DessertButton_Click);
            // 
            // DrinkButton
            // 
            this.DrinkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DrinkButton.Location = new System.Drawing.Point(0, 160);
            this.DrinkButton.Name = "DrinkButton";
            this.DrinkButton.Size = new System.Drawing.Size(110, 58);
            this.DrinkButton.TabIndex = 1;
            this.DrinkButton.Text = "음료";
            this.DrinkButton.UseVisualStyleBackColor = true;
            this.DrinkButton.Click += new System.EventHandler(this.DrinkButton_Click);
            // 
            // AllmenuButton
            // 
            this.AllmenuButton.BackColor = System.Drawing.Color.Gainsboro;
            this.AllmenuButton.FlatAppearance.BorderSize = 0;
            this.AllmenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllmenuButton.ForeColor = System.Drawing.Color.Black;
            this.AllmenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AllmenuButton.Location = new System.Drawing.Point(0, 49);
            this.AllmenuButton.Name = "AllmenuButton";
            this.AllmenuButton.Size = new System.Drawing.Size(110, 58);
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
            // CartPanel
            // 
            this.CartPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CartPanel.Location = new System.Drawing.Point(9, 555);
            this.CartPanel.Name = "CartPanel";
            this.CartPanel.Size = new System.Drawing.Size(468, 194);
            this.CartPanel.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.button_tick);
            // 
            // menu_radio
            // 
            this.menu_radio.AutoSize = true;
            this.menu_radio.Location = new System.Drawing.Point(168, 55);
            this.menu_radio.Name = "menu_radio";
            this.menu_radio.Size = new System.Drawing.Size(92, 16);
            this.menu_radio.TabIndex = 0;
            this.menu_radio.TabStop = true;
            this.menu_radio.Text = "radioButton1";
            this.menu_radio.UseVisualStyleBackColor = true;
            this.menu_radio.CheckedChanged += new System.EventHandler(this.menu_radio_CheckedChanged);
            // 
            // drink_radio
            // 
            this.drink_radio.AutoSize = true;
            this.drink_radio.Location = new System.Drawing.Point(168, 77);
            this.drink_radio.Name = "drink_radio";
            this.drink_radio.Size = new System.Drawing.Size(92, 16);
            this.drink_radio.TabIndex = 4;
            this.drink_radio.TabStop = true;
            this.drink_radio.Text = "radioButton2";
            this.drink_radio.UseVisualStyleBackColor = true;
            // 
            // dessert_radio
            // 
            this.dessert_radio.AutoSize = true;
            this.dessert_radio.Location = new System.Drawing.Point(168, 99);
            this.dessert_radio.Name = "dessert_radio";
            this.dessert_radio.Size = new System.Drawing.Size(92, 16);
            this.dessert_radio.TabIndex = 5;
            this.dessert_radio.TabStop = true;
            this.dessert_radio.Text = "radioButton3";
            this.dessert_radio.UseVisualStyleBackColor = true;
            // 
            // voice_radio
            // 
            this.voice_radio.AutoSize = true;
            this.voice_radio.Location = new System.Drawing.Point(168, 121);
            this.voice_radio.Name = "voice_radio";
            this.voice_radio.Size = new System.Drawing.Size(92, 16);
            this.voice_radio.TabIndex = 6;
            this.voice_radio.TabStop = true;
            this.voice_radio.Text = "radioButton4";
            this.voice_radio.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.voice_radio);
            this.Controls.Add(this.dessert_radio);
            this.Controls.Add(this.drink_radio);
            this.Controls.Add(this.menu_radio);
            this.Controls.Add(this.CartPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SelectbarPanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SelectbarPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuPanel;
        private System.Windows.Forms.Panel SelectbarPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AllmenuButton;
        private System.Windows.Forms.Panel CartPanel;
        private System.Windows.Forms.Button VoiceButton;
        private System.Windows.Forms.Button DessertButton;
        private System.Windows.Forms.Button DrinkButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton menu_radio;
        private System.Windows.Forms.RadioButton drink_radio;
        private System.Windows.Forms.RadioButton dessert_radio;
        private System.Windows.Forms.RadioButton voice_radio;
    }
}

