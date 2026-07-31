using IDS_API_Project.Models;

namespace IDS_API_Project.Services;

public interface IDataService
{
    List<DataItem> GetAll();
}
