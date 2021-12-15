using System;
using online_school.Model;
using online_school.Repo;
using Xunit;

namespace tests_online_school
{
    public class RepoCourseTest
    {
        private CourseRepo courseRepo;

        public RepoCourseTest()
        {
            courseRepo = new CourseRepo();
        }

        [Fact]
        public void getAllTest()
        {
            int start = courseRepo.getAll().Count;
            Course course = new Course("course1", "dep1");
            courseRepo.create(course);
            Assert.Equal(start + 1, courseRepo.getAll().Count);
            courseRepo.deleteById(courseRepo.getByName("course1").Id);
        }

        [Fact]
        public void testGetName()
        {
            Assert.NotNull(courseRepo.getByName(courseRepo.getAll()[0].Name));
        }

        [Fact]
        public void testGetId()
        {
            Assert.NotNull(courseRepo.getById(courseRepo.getAll()[0].Id));
        }

        [Fact]
        public void testCreate()
        {
            Course course = new Course("course1", "dep1");
            courseRepo.create(course);
            int id = courseRepo.getAll()[courseRepo.getAll().Count - 1].Id;
            course.Id = id;
            Assert.Contains(course, courseRepo.getAll());
            courseRepo.deleteById(id);
        }

        [Fact]
        public void testUpdateName()
        {
            string name = courseRepo.getAll()[0].Name;
            courseRepo.updateNameById(courseRepo.getAll()[0].Id, "update");
            Assert.NotNull(courseRepo.getByName("update"));
            courseRepo.updateNameById(courseRepo.getAll()[0].Id, name);
        }

        [Fact]
        public void testUpdateDep()
        {
            string dep = courseRepo.getAll()[0].Department;
            courseRepo.updateDepById(courseRepo.getAll()[0].Id, "update");
            Assert.Equal("update", courseRepo.getById(courseRepo.getAll()[0].Id).Department);
            courseRepo.updateDepById(courseRepo.getAll()[0].Id, dep);
        }
    }
}
