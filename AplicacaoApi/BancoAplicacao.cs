using AutoMapper;
using FluentValidation.Results;
using DominioApi.ModelosDtos;
using DominioApi.Interfaces;
using DominioApi.Entidades;

namespace AplicacaoApi
{
    public class BancoAplicacao : IBancoAplicacao
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        private readonly IMapper _mapper;

        public BancoAplicacao(IBancoRepositorio bancoRepositorio, IMapper mapper)
        {
            _bancoRepositorio = bancoRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> GravarBanco(BancoDto bancoDto)
        {
            Banco banco = _mapper.Map<Banco>(bancoDto);
            return await _bancoRepositorio.SalvarBanco(banco);
        }

        public async Task<BancoDto> ObterBancoPorCodigo(string codigoBanco)
        {
            return _mapper.Map<BancoDto>(await _bancoRepositorio.ObterBancoPorCodigo(codigoBanco));
        }

        public async Task<List<BancoDto>> ObterBancos()
        {
            return _mapper.Map<List<BancoDto>>(await _bancoRepositorio.ObterBancos());
        }

        public async Task<ValidationResult> ValidarBanco(BancoDto banco)
        {
            return await new ValidadorBanco().ValidateAsync(banco);
        }

        public async Task<Banco> ObterBancoPorId(int id)
        {
            return await _bancoRepositorio.ObterBancoPorId(id);
        }
    }
}
