using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaryan_Alla.Infrastructure.ViewModels
{
    public class ProjectViewModel
    {
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectLeader { get; set; }
        public string StartDate { get; set; }
        public string PlanEndDate { get; set; }
        public string GroupId { get; set; }
    }
}
