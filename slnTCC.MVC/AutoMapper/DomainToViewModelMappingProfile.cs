using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnTCC.Domain.Entities;
using slnTCC.MVC.ViewModels;
using AutoMapper;

namespace slnTCC.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }
    }
}