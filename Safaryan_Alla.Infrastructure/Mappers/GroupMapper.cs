using Safaryan_Alla.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaryan_Alla.Infrastructure.Mappers
{
    public static class GroupMapper
    {
        public static GroupViewModel Map(GroupEntity entity)
        {
            var viewModel = new GroupViewModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                GroupLeader = entity.GroupLeader,
            };
            return viewModel;
        }

        public static List<GroupViewModel> Map(List<GroupEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static GroupEntity Map(GroupViewModel viewModel)
        {
            var entity = new GroupEntity
            {
                GroupId = viewModel.GroupId,
                GroupName = viewModel.GroupName,
                GroupLeader = viewModel.GroupLeader,
            };
            return entity;
        }
    }
}
