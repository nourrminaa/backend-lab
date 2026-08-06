/* This is the blueprint for the DataRespository class. */

using IDS_API_Project.Models;

namespace IDS_API_Project.Repositories;

public interface IDataRepository
{
    List<DataItem> GetAll();
}
