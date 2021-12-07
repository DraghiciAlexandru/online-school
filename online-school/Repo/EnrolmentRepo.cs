using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;
using online_school.Model;

namespace online_school.Repo
{
    class EnrolmentRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public EnrolmentRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\online-school\online-school")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Enrolment> getAll()
        {
            string sql = "SELECT * FROM enrolment";

            return db.LoadData<Enrolment, dynamic>(sql, new { }, connectionString);
        }

        public void create(Enrolment enrolment)
        {
            string sql = "insert into enrolment (student_id, course_id, created_at) values (@student_id, @course_id, @created_at);";

            db.SaveData(sql, new {enrolment.Student_id, enrolment.Course_id, enrolment.Created_at}, connectionString);
        }

        public Enrolment getById(int id)
        {
            string sql = "select * from enrolment where id = @id";
            if (db.LoadData<Enrolment, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Enrolment, dynamic>(sql, new { id }, connectionString)[0];
        }

        public List<Enrolment> getByStudentId(int student_id)
        {
            string sql = "select * from enrolment where student_id = @student_id";
            if (db.LoadData<Enrolment, dynamic>(sql, new {student_id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Enrolment, dynamic>(sql, new {student_id}, connectionString);
        }

        public List<Enrolment> getByCourseId(int course_id)
        {
            string sql = "select * from enrolment where course_id = @course_id";
            if (db.LoadData<Enrolment, dynamic>(sql, new {course_id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Enrolment, dynamic>(sql, new {course_id}, connectionString);
        }

        public void deleteById(int id)
        {
            string sql = "delete from enrolment where id = @id";

            db.SaveData(sql, new {id}, connectionString);
        }

        public void updateStudentById(int id, string student_id)
        {
            string sql = "update enrolment set student_id = @sudent_id where id = @id";

            db.SaveData(sql, new {student_id, id}, connectionString);
        }
        public void updateCourseById(int id, string course_id)
        {
            string sql = "update enrolment set course_id = @course_id where id = @id";

            db.SaveData(sql, new {course_id, id}, connectionString);
        }

        public void updateCreatedById(int id, DateTime crated_at)
        {
            string sql = "update enrolment set creaed_at=@created_at where id=@id";

            db.SaveData(sql, new {crated_at, id}, connectionString);
        }
    }
}
