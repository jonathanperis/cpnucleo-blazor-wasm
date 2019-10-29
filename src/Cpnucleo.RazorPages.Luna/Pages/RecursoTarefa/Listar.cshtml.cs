﻿using Cpnucleo.Application.Interfaces;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Cpnucleo.RazorPages.Luna.Pages.RecursoTarefa
{
    [Authorize]
    public class ListarModel : PageModel
    {
        private readonly IRecursoTarefaAppService _recursoTarefaAppService;

        public ListarModel(IRecursoTarefaAppService recursoTarefaAppService)
        {
            _recursoTarefaAppService = recursoTarefaAppService;
        }

        [BindProperty]
        public RecursoTarefaViewModel RecursoTarefa { get; set; }

        public IEnumerable<RecursoTarefaViewModel> Lista { get; set; }

        public IActionResult OnGet(Guid idTarefa)
        {
            Lista = _recursoTarefaAppService.ListarPorTarefa(idTarefa);

            ViewData["idTarefa"] = idTarefa;

            return Page();
        }
    }
}