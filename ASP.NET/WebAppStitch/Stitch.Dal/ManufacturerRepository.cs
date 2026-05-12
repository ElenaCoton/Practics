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
    public class ManufacturerRepository : IManufacturerRepository
    {
        private DataContext _dataContext;

        public ManufacturerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int Add(ManufacturerDto facture)
        {
            if (facture == null)
            {
                throw new ArgumentNullException(nameof(facture));
            }
            if (facture.Name == null || facture.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            _dataContext.Manufacturer.Add(facture);
            _dataContext.SaveChanges();
            return facture.Id;
        }

        public void DeleteById(int id)
        {
            var reffacture = GetById(id);
            _dataContext.Manufacturer.Remove(reffacture);
            _dataContext.SaveChanges();
        }

        public List<ManufacturerDto> GetAll()
        {
            var result = _dataContext.Manufacturer.ToList();
            return result;
        }

        public ManufacturerDto GetById(int id)
        {
            var result = _dataContext.Manufacturer.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_manufacture");
            }
            return result;
        }

        public void Update(ManufacturerDto facture)
        {
            var reffacture = GetById(facture.Id);
            reffacture.Name = facture.Name;
            _dataContext.SaveChanges();
        }
    }
}
