using System.Threading.Tasks;

namespace Exemplo.Application.Previdencia.Aportes
{
    public class RegistroAporte
    {
        public Task<ResultadoAporte> Inicial(AporteInicial aporte)
        {
            return Task.FromResult(
                aporte.IsValid ? Certificado.AporteInicial(aporte) : new ResultadoAporte(aporte));
        }
        
        public Task<ResultadoAporte> Exporadico(Certificado certificado, AporteExporadico aporte)
        {
            return Task.FromResult(
                aporte.IsValid ? certificado.AporteExporadico(aporte) : new ResultadoAporte(aporte));
        }        
    }
}