using System.Collections.Generic;

using Ilms.Model.Demo_T_LMS;
using Proj.Model.Entities.Mod;
namespace Ilms.Repository.Repositories.Interfaces
{
  public interface ImodRepository
  {
  	 
        Task<int> Insert_Demo_T_LMS(Demo_T_LMS TBL);
        Task<int> Delete_Demo_T_LMS(int Id);
        Task<Demo_T_LMS> GetDemo_T_LMSById(int Id);
        Task<List<Demo_T_LMS>> Search_Demo_T_LMS(Demo_T_LMS TBL);
        Task<List<Demo_T_LMS>> Getall_Demo_T_LMS(Demo_T_LMS TBL);
        Task<int> InsertOpponentData(List<BulkData> obj);
    }
}
