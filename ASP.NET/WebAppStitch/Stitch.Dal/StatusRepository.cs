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
    public class StatusRepository : IStatusRepository
    {
        private DataContext _dataContext;

        public StatusRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(StatusDto statusKit)
        {
            if (statusKit == null)
            {
                throw new ArgumentNullException(nameof(statusKit));
            }
            if (statusKit.Name == null || statusKit.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            _dataContext.Status.Add(statusKit);
            _dataContext.SaveChanges();
            return statusKit.Id;
        }

        public void DeleteById(int id)
        {
            var refStatus = GetById(id);
            _dataContext.Status.Remove(refStatus);
            _dataContext.SaveChanges();
        }

        public List<StatusDto> GetAll()
        {
            var result = _dataContext.Status.ToList();
            return result;
        }

        public StatusDto GetById(int id)
        {
            var result = _dataContext.Status.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_status");
            }
            return result;
        }

        public void Update(StatusDto statusKit)
        {
            var refStatus = GetById(statusKit.Id);
            refStatus.Name = statusKit.Name;
            _dataContext.SaveChanges();
        }
    }
}
