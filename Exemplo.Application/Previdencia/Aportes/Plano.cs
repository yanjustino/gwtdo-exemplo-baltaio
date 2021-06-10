namespace Exemplo.Application.Previdencia.Aportes
{
    public class Plano
    {
        public long Codigo { get; private set; }
        public decimal ContribuicaoInicialMinima { get; private set; }
        public decimal ContribuicaoMinima { get; private set; }
        public string Nome { get; private set; }
        public int CotizacaoAplicacao { get; private set; }

        public Plano(long codigo, string nome, int cotizacaoAplicacao, decimal contribuicaoMinima = 0, decimal contribuicaoInicialMinima = 0)
        {
            Codigo = codigo;
            Nome = nome;
            CotizacaoAplicacao = cotizacaoAplicacao;
            ContribuicaoMinima = contribuicaoMinima;
            ContribuicaoInicialMinima = contribuicaoInicialMinima;
        }
    }
}