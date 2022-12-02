using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto.Department;
using Institute.BLL.Dto.Professor;
using Institute.BLL.Extensions;
using Institute.BLL.Responses;
using Institute.BLL.Validations;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<DepartmentService> logger;

        public DepartmentService(IDepartmentRepository deparmentRepository,
                              ILogger<DepartmentService> logger)
        {
            this.departmentRepository = deparmentRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var departments = this.departmentRepository.GetEntities();

                result.Data = departments.Select(item => new Models.DepartmentModel()
                {
                    Id = item.DepartmentID,
                    Name = item.Name,
                    StartDate = item.StartDate,
                    Budget = item.Budget,
                    Administrator = item.Administrator,
                }).OrderByDescending(item => item.StartDate).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the departments";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var department = this.departmentRepository.GetEntity(Id);

                result.Data = new Models.DepartmentModel()
                {
                    Id = department.DepartmentID,
                    Name = department.Name,
                    Budget = department.Budget,
                    StartDate = department.StartDate,
                    Administrator = department.Administrator
                };

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error getting the department";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveDepartment(DepartmentRemoveDto departmentRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professorToRemove = this.departmentRepository.GetEntity(departmentRemoveDto.DepartmentID);

                professorToRemove.DepartmentID = departmentRemoveDto.DepartmentID;

                departmentRepository.Remove(professorToRemove);

                result.Message = "Department successfully removed";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error deleting department";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public DepartmentSaveResponse SaveDepartment(DepartmentSaveDto departmentSaveDto)
        {
            DepartmentSaveResponse result = new DepartmentSaveResponse();

            var resultResultValid = ValidationsDepartment.IsValidDepartment(departmentSaveDto, departmentRepository);

            try
            {
                if (resultResultValid.Success)
                {

                    DAL.Entities.Department departmentToAdd = departmentSaveDto.FromDtoSaveToEntity();

                    departmentRepository.Save(departmentToAdd);
                    result.DepartmentID = departmentToAdd.DepartmentID;

                    result.Message = "Department saved successfully";

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                logger.LogError(ex.Message, ex.ToString());
            }

            return result;
        }

        public DepartmentUpdateResponse UpdateDepartment(DepartmentUpdateDto departmentUpdateDto)
        {
            DepartmentUpdateResponse result = new DepartmentUpdateResponse();

            var resultValid = ValidationsDepartment.IsValidDepartment(departmentUpdateDto, departmentRepository);

            try
            {
                if (resultValid.Success)
                {
                    DAL.Entities.Department departmentToUpdate = departmentUpdateDto.FromDtoUpdateToEntity();

                    departmentRepository.Update(departmentToUpdate);

                    result.Message = "Department updated successfully";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the deparment";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }
    }
}
