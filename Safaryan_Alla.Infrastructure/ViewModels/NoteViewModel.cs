using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaryan_Alla.Infrastructure.ViewModels
{
    public class NoteViewModel
    {
        public long NoteId { get; set; }
        public string NoteDate { get; set; }
        public string CreatorName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string ProjectId { get; set; }
    }
}
