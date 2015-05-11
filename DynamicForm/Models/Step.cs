using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Models
{
    public class Step
    {
        public int id { get; set; }
        public int step_id { get; set; }
        public int procedure_id { get; set; }
        public string content { get; set; }
        public string url { get; set; }
    }
}
