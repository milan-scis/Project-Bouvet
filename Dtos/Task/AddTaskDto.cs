﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BouvetTask.Dtos.Task
{
    public class AddTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EpicId { get; set; }
    }
}
