using SharedLibrary;

namespace WASM.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
    }
}
