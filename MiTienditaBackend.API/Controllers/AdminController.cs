using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTiendita.BLL.Services.Contract;
using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using MiTiendita.Entity;
using MiTiendita.Utility;

namespace MiTienditaBackend.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;

    public AdminController(IAdminService adminService, IMapper mapper)
    {
      _adminService = adminService;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("{adminId}")]
    public IActionResult GetAdmin(int adminId)
    {
      GenericResponse<AdminDTO> rsp = new();

      try
      {
        User? FindAdmin = _adminService.GetAdmin(adminId);

        if (FindAdmin == null)
        {
          throw new TaskCanceledException("admin_invalid_id");
        }

        rsp.Result = true;
        rsp.Data = _mapper.Map<AdminDTO>(FindAdmin);
        rsp.Msg = "admin_get_success";

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
    [Route("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminRequesrtDTO model)
    {
      GenericResponse<AdminDTO> rsp = new();

      try
      {
        AdminDTO? CreatedAdmin = await _adminService.CreateAdmin(model);

        if (CreatedAdmin == null)
        {
          throw new TaskCanceledException("admin_create_failed");
        }

        rsp.Result = true;
        rsp.Data = CreatedAdmin;
        rsp.Msg = "admin_create_success";

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Result = false;
        rsp.Msg= ex.Message;

        return BadRequest(rsp);
      }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAdmin([FromBody] UpdateAdminRequestDTO model)
    {
      GenericResponse<AdminDTO> rsp = new();

      try
      {
        AdminDTO? UpdatedAdmin = await _adminService.UpdateAdmin(model);

        if (UpdatedAdmin == null)
        {
          throw new TaskCanceledException("admin_update_failed");
        }

        rsp.Result = true;
        rsp.Data = UpdatedAdmin;
        rsp.Msg = "admin_update_success";

        return Ok(rsp);
      }
      catch (Exception ex)
      {
        rsp.Result = false;
        rsp.Msg = ex.Message;

        return BadRequest(rsp);
      }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteAdmin([FromBody] DeleteAdminRequestDTO model)
    {
      GenericResponse<bool> rsp = new();

      try
      {
        bool DeletedAdmin = await _adminService.DeleteAdmin(model);

        if (!DeletedAdmin)
        {
          throw new TaskCanceledException("admin_delete_failed");
        }

        rsp.Result = true;
        rsp.Data = DeletedAdmin;
        rsp.Msg = "admin_delete_success";

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
