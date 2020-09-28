using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorSol.Contracts;
using ErrorSol.Entities.Models;
using ErrorSol.Entities.ReturnFormat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorSol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryManager _dbManager;

        public CompanyController(IRepositoryManager dbManager)
        {
            _dbManager = dbManager;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            List<Exception> errors = new List<Exception>();
            List<Company> responseData = new List<Company>();


            var companies = await _dbManager.Company.GetAllCompaniesAsync(trackChanges: false);


            //return Ok(ecoApplicationsDto);
            return Ok(new Response<Company>
            {
                Errors = null,
                Result = new Result<Company>
                {
                    Message = "Company successfully gotten.",
                    Data = companies
                }
            });
        }


        //Get Company by Id
        [HttpGet("{Id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompanyById(Guid Id)
        {
            List<Exception> errors = new List<Exception>();
            List<Company> responseData = new List<Company>();


            var company = await _dbManager.Company.GetCompanyAsync(Id, trackchanges: false);
            if (company == null)
            {
                Exception exception = new Exception($"Company with ID: {Id} doesn't exist in the database.");
                errors.Add(exception);
                return NotFound(new Response<Company>
                {
                    Errors = errors,
                    Result = null
                });
            }
            else
            {
                responseData.Add(company);
                return Ok(new Response<Company>
                {
                    Errors = null,
                    Result = new Result<Company>
                    {
                        Message = "Company successfully gotten.",
                        Data = responseData
                    }
                });
            }
        }


        //Create new Company
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            List<Exception> errors = new List<Exception>();
            List<Company> responseData = new List<Company>();

            if (company == null)
            {
                Exception exception = new Exception("");
                errors.Add(exception);
                return BadRequest(new Response<Company>
                {
                    Errors = errors,
                    Result = null
                });
            }


            _dbManager.Company.CreateCompany(company);
            await _dbManager.SaveAsync();

            responseData.Add(company);
            return CreatedAtRoute("CompanyById", new { Id = company.Id }, (new Response<Company>
            {
                Errors = null,
                Result = new Result<Company>
                {
                    Message = "Company successfully created",
                    Data = responseData
                }
            }));
        }
    }
}
