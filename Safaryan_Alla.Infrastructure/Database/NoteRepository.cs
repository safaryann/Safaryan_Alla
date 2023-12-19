using Safaryan_Alla.Infrastructure.Mappers;
using Safaryan_Alla.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Safaryan_Alla.Infrastructure.Database
{
    public class NoteRepository
    {
        public List<NoteViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Notes.ToList();
                return NoteMapper.Map(items);
            }
        }
        public NoteViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Notes.FirstOrDefault(x => x.NoteId == id);
                return NoteMapper.Map(item);
            }
        }
        public NoteViewModel Add(NoteViewModel entity)
        {
            entity.NoteId = entity.NoteId;
            entity.NoteDate = entity.NoteDate.Trim();
            entity.CreatorName = entity.CreatorName.Trim();
            entity.ShortDescription = entity.ShortDescription.Trim();
            entity.DetailedDescription = entity.DetailedDescription.Trim();
            entity.ProjectId = entity.ProjectId;
            if (string.IsNullOrEmpty(entity.NoteDate) || string.IsNullOrEmpty(entity.CreatorName) || string.IsNullOrEmpty(entity.ShortDescription) || string.IsNullOrEmpty(entity.DetailedDescription))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = NoteMapper.Map(entity);
                context.Notes.Add(item);
                if (item != null)
                {
                    item.NoteId = entity.NoteId;
                    item.NoteDate = entity.NoteDate;
                    item.CreatorName = entity.CreatorName;
                    item.ShortDescription = entity.ShortDescription;
                    item.DetailedDescription = entity.DetailedDescription;
                    item.ProjectId = (long)Convert.ToDecimal(entity.ProjectId);
                    context.Notes.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return NoteMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Notes.FirstOrDefault(x => x.NoteId == id);
                if (user != null)
                {
                    context.Notes.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public NoteViewModel Update(NoteViewModel entity)
        {
            entity.NoteId = entity.NoteId;
            entity.NoteDate = entity.NoteDate.Trim();
            entity.CreatorName = entity.CreatorName.Trim();
            entity.ShortDescription = entity.ShortDescription.Trim();
            entity.DetailedDescription = entity.DetailedDescription.Trim();
            entity.ProjectId = entity.ProjectId;
            if (string.IsNullOrEmpty(entity.NoteDate) || string.IsNullOrEmpty(entity.CreatorName) || string.IsNullOrEmpty(entity.ShortDescription) || string.IsNullOrEmpty(entity.DetailedDescription))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = context.Notes.FirstOrDefault(x => x.NoteId == entity.NoteId);
                if (item != null)
                {
                    item.NoteId = entity.NoteId;
                    item.NoteDate = entity.NoteDate;
                    item.CreatorName = entity.CreatorName;
                    item.ShortDescription = entity.ShortDescription;
                    item.DetailedDescription = entity.DetailedDescription;
                    item.ProjectId = (long)Convert.ToDecimal(entity.ProjectId);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return NoteMapper.Map(item);
            }
        }
        public List<NoteViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Notes
                    .Where(x => x.ShortDescription.ToLower().Contains(search))
                    .ToList();

                return NoteMapper.Map(result);
            }
        }
    }
}
