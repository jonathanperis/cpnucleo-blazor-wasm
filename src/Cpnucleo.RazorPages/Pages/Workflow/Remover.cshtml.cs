﻿using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using Cpnucleo.RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpnucleo.RazorPages.Pages.Workflow
{
    [Authorize]
    public class RemoverModel : PageBase
    {
        private readonly ICpnucleoApiService _cpnucleoApiService;

        public RemoverModel(ICpnucleoApiService cpnucleoApiService)
        {
            _cpnucleoApiService = cpnucleoApiService;
        }

        [BindProperty]
        public WorkflowViewModel Workflow { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                Workflow = await _cpnucleoApiService.GetAsync<WorkflowViewModel>("workflow", Token, id);

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Workflow = await _cpnucleoApiService.GetAsync<WorkflowViewModel>("workflow", Token, Workflow.Id);

                    return Page();
                }

                await _cpnucleoApiService.DeleteAsync("workflow", Token, Workflow.Id);

                return RedirectToPage("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}