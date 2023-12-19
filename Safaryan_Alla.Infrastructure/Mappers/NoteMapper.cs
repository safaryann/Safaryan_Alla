using Safaryan_Alla.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safaryan_Alla.Infrastructure.Mappers
{
    public static class NoteMapper
    {
        public static NoteViewModel Map(NoteEntity entity)
        {
            var viewModel = new NoteViewModel
            {
                NoteId = entity.NoteId,
                NoteDate = entity.NoteDate,
                CreatorName = entity.CreatorName,
                ShortDescription = entity.ShortDescription,
                DetailedDescription = entity.DetailedDescription,
                ProjectId = entity.ProjectId.ToString(),
            };
            return viewModel;
        }

        public static List<NoteViewModel> Map(List<NoteEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        public static NoteEntity Map(NoteViewModel viewModel)
        {
            var entity = new NoteEntity
            {
                NoteId = viewModel.NoteId,
                NoteDate = viewModel.NoteDate,
                CreatorName = viewModel.CreatorName,
                ShortDescription = viewModel.ShortDescription,
                DetailedDescription = viewModel.DetailedDescription,
                ProjectId = (long)Convert.ToDecimal(viewModel.ProjectId),
            };
            return entity;
        }
    }
}
