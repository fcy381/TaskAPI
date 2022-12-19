using AutoMapper;
using JobAPI.Entities;
using JobAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using JobAPI.Entities;
using JobAPI.Repository;

namespace JobAPI.Services   
{
    public static class JobService
    {
        public static void ConfigureJobService(this WebApplication app)
        {            
            app.MapGet("/api/job", GetAllJobsAsync);

            app.MapGet("/api/job/{id:Guid}", GetJobAsync); 

            app.MapPost("/api/job", CreateJobAsync);

            app.MapPut("/api/job/{id:Guid}", UpdateJobAsync);

            app.MapDelete("/api/job/{id:Guid}", DeleteJobAsync); 
        }

        private async static Task<IResult> GetAllJobsAsync(JobRepository _jobRepository,
                                                           Mapper _mapper)
        {
            Console.WriteLine("Endpoint 'GetAllJobsAsync' is executed.");

            List<Job> jobs = await _jobRepository.GetAllAsync();

            APIResponse response = new APIResponse();

            response.Result = _mapper.Map<List<JobGetDTO>>(jobs);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            
            return Results.Ok(response);
        }

        private async static Task<IResult> GetJobAsync(Guid id, 
                                                       JobRepository _jobRepository,
                                                       Mapper _mapper)
        {
            Console.WriteLine("Endpoint 'GetJobsAsync' is executed.");

            Job job = await _jobRepository.GetAsync(id);

            APIResponse response = new APIResponse(); 

            if (job != null)
            {
                response.Result = _mapper.Map<JobGetDTO>(job);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Results.Ok(response);
            }
            else
            {
                response.Result = null;
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessages.Add("Invalid Id");

                return Results.NotFound(response);
            }
        }

        private async static Task<IResult> CreateJobAsync([FromBody] JobCreateDTO jobCreateDTO, 
                                                           JobRepository _jobRepository,
                                                           Mapper _mapper)
        {
            Console.WriteLine("Endpoint 'CreateJobsAsync' is executed.");

            Job job = new Job();

            job = _mapper.Map<Job>(jobCreateDTO);

            job.Creation = DateTime.Now.ToString();
            job.Update = DateTime.Now.ToString();

            await _jobRepository.CreateAsync(job);

            JobGetDTO jobGetDTO = _mapper.Map<JobGetDTO>(job);

            APIResponse response = new APIResponse();

            response.Result = jobGetDTO;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;

            return Results.Ok(response);
            //return Results.CreatedAtRoute("GetJobAsync", new { id = job.Id }, job);
        }

        private async static Task<IResult> UpdateJobAsync(Guid id,
                                                          [FromBody] JobUpdateDTO jobUpdateDTO,
                                                          JobRepository _jobRepository,
                                                          Mapper _mapper)
        {
            Console.WriteLine("Endpoint 'UpdateJobsAsync' is executed.");

            Job job = await _jobRepository.GetAsync(id);

            APIResponse response = new APIResponse();

            if (job != null)
            {
                job = _mapper.Map<Job>(jobUpdateDTO);
                await _jobRepository.UpdateAsync(id, job);

                response.Result = _mapper.Map<JobGetDTO>(job);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Results.Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Invalid Id"); 

                return Results.BadRequest(response);
            }

            await _jobRepository.UpdateAsync(id,_mapper.Map<Job>(jobUpdateDTO));

            return Results.Ok();
        }

        private async static Task<IResult> DeleteJobAsync(Guid id, JobRepository _jobRepository)
        {
            Console.WriteLine("Endpoint 'DeleteJobsAsync' is executed.");

            Job job = await _jobRepository.GetAsync(id);

            APIResponse response = new APIResponse();

            if (job != null)
            {
                await _jobRepository.RemoveAsync(id);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Results.Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add("Invalid Id");

                return Results.BadRequest(response);
            }
        }

    }
}
