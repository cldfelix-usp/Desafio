﻿// using ApiDesafio.Presentation.ActionFilters;
// using ApiDesafio.Presentation.ModelBinders;
// using Asp.Versioning;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.OutputCaching;
// using Microsoft.AspNetCore.RateLimiting;
// using Service.Contracts;
// using Shared.DataTransferObjects;
//
// namespace ApiDesafio.Presentation.Controllers;
//
// [Route("api/companies")]
// [ApiController]
// //[ResponseCache(CacheProfileName = "120SecondsDuration")]
// [OutputCache(PolicyName = "120SecondsDuration")]
// [ApiExplorerSettings(GroupName = "v1")]
// public class CompaniesController : ControllerBase
// {
//     private readonly IServiceManager _service;
//
//     public CompaniesController(IServiceManager service) => _service = service;
//
//     /// <summary>
//     /// Gets the list of all companies
//     /// </summary>
//     /// <returns>The companies list</returns>
//     [HttpGet(Name = "GetCompanies")]
//     [Authorize(Roles = "Manager")]
//     [EnableRateLimiting("SpecificPolicy")]
//     public async Task<IActionResult> GetCompanies()
//     {
//         var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
//
//         return Ok(companies);
//     }
//
//     [HttpGet("{id:guid}", Name = "CompanyById")]
//     //[ResponseCache(Duration = 60)]
//     [OutputCache(Duration = 60)]
//     [DisableRateLimiting]
//     public async Task<IActionResult> GetCompany(Guid id)
//     {
//         var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
//
//         var etag = $"\"{Guid.NewGuid():n}\"";
//         HttpContext.Response.Headers.ETag = etag;
//
//         return Ok(company);
//     }
//
//     [HttpGet("collection/({ids})", Name = "CompanyCollection")]
//     public async Task<IActionResult> GetCompanyCollection
//         ([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
//     {
//         var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);
//
//         return Ok(companies);
//     }
//
//     /// <summary>
//     /// Creates a newly created company
//     /// </summary>
//     /// <param name="company"></param>
//     /// <returns>A newly created company</returns>
//     /// <response code="201">Returns the newly created item</response>
//     /// <response code="400">If the item is null</response>
//     /// <response code="422">If the model is invalid</response>
//     [HttpPost(Name = "CreateCompany")]
//     [ProducesResponseType(201)]
//     [ProducesResponseType(400)]
//     [ProducesResponseType(422)]
//     [ServiceFilter(typeof(ValidationFilterAttribute))]
//     public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
//     {
//         var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);
//
//         return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
//     }
//
//     [HttpPost("collection")]
//     public async Task<IActionResult> CreateCompanyCollection
//         ([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
//     {
//         var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
//
//         return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
//     }
//
//     [HttpDelete("{id:guid}")]
//     public async Task<IActionResult> DeleteCompany(Guid id)
//     {
//         await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
//
//         return NoContent();
//     }
//
//     [HttpPut("{id:guid}")]
//     [ServiceFilter(typeof(ValidationFilterAttribute))]
//     public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
//     {
//         await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);
//
//         return NoContent();
//     }
//
//     [HttpOptions]
//     public IActionResult GetCompaniesOptions()
//     {
//         Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");
//
//         return Ok();
//     }
// }
