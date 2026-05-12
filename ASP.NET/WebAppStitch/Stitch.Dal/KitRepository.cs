using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stitch.Core;
using Stitch.Core.Dtos;
using Stitch.Core.IRepositories;

namespace Stitch.Dal
{
    public class KitRepository : IKitRepository
    {
        private DataContext _dataContext;
        public KitRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(KitDto kit)
        {
            if (kit == null)
            {
                throw new ArgumentNullException(nameof(kit));
            }
            if (kit.Name == null || kit.Name.Trim().Length == 0)
            {
                throw new ArgumentException("null_name");
            }
            if (kit.Complexity == null || kit.Complexity == 0) { kit.Complexity = 3; }
            _dataContext.Kit.Add(kit);
            _dataContext.SaveChanges();
            return kit.Id;
        }

        public void DeleteById(int id)
        {
            var refkIT = GetById(id);
            _dataContext.Kit.Remove(refkIT);
            _dataContext.SaveChanges();
        }

        public List<KitDto> GetAll()
        {
            var result = _dataContext.Kit
                .Include(m => m.Manufacturer)
                .Include(c => c.Canvas)
                .Include(n => n.Needlework)
                .Include(s => s.Status)
                .ToList();
            return result;
        }

        public KitDto GetById(int id)
        {
            var result = _dataContext.Kit
                .Include(m => m.Manufacturer)
                .Include(c => c.Canvas)
                .Include(t => t.Themes)
                .Include(n => n.Needlework)
                .Include(s => s.Status)
                .FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new AbandonedMutexException("no_kit");
            }
            return result;
        }

        public void Update(KitDto kit)
        {
            var refkIT = GetById(kit.Id);
            refkIT.Name = kit.Name;
            refkIT.KitNumber = kit.KitNumber;
            refkIT.ManufactureId = kit.ManufactureId;
            refkIT.CanvasId = kit.CanvasId;
            refkIT.NeedleworkId = kit.NeedleworkId;
            refkIT.StatusId = kit.StatusId;
            refkIT.Complexity = kit.Complexity;
            refkIT.ColorNumber = kit.ColorNumber;
            refkIT.XCount = kit.XCount;
            refkIT.YCount = kit.YCount;
            refkIT.Quantity = kit.Quantity;
            refkIT.EndDate = kit.EndDate;
            refkIT.StoragePlace = kit.StoragePlace;
            refkIT.ImageLink = kit.ImageLink;
            refkIT.Description = kit.Description;
            _dataContext.SaveChanges();
        }

        public void AddRefToThemes(KitDto kitWithThemes)
        { 
            //1 способ
            //List<ThemeDto> themes = new List<ThemeDto>();
            //foreach (var eachTheme in kitWithThemes.Themes)
            //{ 
            //    themes.Add(_dataContext.Theme.Single(t=>t.Id == eachTheme.Id));
            //}
            //_dataContext.Kit.Single(k=>k.Id==kitWithThemes.Id);
            //_dataContext.SaveChanges();

            //2 способ
            var idsThemes = kitWithThemes.Themes.Select(t => t.Id);
            var currentKit = _dataContext.Kit.Single(t => t.Id == kitWithThemes.Id);
            currentKit.Themes = _dataContext.Theme.Where(t=>idsThemes.Contains(t.Id)).ToList();
            _dataContext.SaveChanges();
        }
    }
}
