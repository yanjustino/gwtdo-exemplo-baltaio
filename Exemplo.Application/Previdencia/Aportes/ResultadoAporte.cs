using Flunt.Notifications;

namespace Exemplo.Application.Previdencia.Aportes
{
    public class ResultadoAporte: Notifiable<Notification>
    {
        public Certificado Certificado { get; private set; }

        public ResultadoAporte(AporteInicial aporte)
        {
            if (!aporte.IsValid)
                AddNotifications(aporte.Notifications);
            Certificado = default;
        }
        
        public ResultadoAporte(AporteExporadico aporte)
        {
            if (!aporte.IsValid)
                AddNotifications(aporte.Notifications);
            Certificado = default;
        }        
        
        public ResultadoAporte(Certificado certificado)
        {
            Certificado = certificado;
        }        
    }
}