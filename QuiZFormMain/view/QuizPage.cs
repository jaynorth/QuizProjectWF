using QuiZFormMain.Viewmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiZFormMain
{
    public partial class QuizPage : Form
    {
        QuizPageViewModel qpv = new QuizPageViewModel();
        int index = 0;
        public QuizPage()
        {
            InitializeComponent();
            
        }

  

        private void QuizPage_Load(object sender, EventArgs e)
        {
            LoadformControls();
        }

        private void ClearformControls()
        {
            textBox1.Clear();
            label1.Text = String.Empty;
            groupBox1.Controls.Clear();

        }

        private void LoadformControls()
        {
            label1.Text = "Question Number :" + qpv.CurrentQuestion.Id.ToString();
            textBox1.Text = qpv.CurrentQuestion.ToString();
            //listBox1.DataSource = qpv.CurrentQuestion.Question_choices;
            int count = 1;
            foreach (var choice in qpv.CurrentQuestion.Question_choices)
            {

                RadioButton r = new RadioButton();
                r.Name = "RadioChoice" + count;
                r.Text = "" + choice;
                r.Location = new Point(0, 20 * count);

                groupBox1.Controls.Add(r);

                count++;
            }
        }

    
        private void button1_Click(object sender, EventArgs e)
        {//NEXT bouton
            ClearformControls();
            
            //changing current question to next one
            index++;//changes to next question index in list
            if (index >= qpv.ListQuestions.Count)
            {
                index = 0;
            }

            qpv.CurrentQuestion = qpv.ListQuestions[index];

            LoadformControls();
      
        }

        private void button2_Click(object sender, EventArgs e)
        {//PREVIOUS Button

            ClearformControls();
            //changing current question to next one
            index--;//changes to next question index in list
            if (index < 0)
            {
                index = qpv.ListQuestions.Count()-1;
            }
            qpv.CurrentQuestion = qpv.ListQuestions[index];

            LoadformControls();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            CheckRadioState();
        }

        private void CheckRadioState()
        {
            foreach (Control ctl in groupBox1.Controls)
            {
                Console.WriteLine(ctl.Name + " " + ctl.Text + " " + ctl.GetType().Name);
                if (ctl is RadioButton)
                {
                    RadioButton rb = (RadioButton)ctl;
                    MessageBox.Show(rb.Checked.ToString());
                }

            }
        }
    }
}
