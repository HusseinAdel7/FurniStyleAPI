using AutoMapper;
using FurniStyle.Core.DTOs.Furnis;
using FurniStyle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Core.Mapping.Furnis
{
    public class FurniProfile :Profile
    {
        public FurniProfile()
        {
            CreateMap<Furni,FurniDTO>().ForMember(p => p.CategoryName, options => options.MapFrom(p => p.Category.Name))
                                           .ForMember(p => p.RoomName, options => options.MapFrom(p => p.Room.Name));
        }
    }
}
