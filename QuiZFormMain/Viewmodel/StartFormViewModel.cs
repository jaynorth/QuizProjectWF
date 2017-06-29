using QuiZFormMain.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiZFormMain.Viewmodel
{
    public class StartFormViewModel
    {

        private static SqlConnection con; 

        public StartFormViewModel()
        {
            con =  new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Visual Studio Projects\Projects\QuiZProjectWF\QuiZFormMain\QuizzDb.mdf;Integrated Security=True");
            // https://stackoverflow.com/questions/18754688/c-sharp-how-to-implement-method-that-return-list-of-sql-result

            _listUsers = new List<User>();
            _listSubjects = new List<Subject>();
     


            using (con)
            {
                con.Open();
                string query = "SELECT * FROM [User]";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User u = new User();
                            u.Id = Convert.ToInt32(reader["Id"]);
                            u.Name = reader["Name"].ToString();

                            _listUsers.Add(u);
                        }
                    }
                }

                query = "SELECT * FROM [Subject]";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Subject s = new Subject();
                            s.Id = Convert.ToInt32(reader["Id"]);
                            s.Name = reader["Name"].ToString();

                            _listSubjects.Add(s);
                        }
                    }
                }
            }


            _currentUser = ListUsers[0];
            _currentSubject = ListSubjects[0];
        }




        private List<User> _listUsers;

        public List<User> ListUsers
        {
            get { return _listUsers; }
            set { _listUsers = value; }
        }

        private List<Subject> _listSubjects;
            
        public List<Subject> ListSubjects
        {
            get { return _listSubjects; }
            set { _listSubjects = value; }
        }

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        private Subject _currentSubject;

        public Subject CurrentSubject
        {
            get { return _currentSubject; }
            set { _currentSubject = value; }
        }






    }
}
