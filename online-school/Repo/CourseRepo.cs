﻿using Microsoft.Extensions.Configuration;
using MySqlDataAcces;
using System.Collections.Generic;
using System;
using System.Text;
using online_school.Model;

namespace online_school.Repo
{
    public class CourseRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public CourseRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\online-school\online-school")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Course> getAll()
        {
            string sql = "SELECT * FROM course";

            return db.LoadData<Course, dynamic>(sql, new { }, connectionString);
        }

        public void create(Course course)
        {
            string sql = "insert into course (name, department) values (@name, @department);";

            db.SaveData(sql, new {course.Name, course.Department}, connectionString);
        }

        public Course getByName(string name)
        {
            string sql = "select * from course where name = @name";

            if (db.LoadData<Course, dynamic>(sql, new { name }, connectionString).Count == 0)
                return null;
            return db.LoadData<Course, dynamic>(sql, new { name }, connectionString)[0];
        }

        public Course getById(int id)
        {
            string sql = "select * from course where id = @id";
            if (db.LoadData<Course, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Course, dynamic>(sql, new { id }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from course where id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateNameById(int id, string name)
        {
            string sql = "update course set name = @name where id = @id";

            db.SaveData(sql, new {name, id}, connectionString);
        }

        public void updateDepById(int id, int department)
        {
            string sql = "update course set department=@department where id=@id";

            db.SaveData(sql, new { department, id }, connectionString);
        }
    }
}
