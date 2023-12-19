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
    public class GroupRepository
    {
        public List<GroupViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Groups.ToList();
                return GroupMapper.Map(items);
            }
        }
        public GroupViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Groups.FirstOrDefault(x => x.GroupId == id);
                return GroupMapper.Map(item);
            }
        }
        public GroupViewModel Add(GroupViewModel entity)
        {
            entity.GroupId = entity.GroupId;
            entity.GroupName = entity.GroupName.Trim();
            entity.GroupLeader = entity.GroupLeader.Trim();
            if (string.IsNullOrEmpty(entity.GroupName) || string.IsNullOrEmpty(entity.GroupLeader))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = GroupMapper.Map(entity);
                context.Groups.Add(item);
                if (item != null)
                {
                    item.GroupId = entity.GroupId;
                    item.GroupName = entity.GroupName;
                    item.GroupLeader = entity.GroupLeader;
                    context.Groups.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return GroupMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Groups.FirstOrDefault(x => x.GroupId == id);
                if (user != null)
                {
                    context.Groups.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public GroupViewModel Update(GroupViewModel entity)
        {
            entity.GroupId = entity.GroupId;
            entity.GroupName = entity.GroupName.Trim();
            entity.GroupLeader = entity.GroupLeader.Trim();
            if (string.IsNullOrEmpty(entity.GroupName) || string.IsNullOrEmpty(entity.GroupLeader))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = context.Groups.FirstOrDefault(x => x.GroupId == entity.GroupId);
                if (item != null)
                {
                    item.GroupId = entity.GroupId;
                    item.GroupName = entity.GroupName;
                    item.GroupLeader = entity.GroupLeader;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return GroupMapper.Map(item);
            }
        }
        public List<GroupViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Groups
                    .Where(x => x.GroupName.ToLower().Contains(search))
                    .ToList();

                return GroupMapper.Map(result);
            }
        }
    }
}
