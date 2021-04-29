using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMVC2.Models.TableViewModels
{
    public class SubjectTableViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int Availability { get; set; }
        public string TimeTable { get; set; }
    }
}