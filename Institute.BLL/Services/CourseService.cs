﻿using System;
using System.Linq;
using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Dto.Course;
using Institute.BLL.Dto.Department;
using Institute.BLL.Extensions;
using Institute.BLL.Responses;
using Institute.BLL.Validations;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace Institute.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository CourseRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILoggerService<CourseService> loggerService;
        private object courseRepository;

        public CourseService(ICourseRepository CourseRepository,
                              IDepartmentRepository departmentRepository,
                              ILoggerService<CourseService> loggerService
                              )
        {
            this.CourseRepository = CourseRepository;
            this.departmentRepository = departmentRepository;
            this.loggerService = loggerService;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var course = CourseRepository.GetEntity(Id);
                result.Data = new Models.CourseModel();


            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "An error occurred getting the course";
                this.loggerService.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult GetCoursesByDeparments()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from course in CourseRepository.GetEntities()
                             join depto in this.departmentRepository.GetEntities() on course.DepartmentID equals depto.DepartmentID
                             select new Models.CourseModel()
                             {
                                 Credits = course.Credits,
                                 CourseID = course.CourseID,
                                 DepartmentId = (int)depto.DepartmentID,
                                 Title = course.Title
                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred getting the courses";
                this.loggerService.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public ServiceResult SaveCourse(CourseSaveDto saveCourseDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Course course = new Course()
                {
                    Credits = saveCourseDto.Credits,
                    Title = saveCourseDto.Title,
                    DepartmentID = saveCourseDto.DepartmentId
                };
            }
            catch (Exception ex)
            {
                result.Message = $"Error saving the course {ex.Message}";
                this.loggerService.LogError(result.Message, ex.ToString());

            }
            return result;
        }


        CourseSaveResponse ICourseService.SaveCourse(CourseSaveDto courseSaveDto)
        {
            CourseSaveResponse result = new CourseSaveResponse();

            var resultResultValid = ValidationsCourse.IsValidCourse(courseSaveDto);

            try
            {
                if (resultResultValid.Success)
                {

                    DAL.Entities.Course courseToAdd = courseSaveDto.FromCrsSaveToEntity();

                    CourseRepository.Save(courseToAdd);
                    result.CourseID = courseToAdd.CourseID;

                    result.Message = "Course saved successfully";

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                loggerService.LogError(ex.Message, ex.ToString());
            }

            return result;
        }

        public CourseUpdateResponse UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult RemoveCourse(CourseRemoveDto courseRemoveDto)
        {
            throw new NotImplementedException();
        }
    }
}