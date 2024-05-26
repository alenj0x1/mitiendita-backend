using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.DTO.Requests.App
{
    public class LoginRequestDTO
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
