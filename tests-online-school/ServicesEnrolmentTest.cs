using System;
using online_school;
using online_school.Model;
using online_school.Services;
using Xunit;

namespace tests_online_school
{
    public class ServicesEnrolmentTest
    {
        private EnrolmentServices enrolmentServices;

        public ServicesEnrolmentTest()
        {
            enrolmentServices = new EnrolmentServices();
        }

        [Fact]
        public void createException()
        {
            Enrolment enrolment = new Enrolment(302, 1, DateTime.Now);

            Assert.Equal("Youre already enrolled",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.create(enrolment)).Message);
        }

        [Fact]
        public void createEx2()
        {
            Enrolment enrolment = enrolmentServices.getAll()[0];

            Assert.Equal("Youre already enrolled",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.create(enrolment)).Message);
        }

        [Fact]
        public void getById()
        {
            Assert.Equal("Invalid id",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.getById(-1)).Message);
        }

        [Fact]
        public void getById2()
        {
            Assert.Null(enrolmentServices.getById(1));
        }

        [Fact]
        public void deleteByDetails()
        {
            Enrolment enrolment = new Enrolment(0, 0, DateTime.Now);

            Assert.Equal("Invalid enrolment",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.deletebyDetails(enrolment)).Message);
        }

        [Fact]
        public void deleteByDetails2()
        {
            Enrolment enrolment = new Enrolment(1, 1, 1, DateTime.Now);


            Assert.Equal("Student is not enrolled in this course",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.deletebyDetails(enrolment)).Message);
        }

        [Fact]
        public void getByStudent()
        {
            Assert.Equal("Invalid student id",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.getByStudent(0)).Message);
        }

        [Fact]
        public void getbyStudent2()
        {
            Assert.Null(enrolmentServices.getByStudent(1));
        }

        [Fact]
        public void getByCourse()
        {
            Assert.Equal("Invalid course id",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.getByCourse(0)).Message);
        }

        [Fact]
        public void getByCourse2()
        {
            Assert.Null(enrolmentServices.getByCourse(2));
        }

        [Fact]
        public void deleteById()
        {
            Assert.Equal("Invalid id",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.deleteById(-1)).Message);
        }

        [Fact]
        public void updateStudentById()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.updateStudentById(1, -1)).Message);
        }

        [Fact]
        public void updateCourseById()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.updateCourseById(1, -1)).Message);
        }

        [Fact]
        public void updateCreatedById()
        {
            Assert.Equal("Invalid data",
                Assert.Throws<CourseEnroledExeception>(() => enrolmentServices.updateCreatedById(1, new DateTime())).Message);
        }
    }
}
