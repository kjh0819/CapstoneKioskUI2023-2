using Kiosk_UI.Custom;
using Microsoft.Speech.Recognition;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_UI
{
    public partial class PayCheck : Form
    {
        DataTable passedIndt;

        private SpeechRecognitionEngine recognizer;
        private async Task CallingKeyword()
        {
            recognizer = new SpeechRecognitionEngine();

            // 음성 인식 이벤트 핸들러 등록
            recognizer.SpeechRecognized += async (s, e) =>
            {
                recognizer.RecognizeAsyncStop();
                Console.WriteLine($"Recognized: {e.Result.Text}");
                if (e.Result.Text.Contains("결제"))
                {
                    Yesbutton.PerformClick();
                }
                else if (e.Result.Text.Contains("취소"))
                {
                    Nobutton.PerformClick();
                }
                CallingKeyword();
            };

            // Grammar 생성 및 로드
            var grammar = new Microsoft.Speech.Recognition.Grammar(new Choices("결제", "취소"));
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

        private void PayCheck_KeyDown_1(object sender, KeyEventArgs e)
        {
            // Call arsKey method when Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                arsKey(e);
                Yesbutton.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                Nobutton.PerformClick();
            }
        }
        public void arsKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Yesbutton.PerformClick();
        }
        public PayCheck()
        {
            InitializeComponent();
            CallingKeyword();
            this.AcceptButton = Yesbutton;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nobutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Hide();
        }

        private void PayCheck_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = passedIndt;
        }
        public string labeltxt
        {
            get { return this.costtxt.Text; }
            set { this.costtxt.Text = value; }
        }
        public PayCheck(DataTable table)
        {
            InitializeComponent();
            CallingKeyword();
            this.passedIndt = table;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TakeoutForm takeout = new TakeoutForm();

            DialogResult result1 = takeout.ShowDialog();
            this.Hide();
            if (result1 == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();

            }


            //this.Hide();
            //takeout.ShowDialog();
        }

      
    }
}

