using AutoMapper;
using MiTienditaBackend.DTO.Requests.Admin;
using MiTienditaBackend.DTO.Requests.Store;
using MiTienditaBackend.DTO;
using MiTienditaBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.Utility
{
    public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile() 
    {
      #region Store
      CreateMap<StoreDTO, Store>().ReverseMap();
      CreateMap<CreateStoreRequestDTO, Store>().ReverseMap();
      #endregion

      #region Admin
      CreateMap<AdminDTO, User>().ReverseMap();
      CreateMap<CreateAdminRequesrtDTO, User>().ReverseMap();
      CreateMap<UpdateAdminRequestDTO, User>().ReverseMap();
      #endregion
    }
  }
}
