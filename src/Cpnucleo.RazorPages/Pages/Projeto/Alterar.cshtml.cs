﻿using Cpnucleo.Infra.CrossCutting.Communication.API.Interfaces;
using Cpnucleo.Infra.CrossCutting.Identity.Interfaces;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Cpnucleo.RazorPages.Pages.Projeto
{
    [Authorize]
    public class AlterarModel : PageBase
    {
        private readonly ICrudApiService<ProjetoViewModel> _projetoApiService;
        private readonly ICrudApiService<SistemaViewModel> _sistemaApiService;

        public AlterarModel(IClaimsManager claimsManager,
                                    ICrudApiService<ProjetoViewModel> projetoApiService,
                                    ICrudApiService<SistemaViewModel> sistemaApiService)
            : base(claimsManager)
        {
            _projetoApiService = projetoApiService;
            _sistemaApiService = sistemaApiService;
        }

        [BindProperty]
        public ProjetoViewModel Projeto { get; set; }

        public SelectList SelectSistemas { get; set; }

        public async Task<IActionResult> OnGet(Guid id)
        {
            Projeto = await _projetoApiService.ConsultarAsync(Token, id);
            SelectSistemas = new SelectList(await _sistemaApiService.ListarAsync(Token), "Id", "Nome");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                SelectSistemas = new SelectList(await _sistemaApiService.ListarAsync(Token), "Id", "Nome");

                return Page();
            }

            await _projetoApiService.AlterarAsync(Token, Projeto);

            return RedirectToPage("Listar");
        }
    }
}