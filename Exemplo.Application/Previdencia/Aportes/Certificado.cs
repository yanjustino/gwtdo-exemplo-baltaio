using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo.Application.Previdencia.Aportes
{
    public class Certificado
    {
        public string Numero { get; private set; }
        public long CodigoPlano { get; private set; }
        public DateTime DataCotizacaoInicial { get; private set; }
        public List<decimal> Contribuicoes { get; private set; }
        public decimal Total => Contribuicoes.Any() ?  Contribuicoes.Sum(x => x) : 0;

        public static ResultadoAporte AporteInicial(AporteInicial aporteInicial)
        {
            var certificado = new Certificado();
            certificado.RealizarAplicacaoInicial(aporteInicial);
            return new ResultadoAporte(certificado);
        }
        
        public ResultadoAporte AporteExporadico(AporteExporadico aporte)
        {
            Contribuicoes.Add(aporte.Valor);
            return new ResultadoAporte(this);
        }         
        
        public Certificado()
        {
            Numero = $"{DateTime.Now:O}".Replace(":", "-");
            Contribuicoes = new List<decimal>();
        }
        
        public void RealizarAplicacaoInicial(AporteInicial aporteInicial)
        {
            CodigoPlano = aporteInicial.Plano.Codigo;
            DataCotizacaoInicial = DateTime.Today.AddDays(aporteInicial.Plano.CotizacaoAplicacao);
            Contribuicoes.Add(aporteInicial.Valor);
        }
    }
}