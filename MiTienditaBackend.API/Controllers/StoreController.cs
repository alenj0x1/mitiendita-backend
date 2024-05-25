using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTiendita.DTO.Requests;

namespace MiTienditaBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    [HttpGet]
    [Route("{storeId}")]
    public ActionResult GetStore(int storeId)
    {
      return Ok();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult CreateStore([FromBody] CreateStoreRequestDTO model)
    {
      return Ok();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult CreateStore([FromBody] UpdateStoreRequestDTO model)
    {
      return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    public ActionResult DeleteStore([FromBody] string model)
    {
      return Ok();
    }
  }
}
