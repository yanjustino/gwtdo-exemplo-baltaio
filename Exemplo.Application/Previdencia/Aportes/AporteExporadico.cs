using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Exemplo.Application.Previdencia.Aportes
{
   
    public class AporteExporadico: Notifiable<Notification>
    {
        public Plano Plano { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataAporte { get; private set; }

        public AporteExporadico(Plano plano, decimal valor, DateTime dataAporte)
        {
            Plano = plano;
            Valor = valor;
            DataAporte = dataAporte;
            
            AddNotifications(new AporteExporadicoContract(this));
        }
    }

    public class AporteExporadicoContract : Contract<AporteExporadico>
    {
        public AporteExporadicoContract(AporteExporadico aporteInicial)
        {
            Requires()
                .IsGreaterThan(aporteInicial.Valor, aporteInicial.Plano.ContribuicaoMinima, "aporte",
                    "Valor da contribuição mínima deve ser aportado");
        }
    }
}