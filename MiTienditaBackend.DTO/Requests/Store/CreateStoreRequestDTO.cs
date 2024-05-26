using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.DTO.Requests.Store
{
    public class CreateStoreRequestDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string MoneyType { get; set; }
        public int Iva { get; set; }

        public string? ImageUrl { get; set; }
    }
}
