using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto.Professor;
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
                }).OrderByDescending(item => item.HireDate).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the professors";
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
                result.Message = "Error getting the professor";
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

                result.Message = "Professor removed successfully";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removin the professor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ProfessorSaveResponse SaveProfessor(ProfessorSaveDto professorSaveDto)
        {
            ProfessorSaveResponse result = new ProfessorSaveResponse();

            var resultResultValid = ValidationsProfessor.IsValidProfessor(professorSaveDto, professorRepository);

            try
            {
                if (resultResultValid.Success)
                {

                    DAL.Entities.Professor professorToAdd = professorSaveDto.FromDtoSaveToEntity();

                    professorRepository.Save(professorToAdd);
                    result.ProfessorId = professorToAdd.Id;

                    result.Message = "Professor added successfully";

                }
                return result;
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Error adding the professor";
                logger.LogError(ex.Message,ex.ToString());
            }

            return result;
          
        }



        public ProfessorUpdateResponse UpdateProfessor(ProfessorUpdateDto professorUpdateDto)
        {
            ProfessorUpdateResponse result = new ProfessorUpdateResponse();

            var resultValid = ValidationsProfessor.IsValidProfessor(professorUpdateDto, professorRepository);

            try
            {
                if(resultValid.Success)
                {
                    DAL.Entities.Professor professorToUpdate = professorUpdateDto.FromDtoUpdateToEntity();

                    professorRepository.Update(professorToUpdate);

                    result.Message = "Professor updated successfully";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the professor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }
    }
}
