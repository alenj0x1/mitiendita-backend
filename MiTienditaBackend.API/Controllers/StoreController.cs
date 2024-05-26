using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTienditaBackend.DTO.Requests.Store;
using MiTienditaBackend.BLL.Services.Contract;

namespace MiTienditaBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
      _storeService = storeService;
    }

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
      _storeService.CreateStore(model);

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
