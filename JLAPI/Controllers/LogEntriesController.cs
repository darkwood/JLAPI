using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JLAPI.Base;
using JLAPI.Interfaces;
using JLAPI.Models.Base;
using JLAPI.Models;
using JLAPI.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JLAPI.Controllers
{
    [Route("api/[controller]")]
    public class LogEntriesController : EntityControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(DB.LogsRepository.All);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] LogEntry item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = DB.LogsRepository.DoesItemExist(item.ID);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                item.ID = DB.LogsRepository.All.Max(r => r.ID) + 1;
                item.Created = DateTime.Now;
                item.UserId = "CurrentLoggedInUserId";
                DB.LogsRepository.Insert(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] LogEntry item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = DB.LogsRepository.Find(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }

                item.Changed = DateTime.Now;
                DB.LogsRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return Ok(item);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = DB.LogsRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                DB.LogsRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
    
}
