using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySqlDataAcces;
using online_school.Model;

namespace online_school.Repo
{
    public class PhotoRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public PhotoRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\online-school\online-school")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Photo> getAll()
        {
            string sql = "SELECT * FROM photos";

            return db.LoadData<Photo, dynamic>(sql, new { }, connectionString);
        }

        public void create(Photo photo)
        {
            string sql = "insert into photos (id, image, course_id) values (@id, @image, @created_at)";

            db.SaveData(sql, new {photo.Id, photo.Image, photo.Course_id}, connectionString);
        }

        public Photo getById(int id)
        {
            string sql = "select * from photos where id = @id";
            if (db.LoadData<Photo, dynamic>(sql, new {id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Photo, dynamic>(sql, new {id}, connectionString)[0];
        }

        public Photo getByCourseId(int course_id)
        {
            string sql = "select * from photos where course_id = @course_id";
            if (db.LoadData<Photo, dynamic>(sql, new {course_id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Photo, dynamic>(sql, new {course_id}, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from photos where id= @id";
            db.SaveData(sql, new {id}, connectionString);
        }

        /*public void updateImage(int id, byte[] image)
        {
            string sql = "update photos set image = @image where id = @id";

            db.SaveData(sql, new {image, id}, connectionString);
        }*/
    }
}
