using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Stitch.Core.Dtos;
using Stitch.Core.InputModels;
using Stitch.Core.IRepositories;
using Stitch.Core.OutputModels;
using Stitch.Dal;

namespace Stitch.Bll
{
    public class ManufacturerManager
    {
        private IManufacturerRepository _manufacturerRepository;

        public ManufacturerManager(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public int Add(ManufacturerInputModel facturer)
        {
            ManufacturerDto manufacturerDto = facturer.Adapt<ManufacturerDto>();
            return _manufacturerRepository.Add(manufacturerDto);
        }

        public List<ManufacturerOutputModel> GetAll()
        {
            var facturer = _manufacturerRepository.GetAll();
            var result = facturer.Adapt<List<ManufacturerOutputModel>>();
            return result;
        }

        public ManufacturerDto Get(int id) 
        {
            var manufacturer = _manufacturerRepository.GetById(id);
            return manufacturer;
        }

        public void Update(ManufacturerInputModel facturer)
        {
            var result = facturer.Adapt<ManufacturerDto>();
            _manufacturerRepository.Update(result);
        }

        public void Delete(int id)
        {
            _manufacturerRepository.DeleteById(id);
        }
    }
}
