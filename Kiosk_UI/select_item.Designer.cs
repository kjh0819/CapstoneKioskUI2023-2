namespace Kiosk_UI
{
    partial class select_item
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.item_count = new System.Windows.Forms.Label();
            this.txtImg2 = new System.Windows.Forms.PictureBox();
            this.minus_button = new Kiosk_UI.Custom.Custom_circle();
            this.plus_button = new Kiosk_UI.Custom.Custom_circle();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImg2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.item_count);
            this.panel1.Controls.Add(this.minus_button);
            this.panel1.Controls.Add(this.plus_button);
            this.panel1.Controls.Add(this.txtImg2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 160);
            this.panel1.TabIndex = 0;
            // 
            // item_count
            // 
            this.item_count.AutoSize = true;
            this.item_count.BackColor = System.Drawing.Color.OldLace;
            this.item_count.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.item_count.Location = new System.Drawing.Point(68, 125);
            this.item_count.Name = "item_count";
            this.item_count.Size = new System.Drawing.Size(19, 24);
            this.item_count.TabIndex = 3;
            this.item_count.Text = "1";
            // 
            // txtImg2
            // 
            this.txtImg2.Image = global::Kiosk_UI.Properties.Resources.americano;
            this.txtImg2.Location = new System.Drawing.Point(24, 16);
            this.txtImg2.Name = "txtImg2";
            this.txtImg2.Size = new System.Drawing.Size(100, 100);
            this.txtImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtImg2.TabIndex = 0;
            this.txtImg2.TabStop = false;
            // 
            // minus_button
            // 
            this.minus_button.BackColor = System.Drawing.Color.Pink;
            this.minus_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minus_button.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minus_button.ForeColor = System.Drawing.Color.White;
            this.minus_button.Location = new System.Drawing.Point(98, 121);
            this.minus_button.Name = "minus_button";
            this.minus_button.Size = new System.Drawing.Size(30, 30);
            this.minus_button.TabIndex = 2;
            this.minus_button.Text = "-";
            this.minus_button.UseVisualStyleBackColor = false;
            this.minus_button.Click += new System.EventHandler(this.minus_button_Click);
            // 
            // plus_button
            // 
            this.plus_button.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.plus_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plus_button.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.plus_button.ForeColor = System.Drawing.Color.White;
            this.plus_button.Location = new System.Drawing.Point(24, 121);
            this.plus_button.Name = "plus_button";
            this.plus_button.Size = new System.Drawing.Size(30, 30);
            this.plus_button.TabIndex = 1;
            this.plus_button.Text = "+";
            this.plus_button.UseVisualStyleBackColor = false;
            this.plus_button.Click += new System.EventHandler(this.plus_button_Click);
            // 
            // select_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "select_item";
            this.Size = new System.Drawing.Size(150, 160);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImg2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox txtImg2;
        private System.Windows.Forms.Label item_count;
        private Custom.Custom_circle minus_button;
        private Custom.Custom_circle plus_button;
    }
}
