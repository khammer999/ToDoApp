﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDo
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

    }
}
