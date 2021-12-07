using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;
using online_school.Model;

namespace online_school.Repo
{
    class StudentRepo
    {
        private readonly string connectionString;

        private DataAcces db;
        
        public StudentRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\online-school\online-school")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Student> getAll()
        {
            string sql = "SELECT * FROM student";

            return db.LoadData<Student, dynamic>(sql, new { }, connectionString);
        }

        public void create(Student student)
        {
            string sql = "insert into student (first_name, last_name, email, age) values (@first_name, @last_name, @email, @age);";

            db.SaveData(sql, new {student.First_name, student.Last_name, student.Email, student.Age}, connectionString);
        }

        public Student getByName(string last_name, string first_name)
        {
            string sql = "select * from student where name like '*@last_name*@first_name*'";

            if (db.LoadData<Student, dynamic>(sql, new {last_name = last_name, first_name = first_name},
                connectionString).Count == 0) 
                return null;
            return db.LoadData<Student, dynamic>(sql, new {last_name = last_name, first_name = first_name},
                connectionString)[0];
        }

        public Student getById(int id)
        {
            string sql = "select * from student where id = @id";
            if (db.LoadData<Student, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Student, dynamic>(sql, new { id }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from student where id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateFirst_NameById(int id, string first_name)
        {
            string sql = "update student set first_name = @first_name where id = @id";

            db.SaveData(sql, new {first_name, id}, connectionString);
        }
        public void updateLast_NameById(int id, string last_name)
        {
            string sql = "update student set last_name = @last_name where id = @id";

            db.SaveData(sql, new {last_name, id}, connectionString);
        }

        public void updateEmailById(int id, string email)
        {
            string sql = "update student set email=@email where id=@id";

            db.SaveData(sql, new {email, id}, connectionString);
        }

        public void updateAgeById(int id, int age)
        {
            string sql = "update student set age=@age where id=@id";

            db.SaveData(sql, new {age, id}, connectionString);
        }
    }
}
