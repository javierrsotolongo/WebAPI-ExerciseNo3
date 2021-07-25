using AutoMapper;
using BugsManager.Models;
using BugsManager.ViewModels.Bug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateBugVM, Bug>();
            CreateMap<Bug, BugMV>();
            CreateMap<Bug, BugDataMV>().
            ForMember(s => s.Id, o => o.MapFrom(b => b.BugId)).
            ForMember(s => s.Project, o => o.MapFrom(b => b.Project.Name)).
            ForMember(s => s.UserName, o => o.MapFrom(b => b.User.Name));
        }
    }
}
