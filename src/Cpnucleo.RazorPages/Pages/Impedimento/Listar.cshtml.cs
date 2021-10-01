﻿namespace Cpnucleo.RazorPages.Pages.Impedimento;

[Authorize]
public class ListarModel : PageBase
{
    private readonly ICpnucleoApiService _cpnucleoApiService;

    public ListarModel(ICpnucleoApiService cpnucleoApiService)
    {
        _cpnucleoApiService = cpnucleoApiService;
    }

    public ImpedimentoViewModel Impedimento { get; set; }

    public IEnumerable<ImpedimentoViewModel> Lista { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Lista = await _cpnucleoApiService.GetAsync<IEnumerable<ImpedimentoViewModel>>("impedimento", Token);

            return Page();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }
    }
}
