using QuiZFormMain.model;
using QuiZFormMain.Viewmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiZFormMain
{
    public partial class StartForm : Form
    {
        
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Visual Studio Projects\Projects\QuiZProjectWF\QuiZFormMain\QuizzDb.mdf;Integrated Security=True");

        public StartFormViewModel sfvm;
        public StartForm()
        {
            InitializeComponent();

            sfvm = new StartFormViewModel();
        }

  

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string combo = comboBox2.Text;

            textBox2.Clear();
          
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(Question.Question)FROM Subject INNER JOIN Question ON Subject.ID = Question.SubjectID WHERE Subject.Name =  '" + combo + "' ";
            object numberOFQuestion = cmd.ExecuteScalar();
            string num = numberOFQuestion.ToString();
            
            textBox2.Text = num;
            con.Close();//Closing connection
        }

   

        public void StartForm_Load(object sender, EventArgs e)
        {
            
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            textBox2.Clear();
            label7.Text = sfvm.CurrentUser.Name;
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select Name FROM Subject";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);

            foreach (Subject s in sfvm.ListSubjects)
            {
                comboBox2.Items.Add(s.Name);
            }


            foreach (User u in sfvm.ListUsers)
            {
                comboBox1.Items.Add(u.Name);
                
            }

            //cmd.CommandText = "Select Name FROM [User]";//as User is a reserved name it needs to be in brackets
            //cmd.ExecuteNonQuery();
            //dt = new DataTable();
            //da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    comboBox1.Items.Add(dr["Name"].ToString());
            //}

            //comboBox2.Text = "Geography";

            string subject = comboBox2.SelectedText;
           //string subject = "Geography";
           //cmd.CommandText = "SELECT COUNT(Question.Question)FROM Subject INNER JOIN Question ON Subject.ID = Question.SubjectID WHERE Subject.Name =  '"+subject+"' ";

           // object numberOFQuestion = cmd.ExecuteScalar();
           // string num = numberOFQuestion.ToString();
            

           // textBox2.Text = num;


            con.Close();//Closing connection

        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label7.Text = comboBox1.SelectedItem.ToString();
            
            label7.Text = comboBox1.SelectedItem.ToString();
        }
    }
}
