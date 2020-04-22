using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentAPI.Models;
using static StudentAPI.Models.Student;

namespace StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>
        // decleare sql connection command object

        private SqlConnection conn;
        private SqlDataAdapter adapter;


        public IEnumerable<Student> Get()
        {
            conn = new SqlConnection("data source=localhost;Initial catalog=College; User Id =personal;Integrated Security=SSPI;Persist Security Info=False;");
            
            DataTable _dt = new DataTable();

            var query = "select * from Student";

            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, conn)
            };

            adapter.Fill(_dt);

            List<Student> students = new List<Models.Student>(_dt.Rows.Count);

            if(_dt.Rows.Count > 0)
            {
                foreach(DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }

        // GET api/<controller>
        public IEnumerable<Student> Get (int id)
        {
            conn = new SqlConnection("data source=localhost;Initial catalog=College; User Id =personal;Integrated Security=SSPI;Persist Security Info=False;");

            DataTable _dt = new DataTable();

            var query = "select * from Student where id="+ id;

            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, conn)
            };

            adapter.Fill(_dt);

            List<Student> students = new List<Models.Student>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }
        // POST api/<controller>
        public string Post([FromBody]CreateStudent value)
        {
            conn = new SqlConnection("data source=localhost;Initial catalog=College; User Id =personal;Integrated Security=SSPI;Persist Security Info=False;");

            var query = "Insert into Student (f_name,l_name,address,birthDate,score,dep_id) values (@f_name,@l_name,@address,@birthDate,@score,@dep_id)";

            SqlCommand insertCommand = new SqlCommand(query, conn);

            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            insertCommand.Parameters.AddWithValue("@dep_id", value.dep_id);

            conn.Open();

            int result = insertCommand.ExecuteNonQuery();

            if(result > 0)
            {
                return "True";
            }
            else
            {
                return "False";
            }

        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]CreateStudent value)
        {
            conn = new SqlConnection("data source=localhost;Initial catalog=College; User Id =personal;Integrated Security=SSPI;Persist Security Info=False;");

            var query = " update Student set f_name=@f_name,l_name=@l_name,address=@address,birthDate=@birthDate,score=@score,dep_id=@dep_id where id="+id;

            SqlCommand insertCommand = new SqlCommand(query, conn);

            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            insertCommand.Parameters.AddWithValue("@dep_id", value.dep_id);

            conn.Open();

            int result = insertCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            conn = new SqlConnection("data source=localhost;Initial catalog=College; User Id =personal;Integrated Security=SSPI;Persist Security Info=False;");

            var query = " delete from Student where id=" + id;

            SqlCommand insertCommand = new SqlCommand(query, conn);

            conn.Open();

            int result = insertCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return "True";
            }
            else
            {
                return "False";
            }

        }
    }
}