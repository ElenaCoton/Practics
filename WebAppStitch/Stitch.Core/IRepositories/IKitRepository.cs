using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;
using Stitch.Core.InputModels;
using Stitch.Core.OutputModels;

namespace Stitch.Core.IRepositories
{
    public interface IKitRepository
    {
        public int Add(KitDto kit);

        public List<KitDto> GetAll();

        public KitDto GetById(int id);

        public void DeleteById(int id);

        public void Update(KitDto kit);

        public void AddRefToThemes(KitDto kitWithThemes);

    }
}
