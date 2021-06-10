using Exemplo.Application.Previdencia.Aportes;
using Gwtdo;

namespace GwtDo.Exemplo.Tests.Previdencia.AportesInicial
{
    public class AporteInicialFixture: IFixture
    {
        public AporteInicial AporteInicial { get; set; }
        public Plano Plano { get; set; }
        public RegistroAporte RegistroAporte { get; set; }
        public ResultadoAporte Resultado { get; set; }

        public AporteInicialFixture()
        {
            RegistroAporte = new RegistroAporte();
        }
    }
}