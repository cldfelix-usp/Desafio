using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class ParcelaService : IParcelaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public ParcelaService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        
    }

    public async Task CriarParcelaAsync(ParcelaForCreateionDto parcela, TituloResponseDto? titulo = null)
    {
        var parcelaEntity = _mapper.Map<Parcela>(parcela);
        if(titulo != null)
            parcelaEntity.TituloId = (Guid)titulo.Id;

        _repository.Parcela.CreateParcela(parcelaEntity);
        await _repository.SaveAsync();
    }
}