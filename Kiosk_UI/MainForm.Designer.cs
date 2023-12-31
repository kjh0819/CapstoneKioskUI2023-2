﻿namespace Kiosk_UI
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.SelectbarPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VoiceButton = new Kiosk_UI.Custom.Custom_button();
            this.DessertButton = new Kiosk_UI.Custom.Custom_button();
            this.DrinkButton = new Kiosk_UI.Custom.Custom_button();
            this.AllmenuButton = new Kiosk_UI.Custom.Custom_button();
            this.cancel_button = new Kiosk_UI.Custom.Custom_button();
            this.cost_panel = new Kiosk_UI.Custom.Custom_panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cost_lbl = new System.Windows.Forms.Label();
            this.checkPanel = new Kiosk_UI.Custom.Custom_flowpanel();
            this.custom_button1 = new Kiosk_UI.Custom.Custom_button();
            this.MenuPanel = new Kiosk_UI.Custom.Custom_flowpanel();
            this.SelectbarPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cost_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(93)))), ((int)(((byte)(64)))));
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(481, 79);
            this.TopPanel.TabIndex = 2;
            // 
            // SelectbarPanel
            // 
            this.SelectbarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectbarPanel.BackColor = System.Drawing.Color.Transparent;
            this.SelectbarPanel.Controls.Add(this.panel1);
            this.SelectbarPanel.Location = new System.Drawing.Point(9, 150);
            this.SelectbarPanel.Name = "SelectbarPanel";
            this.SelectbarPanel.Size = new System.Drawing.Size(133, 399);
            this.SelectbarPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.VoiceButton);
            this.panel1.Controls.Add(this.DessertButton);
            this.panel1.Controls.Add(this.DrinkButton);
            this.panel1.Controls.Add(this.AllmenuButton);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 397);
            this.panel1.TabIndex = 3;
            // 
            // VoiceButton
            // 
            this.VoiceButton.BackColor = System.Drawing.Color.Moccasin;
            this.VoiceButton.FlatAppearance.BorderSize = 0;
            this.VoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VoiceButton.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VoiceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(62)))), ((int)(((byte)(45)))));
            this.VoiceButton.Location = new System.Drawing.Point(0, 324);
            this.VoiceButton.Name = "VoiceButton";
            this.VoiceButton.Size = new System.Drawing.Size(124, 70);
            this.VoiceButton.TabIndex = 8;
            this.VoiceButton.Text = "음성검색";
            this.VoiceButton.UseVisualStyleBackColor = false;
            this.VoiceButton.Click += new System.EventHandler(this.VoiceButton_Click);
            // 
            // DessertButton
            // 
            this.DessertButton.BackColor = System.Drawing.Color.Moccasin;
            this.DessertButton.FlatAppearance.BorderSize = 0;
            this.DessertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DessertButton.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DessertButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(62)))), ((int)(((byte)(45)))));
            this.DessertButton.Location = new System.Drawing.Point(0, 224);
            this.DessertButton.Name = "DessertButton";
            this.DessertButton.Size = new System.Drawing.Size(124, 70);
            this.DessertButton.TabIndex = 7;
            this.DessertButton.Text = "디저트";
            this.DessertButton.UseVisualStyleBackColor = false;
            this.DessertButton.Click += new System.EventHandler(this.DessertButton_Click);
            // 
            // DrinkButton
            // 
            this.DrinkButton.BackColor = System.Drawing.Color.Moccasin;
            this.DrinkButton.FlatAppearance.BorderSize = 0;
            this.DrinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrinkButton.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DrinkButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(62)))), ((int)(((byte)(45)))));
            this.DrinkButton.Location = new System.Drawing.Point(0, 124);
            this.DrinkButton.Name = "DrinkButton";
            this.DrinkButton.Size = new System.Drawing.Size(124, 70);
            this.DrinkButton.TabIndex = 6;
            this.DrinkButton.Text = "음료";
            this.DrinkButton.UseVisualStyleBackColor = false;
            this.DrinkButton.Click += new System.EventHandler(this.DrinkButton_Click);
            // 
            // AllmenuButton
            // 
            this.AllmenuButton.BackColor = System.Drawing.Color.Moccasin;
            this.AllmenuButton.FlatAppearance.BorderSize = 0;
            this.AllmenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllmenuButton.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AllmenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(62)))), ((int)(((byte)(45)))));
            this.AllmenuButton.Location = new System.Drawing.Point(0, 24);
            this.AllmenuButton.Name = "AllmenuButton";
            this.AllmenuButton.Size = new System.Drawing.Size(124, 70);
            this.AllmenuButton.TabIndex = 0;
            this.AllmenuButton.Text = "모든메뉴";
            this.AllmenuButton.UseVisualStyleBackColor = false;
            this.AllmenuButton.Click += new System.EventHandler(this.AllmenuButton_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel_button.BackColor = System.Drawing.Color.IndianRed;
            this.cancel_button.FlatAppearance.BorderSize = 0;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button.Font = new System.Drawing.Font("Noto Sans KR Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel_button.ForeColor = System.Drawing.Color.White;
            this.cancel_button.Location = new System.Drawing.Point(9, 576);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(70, 172);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "전체\r\n취소";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // cost_panel
            // 
            this.cost_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cost_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(73)))), ((int)(((byte)(51)))));
            this.cost_panel.BorderColor = System.Drawing.Color.White;
            this.cost_panel.Controls.Add(this.label1);
            this.cost_panel.Controls.Add(this.cost_lbl);
            this.cost_panel.Edge = 20;
            this.cost_panel.Location = new System.Drawing.Point(249, 577);
            this.cost_panel.Name = "cost_panel";
            this.cost_panel.Size = new System.Drawing.Size(129, 172);
            this.cost_panel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(133)))), ((int)(((byte)(96)))));
            this.label1.Font = new System.Drawing.Font("Noto Sans KR Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(223)))), ((int)(((byte)(173)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 67);
            this.label1.TabIndex = 8;
            this.label1.Text = "총 금액";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cost_lbl
            // 
            this.cost_lbl.BackColor = System.Drawing.Color.Moccasin;
            this.cost_lbl.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cost_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(62)))), ((int)(((byte)(45)))));
            this.cost_lbl.Location = new System.Drawing.Point(0, 67);
            this.cost_lbl.Name = "cost_lbl";
            this.cost_lbl.Size = new System.Drawing.Size(129, 108);
            this.cost_lbl.TabIndex = 0;
            this.cost_lbl.Text = "label1";
            this.cost_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkPanel
            // 
            this.checkPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkPanel.AutoScroll = true;
            this.checkPanel.BackColor = System.Drawing.Color.OldLace;
            this.checkPanel.BorderColor = System.Drawing.Color.White;
            this.checkPanel.Edge = 20;
            this.checkPanel.Location = new System.Drawing.Point(85, 576);
            this.checkPanel.Name = "checkPanel";
            this.checkPanel.Padding = new System.Windows.Forms.Padding(5);
            this.checkPanel.Size = new System.Drawing.Size(158, 173);
            this.checkPanel.TabIndex = 8;
            // 
            // custom_button1
            // 
            this.custom_button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.custom_button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(73)))), ((int)(((byte)(72)))));
            this.custom_button1.FlatAppearance.BorderSize = 0;
            this.custom_button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custom_button1.Font = new System.Drawing.Font("Noto Sans KR Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.custom_button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(223)))), ((int)(((byte)(173)))));
            this.custom_button1.Location = new System.Drawing.Point(384, 577);
            this.custom_button1.Name = "custom_button1";
            this.custom_button1.Size = new System.Drawing.Size(97, 172);
            this.custom_button1.TabIndex = 0;
            this.custom_button1.Text = "결제\r\n하기";
            this.custom_button1.UseVisualStyleBackColor = false;
            this.custom_button1.Click += new System.EventHandler(this.custom_button1_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.AutoScroll = true;
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(151)))), ((int)(((byte)(115)))));
            this.MenuPanel.BorderColor = System.Drawing.Color.White;
            this.MenuPanel.Edge = 20;
            this.MenuPanel.Location = new System.Drawing.Point(125, 150);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MenuPanel.Size = new System.Drawing.Size(347, 399);
            this.MenuPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.cost_panel);
            this.Controls.Add(this.checkPanel);
            this.Controls.Add(this.custom_button1);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SelectbarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.SelectbarPanel.ResumeLayout(false);
            this.SelectbarPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cost_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TopPanel;
        private Custom.Custom_flowpanel MenuPanel;
        private Custom.Custom_button custom_button1;
        private Custom.Custom_flowpanel checkPanel;

        private void initializeComponent()
        {
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.BorderColor = System.Drawing.Color.DarkGreen;

        }

        private Custom.Custom_panel cost_panel;
        private Custom.Custom_button cancel_button;
        private System.Windows.Forms.Label cost_lbl;
        private System.Windows.Forms.Panel SelectbarPanel;
        private System.Windows.Forms.Panel panel1;
        private Custom.Custom_button VoiceButton;
        private Custom.Custom_button DessertButton;
        private Custom.Custom_button DrinkButton;
        private Custom.Custom_button AllmenuButton;
        private System.Windows.Forms.Label label1;
    }
}

