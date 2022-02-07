﻿namespace Cpnucleo.Application.Commands.Impedimento.UpdateImpedimento;

public class UpdateImpedimentoCommandValidator : AbstractValidator<UpdateImpedimentoCommand>
{
    public UpdateImpedimentoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Nome).MaximumLength(50);
    }
}
