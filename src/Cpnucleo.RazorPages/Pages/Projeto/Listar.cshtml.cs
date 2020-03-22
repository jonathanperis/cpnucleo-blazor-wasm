﻿using Cpnucleo.Infra.CrossCutting.Communication.API.Interfaces;
using Cpnucleo.Infra.CrossCutting.Identity.Interfaces;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cpnucleo.RazorPages.Pages.Projeto
{
    [Authorize]
    public class ListarModel : PageBase
    {
        private readonly ICrudApiService<ProjetoViewModel> _projetoApiService;

        public ListarModel(IClaimsManager claimsManager,
                                    ICrudApiService<ProjetoViewModel> projetoApiService)
            : base(claimsManager)
        {
            _projetoApiService = projetoApiService;
        }

        public ProjetoViewModel Projeto { get; set; }

        public IEnumerable<ProjetoViewModel> Lista { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Lista = await _projetoApiService.ListarAsync(Token);

            return Page();
        }
    }
}