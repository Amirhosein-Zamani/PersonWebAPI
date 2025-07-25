using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Application.DTO;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Infra.Data.Context;

namespace PersonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(IPersonService personService) : ControllerBase
    {

        #region Read

        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync()
        {

            var people = await personService.GetAllPersonAsync();

            if (people == null || !people.Any())
                return NotFound("هیچ شخصی پیدا نشد.");

            return Ok(people);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await personService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        #endregion Read

        #region Create

        [HttpPost]
        public async Task<IActionResult> AddPersonAsync([FromBody] CreatePersonDto personDto)
        {
            //TODO:: DTO ---> Service ---> Repository

            if (!ModelState.IsValid)
            {

                return BadRequest(new
                {
                    Message = "مقادیر ورودی نامعتبر است!"
                });

            }

            await personService.AddPersonAsync(personDto);

            return Ok();

        }

        #endregion Create

        #region Update

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(int id, [FromBody] EditPersonDto dto)
        {

            var result = await personService.EditPersonAsync(id, dto);

            if (result)
            {
                return Ok("شخص با موفقیت ویرایش شد.");
            }
            else
            {
                return NotFound("شخص مورد نظر یافت نشد.");
            }

        }

        #endregion Update


        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await personService.GetPersonByIdAsync(id);

            if (result != null)
            {
                await personService.DeletePersonAsync(id);
                return Ok("شخص با موفقیت حذف شد.");
            }

            return NotFound("شخص مورد نظر یافت نشد.");
        }



        //    var result = await personService.DeletePersonAsync(id);

        //if (result)
        //    return Ok("شخص با موفقیت حذف شد.");
        //else
        //    return NotFound("شخص مورد نظر یافت نشد.");




    }
}
