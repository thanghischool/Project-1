using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;

namespace Web_mua_bán_sách
{
    public partial class Thao_Tac_Bang_Giong_Noi : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Sarah = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;
        public Thao_Tac_Bang_Giong_Noi()
        {
            InitializeComponent();
        }

        private void Thao_Tac_Bang_Giong_Noi_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(new string[] { "Wake up" }))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
            startlistening.RecognizeAsync(RecognizeMode.Single);
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Hello")
            {
                Sarah.SpeakAsync("Hello, I am here");
            }
            else if (speech == "How are you")
            {
                Sarah.SpeakAsync("I am working normally");
            }
            else if (speech == "What time is it")
            {
                Sarah.SpeakAsync(DateTime.Now.ToString("h:mm tt"));
            }
            else if (speech == "open google")
            {
                Process.Start("https://www.google.com/");
                Sarah.SpeakAsync("Okay, I opened google");
            }
            else if (speech == "promotion")
            {
                Process.Start("https://magiamgia.com/");
                Sarah.SpeakAsync("Okay, I opened promotion");
            }
            else if(speech == "close google")
            {
                foreach (Process process in Process.GetProcessesByName("chrome"))
                {
                    process.Kill();
                }
                Sarah.SpeakAsync("Okay, I closed google");
            }
            else if(speech == "happy rebirth")
            {
                this.Close();
                thong_tin_san_pham t = new thong_tin_san_pham();
                t.Show();
            }
            else if (speech == "exit")
            {
                Sarah.SpeakAsync("Goodbye!");
                System.Threading.Thread.Sleep(2000); // Cho giọng nói kết thúc trước khi thoát ứng dụng
                Application.Exit();
            }

                if (speech == "Stop talking")
            {
                Sarah.SpeakAsyncCancelAll();
                int ranNum = rnd.Next(1, 2);
                if (ranNum == 1)
                {
                    Sarah.SpeakAsync("Yes sir");
                }
                else if (ranNum == 2)
                {
                    Sarah.SpeakAsync("I am sorry, I will be quiet");
                }
                if (speech == "Stop Listening")
                {
                    Sarah.SpeakAsync("If you need me, just ask");
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }

            }

            if (speech == "Show Commands")
            {
                string[] commands = File.ReadAllLines(@"DefaultCommands.txt");
               
                LstCommands.Items.Clear();
                LstCommands.SelectionMode = SelectionMode.None;
                LstCommands.Visible = true;
                foreach (string command in commands)
                {
                    LstCommands.Items.Add(command);
                }
            }
            else if (speech == "Hide Commands")
            {
                LstCommands.Items.Clear();
                LstCommands.Visible = false;
            }

        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                Sarah.SpeakAsync("Yes, I am here");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                TmrSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }
    }
}
