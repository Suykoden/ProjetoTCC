using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using slnTCC.MVC.ViewModels;

namespace slnTCC.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<DomainToViewModelMappingProfile>();
                    x.AddProfile<ViewModelToDomainMappingProfile>();
                });
        }

    }
}