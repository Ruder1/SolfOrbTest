using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BuisnessLogicLayer.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _database;

        private readonly IMapper _mapper;

        public ProviderService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public IEnumerable<ProviderDTO> GetProviders()
        {
            var providersDal = _database.Providers.GetAll();
            var providersDTO = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDTO>>(providersDal);
            return providersDTO;
        }
    }
}
