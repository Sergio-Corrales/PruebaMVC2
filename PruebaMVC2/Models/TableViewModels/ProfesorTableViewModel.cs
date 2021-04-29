using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMVC2.Models.TableViewModels
{
    public class ProfesorTableViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public string State { get; set; }
    }
}