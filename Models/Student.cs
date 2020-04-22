using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAPI.Models
{
    public class Student
    {
        //define all the properties of the table with get and set

        public int Id { get; set; }

        public string f_name { get; set; }

        public string l_name { get; set; }

        public string address { get; set; }

        public string birthDate { get; set; }

        public string score { get; set; }

        public string dep_id { get; set; }

        
        // will creat a class to create an object of student class
        public class CreateStudent : Student
        {

        }


        public class ReadStudent : Student
        {
            public ReadStudent(DataRow row)
            {
                Id = Convert.ToInt32(row["Id"]);
                f_name = row["f_name"].ToString();
                l_name = row["l_name"].ToString();
                address = row["address"].ToString();
                birthDate = row["birthDate"].ToString();
                score = row["score"].ToString();
                dep_id = row["dep_id"].ToString();

            }

            public new int Id { get; set; }

            public new string f_name { get; set; }

            public new string l_name { get; set; }

            public new string address { get; set; }

            public new string birthDate { get; set; }

            public new string score { get; set; }

            public new string dep_id { get; set; }
        }

    }
}