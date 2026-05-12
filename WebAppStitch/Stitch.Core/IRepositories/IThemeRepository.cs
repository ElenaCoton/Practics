using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.IRepositories
{
    public interface IThemeRepository
    {
        public int Add(ThemeDto theme);

        public List<ThemeDto> GetAll();

        public ThemeDto GetById(int id);

        public void DeleteById(int id);

        public void Update(ThemeDto theme);

    }
}
