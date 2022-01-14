using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;
using online_school.Model;

namespace online_school.Repo
{
    public class ProfessorRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public ProfessorRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\online-school\online-school")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public void create(Professor professor)
        {
            string sql = "insert into professor (id, image, description, name) values (@id, @image, @description, @name)";

            db.SaveData(sql, new {professor.Id, professor.Image, professor.Description, professor.Name},
                connectionString);
        }

        public List<Professor> getAll()
        {
            string sql = "SELECT * FROM professor";

            return db.LoadData<Professor, dynamic>(sql, new { }, connectionString);
        }

        public Professor getById(int id)
        {
            string sql = "select * from professor where id = @id";
            if (db.LoadData<Professor, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<Professor, dynamic>(sql, new { id }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from professor where id = @id";
            db.SaveData(sql, new { id }, connectionString);
        }
    }
}
