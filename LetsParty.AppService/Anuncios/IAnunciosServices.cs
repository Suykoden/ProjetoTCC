﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsParty.AppService.Usuarios.DTO;
using LetsParty.Domain.Model.Atores;
using LetsParty.Domain.Repository;
using LetsParty.Domain.ViewModel;

namespace LetsParty.AppService.Anuncios
{
    public interface IAnunciosServices
    {
        void Grava(Anuncio anuncio);
        IEnumerable<Anuncio> RetornaAnuncios(Guid Id);
        Anuncio BuscaPorId(Guid Id);
        void EditarAnuncio(Anuncio anuncio);
        IEnumerable<AnuncioViewModel> Pesquisa(AnuncioViewModel anuncio, string tipo);
        IEnumerable<AnuncioViewModel> RelatorioLocalidade(string sortOrder, string cidade, string bairro, string estado);
        IEnumerable<Anuncio> ListarTodos();
    }
}
