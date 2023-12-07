using AutoMotorControl;
using Kiosk_UI.Custom;
using System;
using System.Windows.Forms;
using TTSLib;

namespace Kiosk_UI
{
    public partial class FinishForm : Form
    {
        private System.Windows.Forms.Timer tmr;

        TextToSpeechConverter tts = new TextToSpeechConverter();

        public FinishForm()
        {
            try
            {
                MotorControl motorControl = new MotorControl();
                motorControl.Finished();
            }
            catch (Exception ex)
            {
                Console.WriteLine("모터제어 오류 FinishForm");
                Console.WriteLine(ex.Message);
            }
            InitializeComponent();

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate
            {
                tmr.Stop();
                this.Close();
                this.DialogResult = DialogResult.Cancel;

            };
            tmr.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            tmr.Start();

        }

        private void FinishForm_Shown(object sender, EventArgs e)
        {
            tts.Speak("결제가 완료되었습니다. 이용해주셔서 감사합니다");
        }
    }
}
