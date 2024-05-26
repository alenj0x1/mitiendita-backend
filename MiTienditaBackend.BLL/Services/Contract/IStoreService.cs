using MiTienditaBackend.DTO.Requests.Store;
using MiTienditaBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.BLL.Services.Contract
{
    public interface IStoreService
  {
    Task<StoreDTO> CreateStore(CreateStoreRequestDTO model, bool createManager = true);
    StoreDTO GetStore(int storeId);
    Task<StoreDTO> UpdateStore(UpdateStoreRequestDTO model);
    Task<bool> DeleteStore(int storeId);
  }
}
