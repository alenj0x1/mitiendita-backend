using AutoMapper;
using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using MiTiendita.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.Utility
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
