using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Models
{
    public class Process
    {
        public int id { get; set; }
        public int procedure_id { get; set; }
        public int group_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}
