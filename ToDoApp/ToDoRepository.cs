using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp
{
    public class ToDoRepository : Repository<Models.ToDo>, IToDoRepository
    {
        public ToDoRepository(Context db) : base(db)
        {




        }
    }
}
