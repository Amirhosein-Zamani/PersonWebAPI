using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Application.DTO.Voucher;
using PersonWebAPI.Application.Services.Intrfaces;


[Route("api/[controller]")]
[ApiController]
public class VouchersController(IVoucherService voucherService) : ControllerBase
{

    #region GetByPersonId

    [HttpGet("by-person")]
    public async Task<IActionResult> GetVouchersByPersonIdAsync([FromQuery] List<int> personIds,  DateTime? fromDate, DateTime? toDate)
    {
        var voucher = await voucherService.GetVoucherByPersonIdAsync(personIds, fromDate, toDate);

        if (voucher.IsSucces)
        {
            return Ok(voucher);
        }
        else
        {
            return NotFound(voucher.Error);
        }
    }

    #endregion GetByPersonId


    #region GetByGroupId

    [HttpGet("by-group")]
    public async Task<IActionResult> GetVoucherByGroupIdAsync(
      [FromQuery] List<int> groupIds,
      [FromQuery] DateTime? fromDate,
      [FromQuery] DateTime? toDate)
    {
        var voucher = await voucherService.GetVoucherByGroupIdAsync(groupIds, fromDate, toDate);

        if (voucher.IsSucces)
        {
            return Ok(voucher);
        }


        return NotFound(voucher.Error);


    }

    #endregion GetByGroupId


    #region Create

    [HttpPost]
    public async Task<IActionResult> AddVoucherAsync([FromBody] CreateVoucherDto CreateVoucherDto)
    {

        if (!ModelState.IsValid)
        {

            return BadRequest(ModelState);
        }

        var result = await voucherService.CreateVoucherAsync(CreateVoucherDto);

        if (!result.IsSucces)
        {
            return BadRequest(result.Error);
        }

        return Ok("ووچر با موفقیت اضافه شد");


    }

    #endregion Create


    #region Edit

    [HttpPut("id")]
    public async Task<IActionResult> EditVoucherAsync(int id, EditVoucherDto editVoucherDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await voucherService.EditVoucherAsync(id, editVoucherDto);

        if (!result.IsSucces)
        {
            return BadRequest(result.Error);
        }

        return Ok(result);
    }

    #endregion Edit



    #region Delete

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVoucher(int id)
    {
        var result = await voucherService.DeleteVoucherAsync(id);

        if (!result.IsSucces)
        {
            return BadRequest(result.Error);
        }

        return Ok(result);
    }

    #endregion Delete
}

