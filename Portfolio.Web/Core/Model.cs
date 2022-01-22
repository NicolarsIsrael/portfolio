using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Core
{
    public class IndexModel
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}
