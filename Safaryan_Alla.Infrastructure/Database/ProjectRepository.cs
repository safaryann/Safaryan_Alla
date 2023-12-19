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
    public class ProjectRepository
    {
        public List<ProjectViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Projects.ToList();
                return ProjectMapper.Map(items);
            }
        }
        public ProjectViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Projects.FirstOrDefault(x => x.ProjectId == id);
                return ProjectMapper.Map(item);
            }
        }
        public ProjectViewModel Add(ProjectViewModel entity)
        {
            entity.ProjectId = entity.ProjectId;
            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description.Trim();
            entity.ProjectLeader = entity.ProjectLeader.Trim();
            entity.StartDate = entity.StartDate.Trim();
            entity.PlanEndDate = entity.PlanEndDate.Trim();
            entity.GroupId = entity.GroupId;
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Description) || string.IsNullOrEmpty(entity.ProjectLeader) || string.IsNullOrEmpty(entity.StartDate) || string.IsNullOrEmpty(entity.PlanEndDate))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = ProjectMapper.Map(entity);
                context.Projects.Add(item);
                if (item != null)
                {
                    item.ProjectId = entity.ProjectId;
                    item.Name = entity.Name;
                    item.Description = entity.Description;
                    item.ProjectLeader = entity.ProjectLeader;
                    item.StartDate = entity.StartDate;
                    item.PlanEndDate = entity.PlanEndDate;
                    item.GroupId = (long)Convert.ToDecimal(entity.GroupId);
                    context.Projects.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProjectMapper.Map(item);
            }
        }
        public void Delete(long id)
        {
            using (var context = new Context())
            {
                var user = context.Projects.FirstOrDefault(x => x.ProjectId == id);
                if (user != null)
                {
                    context.Projects.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public ProjectViewModel Update(ProjectViewModel entity)
        {
            entity.ProjectId = entity.ProjectId;
            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description.Trim();
            entity.ProjectLeader = entity.ProjectLeader.Trim();
            entity.StartDate = entity.StartDate.Trim();
            entity.PlanEndDate = entity.PlanEndDate.Trim();
            entity.GroupId = entity.GroupId;
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Description) || string.IsNullOrEmpty(entity.ProjectLeader) || string.IsNullOrEmpty(entity.StartDate) || string.IsNullOrEmpty(entity.PlanEndDate))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            using (var context = new Context())
            {
                var item = context.Projects.FirstOrDefault(x => x.ProjectId == entity.ProjectId);
                if (item != null)
                {
                    item.ProjectId = entity.ProjectId;
                    item.Name = entity.Name;
                    item.Description = entity.Description;
                    item.ProjectLeader = entity.ProjectLeader;
                    item.StartDate = entity.StartDate;
                    item.PlanEndDate = entity.PlanEndDate;
                    item.GroupId = (long)Convert.ToDecimal(entity.GroupId);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return ProjectMapper.Map(item);
            }
        }
        public List<ProjectViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Projects
                    .Where(x => x.Name.ToLower().Contains(search))
                    .ToList();

                return ProjectMapper.Map(result);
            }
        }
    }
}
