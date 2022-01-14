using System;
using System.Collections.Generic;
using System.Text;
using online_school.Model;
using online_school.Repo;

namespace online_school.Services
{
    public class ProfessorServices
    {
        private ProfessorRepo professorRepo;
        private List<Professor> professors;

        public ProfessorServices()
        {
            professorRepo = new ProfessorRepo();
            professors = professorRepo.getAll();
        }
        
        public void create(Professor professor)
        {
            if (!professors.Contains(professor))
            {
                professorRepo.create(professor);
            }
            else
            {
                throw new CourseEnroledExeception("Professor already exists");
            }
        }

        public List<Professor> getAll()
        {
            if (professors.Count == 0)
                return null;
            return professors;
        }

        public Professor getById(int id)
        {
            if (id >= 1)
                return professorRepo.getById(id);
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                professorRepo.deleteById(id);
            }
            else
            {
                throw new CourseEnroledExeception("Invalid id");
            }
        }
    }
}
