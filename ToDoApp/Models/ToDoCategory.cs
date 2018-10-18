using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public int ToDoId { get; set; }
        public ToDo Todo { get; set; }
        public int CatagoryId { get; set; }
        public Category Category { get; set; }
    }
}
