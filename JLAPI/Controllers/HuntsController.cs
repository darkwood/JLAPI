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
    public class HuntsController : EntityControllerBase
    {
        public HuntsController() : base()
        {   
            
        }

        [HttpGet]
        public IActionResult List()
        {
            return ListItems();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Hunt item)
        {
            return CreateItem(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Hunt item)
        {
            return EditItem(item);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return DeleteItem(id);
        }
    }
    
}
