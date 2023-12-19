using Safaryan_Alla.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaryan_Alla.Infrastructure.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectViewModel Map(ProjectEntity entity)
        {
            var viewModel = new ProjectViewModel
            {
                ProjectId = entity.ProjectId,
                Name = entity.Name,
                Description = entity.Description,
                ProjectLeader = entity.ProjectLeader,
                StartDate = entity.StartDate,
                PlanEndDate = entity.PlanEndDate,
                GroupId = entity.GroupId.ToString(),
            };
            return viewModel;
        }

        public static List<ProjectViewModel> Map(List<ProjectEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static ProjectEntity Map(ProjectViewModel viewModel)
        {
            var entity = new ProjectEntity
            {
                ProjectId = viewModel.ProjectId,
                Name = viewModel.Name,
                Description = viewModel.Description,
                ProjectLeader = viewModel.ProjectLeader,
                StartDate = viewModel.StartDate,
                PlanEndDate = viewModel.PlanEndDate,
                GroupId = (long)Convert.ToDecimal(viewModel.GroupId),
            };
            return entity;
        }
    }
}
