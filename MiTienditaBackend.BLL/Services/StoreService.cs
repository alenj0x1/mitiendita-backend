using AutoMapper;
using MiTienditaBackend.DAL.Repository.Contract;
using MiTienditaBackend.DTO.Requests.Store;
using MiTienditaBackend.BLL.Services.Contract;
using MiTienditaBackend.BLL.Services;
using MiTienditaBackend.DTO;
using MiTienditaBackend.Entity;
using MiTienditaBackend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.BLL.Services
{
    public class StoreService : IStoreService
  {
    private readonly IGenericRepository<Store> _storeRep;
    private readonly IGenericRepository<User> _userRep;
    private readonly IMapper _mapper;
    private readonly PasswordHasher _passwordHasher = new();

    public StoreService(IGenericRepository<Store> storeRep, IGenericRepository<User> userRep, IMapper mapper)
    {
      _storeRep = storeRep;
      _userRep = userRep;
      _mapper = mapper;
    }

    public async Task<StoreDTO> CreateStore(CreateStoreRequestDTO model, bool createManager = true)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.Name == model.Name);

        if (FindStore != null)
        {
          throw new TaskCanceledException("store_name_taked");
        }

        Store NewStore = _mapper.Map<Store>(model);

        // await _storeRep.Create(NewStore);

        if (createManager)
        {
        }

        Console.WriteLine(_passwordHasher.GeneratePassword());

        return _mapper.Map<StoreDTO>(NewStore);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> DeleteStore(int storeId)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.StoreId == storeId);

        if (FindStore == null)
        {
          throw new TaskCanceledException("store_not_found");
        }

        await _storeRep.Delete(FindStore);

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

    public async Task<StoreDTO> UpdateStore(UpdateStoreRequestDTO model)
    {
      try
      {
        Store? FindStore = _storeRep.Get(store => store.StoreId == model.StoreId);

        if (FindStore == null)
        {
          throw new TaskCanceledException("store_not_found");
        }

        await _storeRep.Update(FindStore);

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
