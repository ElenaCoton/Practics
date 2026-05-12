using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.IRepositories;

namespace Stitch.Dal
{
    public class ThemeRepository : IThemeRepository
    {
        private DataContext _dataContext;
        public ThemeRepository(DataContext context)
        {
            _dataContext = context;
        }

        public int Add(ThemeDto theme)
        {
            if (theme == null)
            {
                throw new ArgumentNullException(nameof(theme));
            }
            if (theme.Name == null || theme.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            _dataContext.Theme.Add(theme);
            _dataContext.SaveChanges();
            return theme.Id;
        }

        public void DeleteById(int id)
        {
            var refTheme = GetById(id);
            _dataContext.Theme.Remove(refTheme);
            _dataContext.SaveChanges();
        }

        public List<ThemeDto> GetAll()
        {
            var result = _dataContext.Theme.ToList();
            return result;
        }

        public ThemeDto GetById(int id)
        {
            var result = _dataContext.Theme.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_theme");
            }

            return result;
        }

        public void Update(ThemeDto theme)
        {
            var refTheme = GetById(theme.Id);
            refTheme.Name = theme.Name;
            _dataContext.SaveChanges();

        }
    }
}
