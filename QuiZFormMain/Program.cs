﻿using QuiZFormMain.model;
using QuiZFormMain.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiZFormMain
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new StartForm());
            Application.Run(new QuizPage());

            //Console.WriteLine("test");
            //StartFormViewModel stvm = new StartFormViewModel();

            //foreach (User u in stvm.ListUsers)
            //{
            //    Console.WriteLine(u.Name);
            //}
        }
    }
}
