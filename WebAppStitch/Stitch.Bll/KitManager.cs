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
    public class KitManager
    {
        private IKitRepository _kitRep;

        public KitManager(IKitRepository kit)
        {
            _kitRep = kit;
        }

        public int Add(KitInputModel kitInp)
        {
            KitDto kitDto = kitInp.Adapt<KitDto>();
            var result = _kitRep.Add(kitDto);
            return result;
        }

        public List<KitOutputModel> GetAll()
        {
            List<KitDto> kitDto = _kitRep.GetAll();
            List<KitOutputModel> result = kitDto.Adapt<List<KitOutputModel>>();
            return result;
        }


        public List<KitInputModel> GetAllInp()
        {
            List<KitDto> kitDto = _kitRep.GetAll();
            List<KitInputModel> result = kitDto.Adapt<List<KitInputModel>>();
            return result;
        }

        public KitOutputModel GetById(int id)
        {
            var kitDto = _kitRep.GetById(id);
            var kitOut = kitDto.Adapt<KitOutputModel>();
            return kitOut;
        }

        public KitInputModel GetInputModelById(int id)
        {
            var kitDto = _kitRep.GetById(id);
            var kitInput = kitDto.Adapt<KitInputModel>();
            return kitInput;
        }

        public void DeleteById(int id)
        {
            _kitRep.DeleteById(id);
        }

        public void Update(KitInputModel kitInp)
        {
            var result = kitInp.Adapt<KitDto>();
            _kitRep.Update(result);
        }

        public void LinkThemes(KitInputModel kitInp)
        {
            var kitDtoModel = kitInp.Adapt<KitDto>();
            kitDtoModel.Themes = kitInp.Themes.Adapt<List<ThemeDto>>();

            _kitRep.AddRefToThemes(kitDtoModel);
        }

        public List<KitOutputModel> Search(string pNameKit, int? pManufacturerId, string pKitNumber, int? pThemeId)
        {
            List<KitDto> kitDto = _kitRep.GetAll();

            // Фильтрация данных
            if (!String.IsNullOrEmpty(pNameKit))
            {
                kitDto = kitDto.Where(s => s.Name.Contains(pNameKit)).ToList();
            }

            if (pManufacturerId.HasValue)
            {
                kitDto = kitDto.Where(p => p.ManufactureId == pManufacturerId).ToList();
            }

            if (!String.IsNullOrEmpty(pKitNumber))
            {
                kitDto = kitDto.Where(s => s.KitNumber.Contains(pKitNumber)).ToList();
            }

           

            List<KitOutputModel> result = kitDto.Adapt<List<KitOutputModel>>();
            return result;
        }
    }
}
