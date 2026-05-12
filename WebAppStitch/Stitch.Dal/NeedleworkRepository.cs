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
    public class NeedleworkRepository : INeedleworkRepository
    {
        private DataContext _dataContext;
        public NeedleworkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(NeedleworkDto needlework)
        {
            if (needlework == null)
            {
                throw new ArgumentNullException(nameof(needlework));
            }
            if (needlework.Name == null || needlework.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            _dataContext.Needlework.Add(needlework);
            _dataContext.SaveChanges();
            return needlework.Id;
        }

        public void DeleteById(int id)
        {
            var refNeedlework = GetById(id);
            _dataContext.Needlework.Remove(refNeedlework);
            _dataContext.SaveChanges();
        }

        public List<NeedleworkDto> GetAll()
        {
            var result = _dataContext.Needlework.ToList();
            return result;
        }

        public NeedleworkDto GetById(int id)
        {
            var result = _dataContext.Needlework.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_needlework");
            }
            return result;
        }

        public void Update(NeedleworkDto needlework)
        {
            var refNeedlework = GetById(needlework.Id);
            refNeedlework.Name = needlework.Name;
            _dataContext.SaveChanges();
        }
    }
}
