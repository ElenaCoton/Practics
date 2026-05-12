using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.IRepositories
{
    public interface INeedleworkRepository
    {
        public int Add(NeedleworkDto needlework);

        public List<NeedleworkDto> GetAll();

        public NeedleworkDto GetById(int id);

        public void DeleteById(int id);

        public void Update(NeedleworkDto needlework);
    }
}
