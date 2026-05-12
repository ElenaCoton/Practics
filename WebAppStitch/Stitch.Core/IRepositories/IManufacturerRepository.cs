using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.IRepositories
{
    public interface IManufacturerRepository
    {
        public int Add(ManufacturerDto facture);

        public List<ManufacturerDto> GetAll();

        public ManufacturerDto GetById(int id);

        public void DeleteById(int id);

        public void Update(ManufacturerDto facture);
    }
}
