using System;
using System.Collections.Generic;
using System.Text;
using online_school.Model;
using online_school.Repo;

namespace online_school.Services
{
    public class PhotosServices
    {
        private PhotoRepo photoRepo;
        private List<Photo> photos;

        public PhotosServices()
        {
            photoRepo = new PhotoRepo();
            photos = photoRepo.getAll();
        }

        public void create(Photo photo)
        {
            if (!photos.Contains(photo))
            {
                photoRepo.create(photo);
            }
            else
            {
                throw new CourseEnroledExeception("Image already exists");
            }
        }

        public List<Photo> getAll()
        {
            if (photos.Count == 0)
                return null;
            return photos;
        }

        public Photo getById(int id)
        {
            if (id >= 1)
                return photoRepo.getById(id);
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }

        public Photo getByCourseId(int course_id)
        {
            if (course_id >= 1)
                return photoRepo.getByCourseId(course_id);
            else
            {
                throw new CourseEnroledExeception("Invalid course id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                photoRepo.deleteById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }
    }
}
