/* 
    Note: now we're not doing anyything new in the services but later, 
    here will be the code logic, restrictions and validations 
*/

using IDS_API_Project.Models;
using IDS_API_Project.Repositories;

namespace IDS_API_Project.Services;

public class DataService : IDataService
{
    private readonly IDataRepository _repo;

    // for decoupling, we will pass it as argument to the constructor
    public DataService(IDataRepository repo)
    {
        _repo = repo;
    }

    public List<DataItem> GetAll(){ 
        return _repo.GetAll(); 
    }
}
