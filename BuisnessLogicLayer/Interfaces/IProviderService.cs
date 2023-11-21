using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IProviderService
    {
        public IEnumerable<ProviderDTO> GetProviders();
    }
}
