﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.DTO.Requests
{
  public class UpdateStoreRequestDTO
  {
    public int StoreId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
  }
}