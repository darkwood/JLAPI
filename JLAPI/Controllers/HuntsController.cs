﻿using System;
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
    public class HuntsController : EntityControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok(DB.HuntsRepository.All);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Hunt item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = DB.HuntsRepository.DoesItemExist(item.ID);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                item.ID = DB.HuntsRepository.All.Max(r => r.ID) + 1;
                item.Created = DateTime.Now;
                item.UserId = "CurrentLoggedInUserId";
                DB.HuntsRepository.Insert(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Hunt item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = DB.HuntsRepository.Find(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }

                item.Changed = DateTime.Now;
                DB.HuntsRepository.Update(item);
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
                var item = DB.HuntsRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                DB.HuntsRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
    
}
