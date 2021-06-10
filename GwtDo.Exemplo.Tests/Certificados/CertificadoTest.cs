using Gwtdo;
using Xunit;

namespace GwtDo.Exemplo.Tests.Certificados
{
    public class CertificadoTest: Feature<CertificadoFixture>, IClassFixture<CertificadoFixture>
    {
        public CertificadoTest(CertificadoFixture fixture): base(fixture)
        {
            
        }
        
        [Fact]
        public void TesteCertificado()
        {
            GIVEN
                .Eu_tenho_um_certificado_com_valor_inicial_de_500();
            WHEN
                .Eu_faco_um_aporte_de(100)
                .Eu_faco_um_aporte_de(100)
                .Eu_faco_um_aporte_de(100);
            THEN
                .O_valor_deve_ser(800);
        }        

        [Theory]
        [InlineData(100, 600)]
        [InlineData(200, 700)]
        [InlineData(500, 1000)]
        public void TesteCertificadoTotal(decimal aporte, decimal total)
        {
            GIVEN
                .Eu_tenho_um_certificado_com_valor_inicial_de_500();
            WHEN
                .Eu_faco_um_aporte_de(aporte);
            THEN
                .O_valor_deve_ser(total);
        }
    }
}