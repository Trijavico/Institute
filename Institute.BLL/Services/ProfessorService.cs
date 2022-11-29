using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Extensions;
using Institute.BLL.Responses;
using Institute.BLL.Validations;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.BLL.Services
{
    public class ProfessorService : IProfessorService
    {

        private readonly IProfessorRepository professorRepository;
        private readonly ILogger<ProfessorService> logger;

        public ProfessorService(IProfessorRepository professorRepository,
                              ILogger<ProfessorService> logger)
        {
            this.professorRepository = professorRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professors = this.professorRepository.GetEntities();

                result.Data = professors.Select(item => new Models.ProfessorModel()
                {
                    Id = item.Id,
                    HireDate = (DateTime)item.HireDate,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los profesores";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professor = this.professorRepository.GetEntity(Id);

                result.Data = new Models.ProfessorModel()
                {
                    Id = professor.Id,
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    HireDate = professor.HireDate.Value
                };

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo el profesor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }


        public ServiceResult RemoveProfessor(ProfessorRemoveDto professorRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professorToRemove = this.professorRepository.GetEntity(professorRemoveDto.Id);

                professorToRemove.Id = professorRemoveDto.Id;

                professorRepository.Remove(professorToRemove);

                result.Message = "Estudiante eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ProfessorSaveResponse SaveProfessor(ProfessorSaveDto professorSaveDto)
        {
            ProfessorSaveResponse result = new ProfessorSaveResponse();

            result = (ProfessorSaveResponse) ValidationsProfessor.IsValidProfessor(professorSaveDto, professorRepository);

            if (result.Success)
            {
                DAL.Entities.Professor professorToAdd = professorSaveDto.FromDtoSaveToEntity();

                result.ProfessorId = professorToAdd.Id;
                professorRepository.Save(professorToAdd);

                result.Message = "Profesor agregado correctamente";

            }
            return result;
        }



        public ProfessorUpdateResponse UpdateProfessor(ProfessorUpdateDto professorUpdateDto)
        {
            ProfessorUpdateResponse result = new ProfessorUpdateResponse();

            result = (ProfessorUpdateResponse)ValidationsProfessor.IsValidProfessor(professorUpdateDto, this.professorRepository);

            try
            {
                DAL.Entities.Professor professorToUpdate = professorUpdateDto.FromDtoUpdateToEntity();

                professorRepository.Update(professorToUpdate);

                result.Message = "Estudiante actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el estudiante";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}
