using DrugPreventionSystem.BusinessLogic.Services.Interfaces;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BusinessObjects;
using Repositories.Interface.LessonRepo;

namespace DrugPreventionSystem.BusinessLogic.Services
{
    public class LessonResourceService : ILessonResourceService
    {
        private readonly ILessonResourceRepository _lessonResourceRepository;

        public LessonResourceService(ILessonResourceRepository lessonResourceRepository)
        {
            _lessonResourceRepository = lessonResourceRepository;
        }

        public List<LessonResource> GetAll()
        {
            return _lessonResourceRepository.GetAll();
        }

        public LessonResource? GetById(int id)
        {
            return _lessonResourceRepository.GetById(id);
        }

        public void Add(LessonResource resource)
        {
            _lessonResourceRepository.Add(resource);
        }

        public bool Update(LessonResource resource)
        {
            return _lessonResourceRepository.Update(resource);
        }

        public bool Delete(int id)
        {
            return _lessonResourceRepository.Delete(id);
        }

        public List<LessonResource> GetByLessonId(int lessonId)
        {
            return _lessonResourceRepository.GetByLessonId(lessonId);
        }
    }
} 