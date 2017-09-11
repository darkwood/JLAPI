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
