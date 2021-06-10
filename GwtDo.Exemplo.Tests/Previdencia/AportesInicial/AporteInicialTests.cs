using FluentAssertions;
using Gwtdo;
using Xunit;
using Xunit.Abstractions;

namespace GwtDo.Exemplo.Tests.Previdencia.AportesInicial
{
    public class AporteInicialTests : Feature<AporteInicialFixture>,
        IClassFixture<AporteInicialFixture>
    {
        private readonly AporteInicialMapper _mapper;

        public AporteInicialTests(AporteInicialFixture fixture, ITestOutputHelper output) :
            base(fixture)
        {
            SCENARIO.RedirectStandardOutput = output.WriteLine;
            _mapper = new AporteInicialMapper(SCENARIO);
        }

        [Fact]
        public void Descrevendo_aporte_inicial()
        {
            _mapper.Map_aporte_plano_d0();
            
            SCENARIO["Aporte inicial"] =
                DESCRIBE
                | "Cliente faz aporte inicial em plano de cotização D+0" |
                GIVEN
                | "Um plano de previdência com cotização inical D+0 (Dias Úteis)" | AND
                | "Eu tenho um valor de R$ 500,00 para realizar um aporte" |
                WHEN
                | "Eu realizo esse aporte inicial hoje" |
                THEN
                | "A data de cotização inicial do meu certificado deve ser hoje";

            SCENARIO.Execute().IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(300)]
        [InlineData(400)]
        public void Descrevendo_aplicacao_minima(decimal valor)
        {
            Let["valor-aporte"] = valor;

            _mapper.Map_plano_minimo_500();

            SCENARIO["Aporte inicial sem valor mínimo exigido"] =
                DESCRIBE 
                | "Cliente faz aporte inicial em plano de contribuição mínima de R$ 500,00" |
                GIVEN 
                | "Um plano de previdência com contribuição inical mínima de R$ 500" | AND 
                | "Eu tenho um valor de R$ :valor-aporte para realizar um aporte" |
                WHEN 
                | "Eu realizo esse aporte inicial desse valor" |
                THEN 
                | "O aporte deve ser rejeitado criticando valor mínimo não atendido";

            SCENARIO.Execute().IsSuccess.Should().BeTrue();
        }
    }
}