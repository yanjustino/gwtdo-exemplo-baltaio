using System;
using Exemplo.Application.Previdencia.Aportes;
using FluentAssertions;
using Gwtdo;

namespace GwtDo.Exemplo.Tests.Certificados
{
    using ARRANGE = Arrange<CertificadoFixture>;
    using ACT = Act<CertificadoFixture>;
    using ASSERT = Assert<CertificadoFixture>;

    public class CertificadoFixture : IFixture
    {
        public Certificado Certificado { get; set; }
    }

    public static class CertificadoMapping
    {
        public static ARRANGE Eu_tenho_um_certificado_com_valor_inicial_de_500(this ARRANGE arrange) =>
            arrange.Setup((f) => f.Certificado = Certificado.AporteInicial(Stubs.AporteInicial).Certificado);

        public static ACT Eu_faco_um_aporte_de(this ACT act, decimal valor) =>
            act.It((f) => f.Certificado.AporteExporadico(Stubs.AporteExporadico(valor)));
        
        public static ASSERT O_valor_deve_ser(this ASSERT assert, decimal valor) =>
            assert.Expect((f) => f.Certificado.Total.Should().Be(valor));
    }
}