using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Stitch.Core.Dtos;
using Stitch.Core.InputModels;
using Stitch.Core.OutputModels;

namespace Stitch.Core
{
    public static class MapsterConfig
    {
        public static void SetConfig()
        {
            TypeAdapterConfig.GlobalSettings
               .NewConfig<CanvasInputModel, CanvasDto>();

            TypeAdapterConfig.GlobalSettings
                .NewConfig<CanvasDto, CanvasOutputModel>();


            TypeAdapterConfig.GlobalSettings
               .NewConfig<KitInputModel, KitDto>()
               .Map(c=>c.Themes, m => m.Themes.Adapt<List<ThemeDto>>())
               ;

            TypeAdapterConfig.GlobalSettings
              .NewConfig<KitDto, KitInputModel>()
              .Map(c => c.Themes, m => m.Themes.Adapt<List<ThemeDto>>())
              .Ignore(c=>c.ThemeCheckBoxes)
              ;

            TypeAdapterConfig.GlobalSettings
                .NewConfig<KitDto, KitOutputModel>()
                .Map(k => k.ManufacturerName, k => k.Manufacturer.Name)
                .Map(k => k.CanvasName, k => k.Canvas.Name)
                .Map(k => k.NeedleworkName, k => k.Needlework.Name)
                .Map(k => k.StatusName, k => k.Status.Name)
                .Map(c => c.ComplexityName, c => (c.Complexity > 0)? string.Concat(Enumerable.Repeat('*', (int)c.Complexity)) : string.Empty)
                //.Map(c=>c.ComplexityName,  c=> string ('*', (int)c.Complexity))
                .Map(k => k.XYCountCrossStitch, k => k.XCount * k.YCount)
                ;

            
            TypeAdapterConfig.GlobalSettings
               .NewConfig<ManufacturerInputModel, ManufacturerDto>();

            TypeAdapterConfig.GlobalSettings
                .NewConfig<ManufacturerDto, ManufacturerOutputModel>()
                //.Map(m => m.KitsCount, k => k.Kits.Count());
                .Map(m => m.KitsCount, m => m.Kits != null ? m.Kits.Count : 0);
          


            /*  TypeAdapterConfig.GlobalSettings
                 .NewConfig<NeedleworkInputModel, NeedleworkDto>();

              TypeAdapterConfig.GlobalSettings
                  .NewConfig<NeedleworkDto, NeedleworkOutputModel>();


              TypeAdapterConfig.GlobalSettings
                 .NewConfig<StatusInputModel, StatusDto>();

              TypeAdapterConfig.GlobalSettings
                  .NewConfig<StatusDto, StatusOutputModel>();


              TypeAdapterConfig.GlobalSettings
                 .NewConfig<ThemeInputModel, ThemeDto>();

              TypeAdapterConfig.GlobalSettings
                  .NewConfig<ThemeDto, ThemeOutputModel>();*/
        }
    }
}
