using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services.Contract
{
  public interface IStoreService
  {
    StoreDTO CreateStore(CreateStoreRequestDTO model);
    StoreDTO GetStore(int storeId);
    StoreDTO UpdateStore(UpdateStoreRequestDTO model);
    bool DeleteStore(int storeId);
  }
}
