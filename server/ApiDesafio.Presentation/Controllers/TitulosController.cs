using ApiDesafio.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ApiDesafio.Presentation.Controllers;

[Route("api/titulos")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
// [ServiceFilter(typeof(ValidationFilterAttribute))]
public class TitulosController : ControllerBase
{
    private readonly IServiceManager _service;

    public TitulosController(IServiceManager service) => _service = service;
    
    
    [HttpGet(Name = "getTitulosAsync")]
    public async Task<IActionResult> GetTitulosAsync()
    {
        var titulos = await _service.TituloService.GetTitulosAsync();
        return Ok(titulos);
    }
    
    [HttpPost(Name = "criarTituloAsync")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CriarTituloAsync([FromBody] TituloForCreateionDto titulo)
    {
        var tituloResponse =  await _service.TituloService.GetTituloAsync(titulo.NumeroTitulo);
        
        if (tituloResponse is not null)
        {
            foreach (var parcelaForCreateionDto in titulo.ParcelasEmAtraso)
            {
                await _service.ParcelaService.CriarParcelaAsync(parcelaForCreateionDto, tituloResponse);
                return CreatedAtRoute("criarTituloAsync", new { id = tituloResponse.Id }, tituloResponse);
            }
            return CreatedAtRoute("criarTituloAsync", new { id = tituloResponse.Id }, tituloResponse.Id);
        }
        
        var createdTitulo = await _service.TituloService.CriarTituloAsync(titulo);
        return CreatedAtRoute("criarTituloAsync", new { id = createdTitulo.Id }, createdTitulo);

    
    }



}