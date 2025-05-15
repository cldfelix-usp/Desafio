using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class TituloService : ITituloService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public TituloService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        
    }

    public async Task<TituloDto> CriarTituloAsync(TituloForCreateionDto titulo)
    {
        var tituloEntity = _mapper.Map<Titulo>(titulo);
        _repository.Titulo.CreateTitulo(tituloEntity);
        await _repository.SaveAsync();
        var tituloToReturn = _mapper.Map<TituloDto>(tituloEntity);
        return tituloToReturn;
    }

    public async Task<IEnumerable<TituloResumoDto>> GetTitulosAsync()
    {
       var titulos = await _repository.Titulo.GetAllTitulosAsync();
       var mapped = _mapper.Map<IEnumerable<TituloResumoDto>>(titulos);
       foreach (var tituloResumoDto in mapped)
       {
           tituloResumoDto.SetSumario();
       }
       return mapped;   
    }

    public async Task<TituloResponseDto?> GetTituloAsync(string tituloNumeroTitulo)
    {
        var res = await _repository.Titulo.GetTituloAsync(tituloNumeroTitulo);
        var mapped = _mapper.Map<TituloResponseDto>(res);
        return mapped;
        
    }
}