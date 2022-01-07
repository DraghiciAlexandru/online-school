using System;
using online_school.Model;
using online_school.Repo;
using Xunit;

namespace tests_online_school
{
    public class RepoStudentTest
    {
        private StudentRepo studentRepo;

        public RepoStudentTest()
        {
            studentRepo = new StudentRepo();
        }

        [Fact]
        public void getAllTest()
        {
            // adaugam 100 de sgtudenti 
            int x = studentRepo.getAll().Count;

            for (int i = x; i < 100; i++)
            {
                studentRepo.create(new Student(i.ToString(), i.ToString(), "e", 1, "non"));
            }

            Assert.Equal(100, studentRepo.getAll().Count);
            
            for (int i = x; i <= 100; i++)
            {
                studentRepo.deleteByName(i.ToString(), i.ToString());
            }
        }

    }
}
