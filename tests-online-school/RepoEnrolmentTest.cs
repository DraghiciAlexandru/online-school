using System;
using online_school.Model;
using online_school.Repo;
using Xunit;

namespace tests_online_school
{
    public class RepoEnrolmentTest
    {
        private EnrolmentRepo enrolmentRepo;

        public RepoEnrolmentTest()
        {
            enrolmentRepo = new EnrolmentRepo();
        }

        [Fact]
        public void getAllTest()
        {
            int x = enrolmentRepo.getAll().Count;
            
        }
    }
}
