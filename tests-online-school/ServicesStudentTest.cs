using System;
using online_school;
using online_school.Model;
using online_school.Services;
using Xunit;

namespace tests_online_school
{
    public class ServicesStudentTest
    {
        private StudentServices studentServices;

        public ServicesStudentTest()
        {
            studentServices = new StudentServices();
        }

        [Fact]
        public void create()
        {
            Student student = new Student("Alex", "Draghici", "alexdraghici2104@gmail.com", 0);

            Assert.Equal("Student already exists",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.create(student)).Message);
        }

        [Fact]
        public void getAll()
        {
            Assert.NotNull(studentServices.getAll());
        }

        [Fact]
        public void getByName()
        {
            Assert.Equal("Student does not exist",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.getByName("nume1", "nume2")).Message);
        }

        [Fact]
        public void getById()
        {
            Assert.Equal("Invalid student id 2",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.getById(0)).Message);
        }

        [Fact]
        public void deleteById()
        {
            Assert.Equal("Invalid student id 3",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.deleteById(0)).Message);
        }

        [Fact]
        public void deleteByName1()
        {
            Assert.Equal("Invalid name",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.deleteByName("", "")).Message);
        }

        [Fact]
        public void deleteByName2()
        {
            Assert.Equal("Name does not exist",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.deleteByName("name1", "name2")).Message);
        }

        [Fact]
        public void updateFirstName()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.updateFirst_NameById(1, " ")).Message);
        }

        [Fact]
        public void updateFastName()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.updateLast_NameById(0, " ")).Message);
        }

        [Fact]
        public void updateEmailById1()
        {
            Assert.Equal("Invalid email",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.updateEmailById(1, "email")).Message);
        }

        [Fact]
        public void updateEmailById2()
        {
            Assert.Equal("Invalid email",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.updateEmailById(0, "email@gmail.com")).Message);
        }

        [Fact]
        public void updateEmailById3()
        {
            Assert.Equal("Invalid email",
                Assert.Throws<CourseEnroledExeception>(() =>
                    studentServices.updateEmailById(302, "alexdraghici2104@gmail.com")).Message);
        }

        [Fact]
        public void updateAge()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => studentServices.updateAgeById(1, 0)).Message);
        }
    }
}
