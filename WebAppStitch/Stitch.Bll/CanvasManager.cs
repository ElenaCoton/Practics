using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Stitch.Core.Dtos;
using Stitch.Core.InputModels;
using Stitch.Core.IRepositories;
using Stitch.Core.OutputModels;

namespace Stitch.Bll
{
    public class CanvasManager
    {
        private ICanvasRepository _canvasRepository;

        public CanvasManager(ICanvasRepository canvasRepository)
        {
            _canvasRepository = canvasRepository;
        }
        public int Add(CanvasInputModel canvas)
        {
            CanvasDto canvasDto = canvas.Adapt<CanvasDto>();
            return _canvasRepository.Add(canvasDto);
        }

        public List<CanvasOutputModel> GetAll()
        {
            var canvas = _canvasRepository.GetAll();
            List<CanvasOutputModel> resCanvas = canvas.Adapt<List<CanvasOutputModel>>();

            return resCanvas;
        }

    }
}
