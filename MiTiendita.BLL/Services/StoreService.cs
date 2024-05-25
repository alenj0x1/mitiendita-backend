using AutoMapper;
using MiTiendaBackend.DAL.Repository.Contract;
using MiTiendita.BLL.Services.Contract;
using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using MiTiendita.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services
{
  public class StoreService : IStoreService
  {
    private readonly IGenericRepository<Store> _storeRep;
    private readonly IMapper _mapper;

    public StoreService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public StoreDTO CreateStore(CreateStoreRequestDTO model)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.Name == model.Name);

        if (FindStore != null)
        {
          throw new TaskCanceledException("store_name_taked");
        }

        Store? NewStore = _storeRep.Create(_mapper.Map<Store>(model));

        return _mapper.Map<StoreDTO>(NewStore);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool DeleteStore(int storeId)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.StoreId == storeId);

        if (FindStore == null)
        {
          throw new TaskCanceledException("store_not_found");
        }

        _storeRep.Delete(FindStore);

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public StoreDTO GetStore(int storeId)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.StoreId == storeId);
        
        if (FindStore == null)
        {
          throw new TaskCanceledException("store_not_found");
        }

        return _mapper.Map<StoreDTO>(FindStore);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public StoreDTO UpdateStore(UpdateStoreRequestDTO model)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.StoreId == model.StoreId);

        if (FindStore == null)
        {
          throw new TaskCanceledException("store_not_found");
        }

        _storeRep.Update(FindStore);

        StoreDTO UpdatedStore = GetStore(model.StoreId);

        return UpdatedStore;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
