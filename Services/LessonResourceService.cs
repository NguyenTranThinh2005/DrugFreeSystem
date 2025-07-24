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

        public LessonResource? GetById(Guid id)
        {
            return _lessonResourceRepository.GetById(id);
        }

        public void Add(LessonResource resource)
        {
            resource.ResourceId = Guid.NewGuid();
            _lessonResourceRepository.Add(resource);
        }

        public bool Update(LessonResource resource)
        {
            return _lessonResourceRepository.Update(resource);
        }

        public bool Delete(Guid id)
        {
            return _lessonResourceRepository.Delete(id);
        }

        public List<LessonResource> GetByLessonId(Guid lessonId)
        {
            return _lessonResourceRepository.GetByLessonId(lessonId);
        }
    }
} 