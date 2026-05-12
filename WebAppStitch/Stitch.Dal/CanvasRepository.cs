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
    public class CanvasRepository : ICanvasRepository
    {
        private DataContext _dataContext;
        public CanvasRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(CanvasDto canvas)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas));
            }
            if (canvas.Name == null || canvas.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            _dataContext.Canvas.Add(canvas);
            _dataContext.SaveChanges();
            return canvas.Id;
        }

        public void DeleteById(int id)
        {
            var refCanvas = GetById(id);
            _dataContext.Canvas.Remove(refCanvas);
            _dataContext.SaveChanges();
        }

        public List<CanvasDto> GetAll()
        {
            var result = _dataContext.Canvas.ToList();
            return result;
        }

        public CanvasDto GetById(int id)
        {
            var result = _dataContext.Canvas.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_canvas");
            }
            return result;
        }

        public void Update(CanvasDto canvas)
        {
            var refCanvas = GetById(canvas.Id);
            refCanvas.Name = canvas.Name;
            _dataContext.SaveChanges();
        }
    }
}
