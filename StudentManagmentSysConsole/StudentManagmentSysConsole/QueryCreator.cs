﻿using Microsoft.SqlServer.Server;
using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    class QueryCreator
    {
        private string Query { get; set; }

        public string Input { get; set; }

        public int State { get; set; }

        public User User { get; set; }

        public QueryCreator(User user)
        {
            User = user;
        }
        
        public string ReturnQuery()
        {
            if (Query != null)
            {
                return Query;
            }
            else return "Query not created!";
        }

        public void CreateQuery(string input, int state)
        {
            string[] stringArray = input.Split(' ');
            switch (state)
            {
                case 1:
                    switch (stringArray[0])
                    {
                        case "student":
                            Query = 
                                String.Format("INSERT INTO Students (firstname, lastname, subject, teacher, letterID)" +
                                "VALUES ('{0}', '{1}', '{2}', '{3}' 'S')",
                                stringArray[1], stringArray[2], User.Subject, User.FirstName + " " + User.LastName);
                            break;
                        case "grade":
                            break;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void CreateQuery(string input)
        {
            switch (input)
            {
                case "G":
                    Query = String.Format("SELECT * From Grades Where student = {0} {1}",
                        User.FirstName, User.LastName);
                    break;
                case "S":
                    Query = String.Format("SELECT * From Students Where firstname = {0} AND lastname = {1}",
                        User.FirstName, User.LastName);
                    break;
                case "T":
                    Query = String.Format("SELECT * From Students Where firstname = {0} AND lastname = {1}",
                        User.FirstName, User.LastName);
                    break;
                case "A":
                    Query = String.Format("SELECT * From Students Where firstname = {0} AND lastname = {1}" +
                                          "UNION" +
                                          "SELECT * From Grades Where student = {0} {1}",
                                            User.FirstName, User.LastName);
                    break;
            }
        }
    }
}
