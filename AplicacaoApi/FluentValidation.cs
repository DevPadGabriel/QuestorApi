using DominioApi.ModelosDtos;
using FluentValidation;
using FluentValidation.Results;

namespace AplicacaoApi
{
    public class ValidadorBoleto : AbstractValidator<BoletoDto>
    {
        internal string Erros;

        public ValidadorBoleto()
        {
            RuleFor(a => a.NomePagador).NotEmpty().WithMessage("Necessário informar o nome do pagador")
                 .MaximumLength(80).WithMessage("Máximo de 80 caracteres excedido");

            RuleFor(a => a.CpfCnpjPagador).NotEmpty().WithMessage("Necessário informar o o CPF ou CNPJ do pagador")
                 .MaximumLength(18).WithMessage("Máximo de 18 caracteres do campo CpfCnpjPagador excedido");

            RuleFor(a => a.NomeBeneficiario).NotEmpty().WithMessage("Necessário informar o nome do beneficiario")
                 .NotNull().WithMessage("Nome beneficiario nulo")
                 .MaximumLength(80).WithMessage("Máximo de 80 caracteres excedido");

            RuleFor(a => a.CpfCnpjBeneficiario).NotEmpty().WithMessage("Necessário informar o CPF ou CNPJ do beneficiario")
                 .NotNull().WithMessage("CpfCnpj beneficiario nulo")
                 .MaximumLength(18).WithMessage("Máximo de 18 caracteres do campo CpfCnpjPagador excedido");

            RuleFor(a => a.Valor).GreaterThanOrEqualTo(0).WithMessage("Necessário informar o valor.")
                 .NotNull().WithMessage("Valor nulo");

            RuleFor(a => a.DataVencimento).NotNull().WithMessage("Necessário informar a data de vencimento.");

            RuleFor(c => c.BancoId).NotNull().WithMessage("Necessário informar o Id do banco.");
        }
    }

    public class ValidadorBanco : AbstractValidator<BancoDto>
    {
        public ValidadorBanco()
        {
            RuleFor(a => a.NomeBanco).NotEmpty().WithMessage("Necessário informar o nome do banco")
                .MaximumLength(80).WithMessage("Máximo de 80 caracteres do campo NomeBanco excedido");

            RuleFor(a => a.CodigoBanco).NotEmpty().WithMessage("Necessário informar o codigo do banco").
                MaximumLength(30).WithMessage("Máximo de 30 caracteres do campo CodigoBanco excedido");

            RuleFor(a => a.PercentualJuros).GreaterThanOrEqualTo(0).WithMessage("Necessário informar o percentual de juros")
                .NotNull().WithMessage("Valor nulo"); ;
        }
    }
}