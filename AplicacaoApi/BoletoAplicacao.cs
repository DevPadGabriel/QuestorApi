using AutoMapper;
using DominioApi.Entidades;
using DominioApi.Interfaces;
using DominioApi.ModelosDtos;
using FluentValidation.Results;

namespace AplicacaoApi
{
    public class BoletoAplicacao : IBoletoAplicacao
    {
        private readonly IBoletoRepositorio _boletoRepositorio;

        private readonly IBancoAplicacao _bancoAplicacao;

        private readonly IMapper _mapper;

        public BoletoAplicacao(IBoletoRepositorio boletoRepositorio, IBancoAplicacao bancoAplicacao,IMapper mapper)
        {
            _bancoAplicacao = bancoAplicacao;
            _boletoRepositorio = boletoRepositorio;
            _mapper = mapper;
        }

        public async Task<ValidationResult> ValidarBoleto(BoletoDto boleto)
        {
            if ((await _bancoAplicacao.ObterBancoPorId(boleto.BancoId)) == null)
                throw new ArgumentException("Banco informado não encontrado.");

            return await new ValidadorBoleto().ValidateAsync(boleto);
        }

        public async Task<bool> GravarBoleto(BoletoDto boletoDto)
        {
            var boleto =_mapper.Map<Boleto>(boletoDto);
            return await _boletoRepositorio.SalvarBoleto(boleto);
        }

        public async Task<BoletoDto> ObterBoletoPorId(int id)
        {
            var boleto = await _boletoRepositorio.ObterBoletoPorId(id);

            if (boleto == null)
                return null;

            if (DateOnly.FromDateTime(DateTime.Today) > boleto.DataVencimento)
                CalcularJurosAposVencimento(boleto);

            return _mapper.Map<BoletoDto>(boleto);
        }

        private static void CalcularJurosAposVencimento(Boleto boleto)
        {
            boleto.Valor += boleto.Valor * (boleto.Banco.PercentualJuros / 100);
        }
    }
}
