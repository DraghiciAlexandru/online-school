using System;
using online_school;
using online_school.Model;
using online_school.Services;
using Xunit;

namespace tests_online_school
{
    public class ServicesCourseTest
    {
        private CourseServices courseServices;

        public ServicesCourseTest()
        {
            courseServices = new CourseServices();
        }

        [Fact]
        public void create()
        {
            Assert.Equal("Course exists",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.create(new Course("WW1", "dep"))).Message);
        }

        [Fact]
        public void getByName1()
        {
            Assert.Equal("Invalid course id",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.getByName(" ")).Message);
        }

        [Fact]
        public void getByName2()
        {
            Assert.Equal("Course does not exists",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.getByName("course0")).Message);
        }

        [Fact]
        public void getById()
        {
            Assert.Equal("Invalid course id",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.getById(0)).Message);
        }

        [Fact]
        public void deleteById()
        {
            Assert.Equal("Invalid course id",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.deleteById(0)).Message);
        }

        [Fact]
        public void deleteByName()
        {
            Assert.Equal("Invalid name",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.deleteByName("")).Message);
        }

        [Fact]
        public void updateName()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.updateNameById(1, "")).Message);
        }

        [Fact]
        public void updateDep()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => courseServices.updateDepById(1, "")).Message);
        }
    }
}
