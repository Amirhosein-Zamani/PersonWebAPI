using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Application.DTO.Person;
using PersonWebAPI.Application.Services.Implementation;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Application.Validator;
using PersonWebAPI.Infra.Data.Context;

namespace PersonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController(IPersonService personService) : ControllerBase
    {

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync()
        {
            var result = await personService.GetAllPersonAsync();

            if (!result.IsSucces)
                return NotFound(result.Error);

            return Ok(result);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var result = await personService.GetPersonByIdAsync(id);

            if (!result.IsSucces)
            {
                return NotFound(result.Error);
            }

            return Ok(result);
        }

        #endregion Get


        #region Create

        [HttpPost]
        public async Task<IActionResult> AddPersonAsync([FromBody] CreatePersonDto createPersonDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await personService.AddPersonAsync(createPersonDto);

            if (!result.IsSucces)
            {
                return BadRequest(result.Error);
            }

            return Ok("کاربر با موفقیت اضافه شد");

        }

        #endregion Create


        #region Update


        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(int id, [FromBody] EditPersonDto dto, [FromServices] IValidator<EditPersonDto> validator)
        {
            var result = await validator.ValidateAsync(dto);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var serviceResult = await personService.EditPersonAsync(id, dto);

            if (!serviceResult.IsSucces)
                return BadRequest(serviceResult.Error);

            return Ok("شخص با موفقیت ویرایش شد.");
        }


        #endregion Update


        #region Delete


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await personService.DeletePersonAsync(id);

            if (!result.IsSucces)
            {

                return NotFound(result.Error);

            }

            return Ok("کاربر با موفقیت حذف شد.");

        }


        #endregion Delete


    }
}
