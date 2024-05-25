using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.Utility
{
  public class GenericResponse<T>
  {
    public bool Result { get; set; }
    public T Data { get; set; }
    public string Msg { get; set; }
  }
}
