using Microsoft.CognitiveServices.Speech;
using Microsoft.Speech.Recognition;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTSLib;

namespace Kiosk_UI
{
    public partial class TakeoutForm : Form
    {
        public int select_check = 0;
        private PictureBox curbutton;

        TextToSpeechConverter tts = new TextToSpeechConverter();
        private void actbutton(object senderBtn)
        {

            if (senderBtn != null)
            {
                DisableButton();
                curbutton = (PictureBox)senderBtn;
                curbutton.BackColor = Color.FromArgb(244, 211, 123);
            }
        }
        private SpeechRecognitionEngine recognizer;
        private async Task CallingKeyword()
        {
            recognizer = new SpeechRecognitionEngine();

            // 음성 인식 이벤트 핸들러 등록
            recognizer.SpeechRecognized += async (s, e) =>
            {
                recognizer.RecognizeAsyncStop();
                Console.WriteLine($"Recognized: {e.Result.Text}");
                if (e.Result.Text.Contains("매장"))
                {
                    select_check = 1;
                    Yesbutton.PerformClick();
                }
                else if (e.Result.Text.Contains("포장"))
                {
                    select_check = 1;
                    Yesbutton.PerformClick();
                }
                CallingKeyword();
            };

            // Grammar 생성 및 로드
            var grammar = new Microsoft.Speech.Recognition.Grammar(new Choices("매장","포장"));
            if (grammar != null)
            {
                recognizer.LoadGrammar(grammar);
            }
            var choices = new Choices("설명서");
            Console.WriteLine(choices);
            // 음성 인식 시작
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }
        private void DisableButton()
        {
            if (curbutton != null)
            {
                curbutton.BackColor = Color.White;
            }
        }
        private void Reset()
        {
            DisableButton();
        }
        public TakeoutForm()
        {
            InitializeComponent();
            CallingKeyword();
        }

        private void Nobutton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cafe_Click(object sender, EventArgs e)
        {
            select_check = 1;
            actbutton(sender);
        }

        private void takeout_Click(object sender, EventArgs e)
        {
            select_check = 1;
            actbutton(sender);
        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            if (select_check < 1)
            {
                tts.Speak("매장과 포장 중 선택해주세요");
                Form modalbackground = new Form();
                using (warning modal = new warning())
                {
                    modal.ShowDialog();
                    modalbackground.Dispose();

                    this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                }
            }
            else
            {
                FinishForm finishForm = new FinishForm();

                this.Hide();
                finishForm.ShowDialog();
            }
            /* using(var frm = new FinishForm())
             {
                 frm.ShowDialog();
             }*/

        }

        private void TakeoutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.NumPad2)
            {
                takeout_Click(this.takeout, e);
            }
            else if(e.KeyCode == Keys.NumPad1)
            {
                cafe_Click(this.cafe, e);
            }
            if(e.KeyCode == Keys.Enter)
            {
                Yesbutton.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                Nobutton.PerformClick();
            }
        }

        private void TakeoutForm_Shown(object sender, EventArgs e)
        {
           tts.Speak("매장은 일번, 포장은 이번을 눌러주세요. 확인은 엔터키를, 다시 선택하시려면 뒤로가기키를 눌러주세요.");
        }
    }
}
