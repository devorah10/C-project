using AutoMapper;
using Repositories.Models;
using Service.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Profiles
{
    class companyProfile: Profile
    {
        public companyProfile()
        {
            CreateMap<Company, companyVM>().ReverseMap().ForPath(f => f.Id, o => o.Ignore());


        }
    }
}
