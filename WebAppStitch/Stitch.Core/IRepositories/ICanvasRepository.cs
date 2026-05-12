using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stitch.Core.Dtos;

namespace Stitch.Core.IRepositories
{
    public interface ICanvasRepository
    {
        public int Add(CanvasDto canvas);

        public List<CanvasDto> GetAll();

        public CanvasDto GetById(int id);

        public void DeleteById(int id);

        public void Update(CanvasDto canvas);
    }
}
