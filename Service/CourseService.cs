using sqlwebapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlwebapp.Service
{
    public class CourseService
    {
        public List<Course> GetCourses(string conn)
        {

            List<Course> course = new List<Course>();
            //{
            //    new Course() { ID = 100, Name = "AZ-900", Rating = 4 },
            //    new Course() { ID = 101, Name = "AZ-204", Rating = 7 },
            //    new Course() { ID = 101, Name = conn, Rating = 7 }
            //};
            string _statement = "SELECT ID,Name,rating from Course";
            SqlConnection _connection = new SqlConnection(conn);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        ID = _reader.GetInt32(0),
                        Name = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    course.Add(_course);
                }
            }
            _connection.Close();

            return course;
        }
    }
}
