using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web.Core
{
    public enum ParticipationType
    {
        [Display(Name ="Individual project")]
        Individual,

        [Display(Name ="Team project")]
        Group,
    }
    public class Project : Entity
    {
        public string Title { get; set; }
        public ParticipationType Participation { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public string LiveDemoUrl { get; set; }
        public string CodeUrl { get; set; }
        public int Rank { get; set; }
    }
}
