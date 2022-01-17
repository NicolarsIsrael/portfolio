using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Core
{
    public class Certificate : Entity
    {
        public string Title { get; set; }
        public string Organization { get; set; }
        public string Url { get; set; }
        public string Descritption { get; set; }
        public DateTime DateAwarded { get; set; }

    }
}
