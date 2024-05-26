using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTienditaBackend.BLL.Services.Contract;
using MiTienditaBackend.DTO.Requests.App;
using MiTienditaBackend.Utility;

namespace MiTienditaBackend.API.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class AppController : ControllerBase
  {
    private readonly IAppService _appService;

    public AppController(IAppService appService)
    {
      _appService = appService;
    }

    [HttpGet]
    public IActionResult CheckApp()
    {
      GenericResponse<bool> rsp = new();

      try
      {
        int CheckSuperAdmin = _appService.CheckSuperAdmin();

        if (CheckSuperAdmin == 0)
          throw new TaskCanceledException("without_admin");

        rsp.Result = true;
        rsp.Data = true;
        rsp.Msg = "all_good";

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Result = false;
        rsp.Msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO req)
    {
      GenericResponse<string> rsp = new();

      try
      {
        string? UserToken = _appService.Login(req);

        if (UserToken == null)
          throw new TaskCanceledException("login_failed");

        rsp.Result = true;
        rsp.Data = UserToken;
        rsp.Msg = "login_success";

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Result = false;
        rsp.Msg = ex.Message;

        return BadRequest(rsp);
      }
    }
  }
}
