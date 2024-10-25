using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Task
    {
        public string Description { get; set; }
        public Status Status { get; set; }

        public Task(string description)
        {
            Description = description;
            Status = Status.PENDING;
        }

        public override string ToString()
        {
            return Description + " - " + char.ToUpper(Status.ToString()[0]) + Status.ToString().Substring(1).ToLower();
        }

    }
}
