using System;
using Exemplo.Application.Previdencia.Aportes;
using FluentAssertions;
using Gwtdo.Extensions;
using Gwtdo.Scenarios;

namespace GwtDo.Exemplo.Tests.Previdencia.AportesInicial
{
    public class AporteInicialMapper : ScenarioMapper<AporteInicialFixture>
    {
        public AporteInicialMapper(Scenario<AporteInicialFixture> scenario): base(scenario)
        {
        }

        public void Map_aporte_plano_d0()
        {
            SCENARIO["Aporte inicial"] =
                DESCRIBE 
                | "Cliente faz aporte inicial em plano de cotização D+0" |
                GIVEN 
                | "Um plano de previdência com cotização inical D+0 (Dias Úteis)".MapAction(PlanoCotizacaoD0)| AND 
                | "Eu tenho um valor de R$ 500,00 para realizar um aporte".MapAction(Aporte500) |
                WHEN 
                | "Eu realizo esse aporte inicial hoje".MapAction(RegistroAporte500) |
                THEN 
                | "A data de cotização inicial do meu certificado deve ser hoje".MapAction(DataCotizacaoHoje);                       
        }
        
        public void Map_plano_minimo_500()
        {
            SCENARIO["Aporte inicial sem valor mínimo exigido"] =
                DESCRIBE 
                | "Cliente faz aporte inicial em plano de contribuição mínima de R$ 500,00" |
                GIVEN 
                | "Um plano de previdência com contribuição inical mínima de R$ 500".MapAction(PlanoMinimo500) | AND 
                | "Eu tenho um valor de R$ :valor-aporte para realizar um aporte".MapAction(AporteDinamico) |
                WHEN 
                | "Eu realizo esse aporte inicial desse valor".MapAction(RegistroAporte400) |
                THEN 
                | "O aporte deve ser rejeitado criticando valor mínimo não atendido".MapAction(AporteRejeitado);                   
        }        

        private Action<AporteInicialFixture> PlanoCotizacaoD0 =>
            f => f.Plano = new Plano(1000, "plano 10", 0);
        
        private Action<AporteInicialFixture> PlanoMinimo500 =>
            f => f.Plano = new Plano(2000, "plano 10", 0, 0, 500);        
        
        private Action<AporteInicialFixture> Aporte500 =>
            f => f.AporteInicial = new AporteInicial(f.Plano, 500, DateTime.Now);
        
        private Action<AporteInicialFixture> AporteDinamico =>
            f => f.AporteInicial = new AporteInicial(f.Plano, Let.Get<decimal>("valor-aporte"), DateTime.Now);        

        private Action<AporteInicialFixture> RegistroAporte500 =>
            async f => f.Resultado = await f.RegistroAporte.Inicial(f.AporteInicial);
        
        private Action<AporteInicialFixture> RegistroAporte400 =>
            async f => f.Resultado = await f.RegistroAporte.Inicial(f.AporteInicial);        
        
        private Action<AporteInicialFixture> DataCotizacaoHoje =>
            f => f.Resultado.Certificado.DataCotizacaoInicial.Should().Be(DateTime.Today);  
        
        private Action<AporteInicialFixture> AporteRejeitado =>
            f => f.Resultado.IsValid.Should().BeFalse();           
    }
}