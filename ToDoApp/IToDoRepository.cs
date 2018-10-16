using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
    }
}
