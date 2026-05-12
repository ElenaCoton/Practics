using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.IRepositories
{
    public interface IStatusRepository
    {
        public int Add(StatusDto statusKit);

        public List<StatusDto> GetAll();

        public StatusDto GetById(int id);

        public void DeleteById(int id);

        public void Update(StatusDto statusKit);
    }
}
