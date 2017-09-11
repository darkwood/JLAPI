using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JLAPI.Controllers;
using JLAPI.Interfaces;
using JLAPI.Models.Base;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JLAPI.Base
{
    public class EntityControllerBase : Controller
    {
        protected IRepository<EntityBase> _repository;
        
        protected IActionResult ListItems()
        {
            return Ok(_repository.All);
        }

        protected IActionResult CreateItem(EntityBase item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _repository.DoesItemExist(item.ID);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                item.Created = DateTime.Now;
                item.UserId = "CurrentLoggedInUserId";
                _repository.Insert(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        protected IActionResult EditItem(EntityBase item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _repository.Find(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }

                item.Changed = DateTime.Now;
                _repository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return Ok(item);
        }

        protected IActionResult DeleteItem(int id)
        {
            try
            {
                var item = _repository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _repository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
    public enum ErrorCode
    {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }
}
