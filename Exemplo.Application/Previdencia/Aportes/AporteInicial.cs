using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Exemplo.Application.Previdencia.Aportes
{
    public class AporteInicial: Notifiable<Notification>
    {
        public Plano Plano { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataAporte { get; private set; }

        public AporteInicial(Plano plano, decimal valor, DateTime dataAporte)
        {
            Plano = plano;
            Valor = valor;
            DataAporte = dataAporte;
            
            AddNotifications(new AporteContract(this));
        }
    }

    public class AporteContract : Contract<AporteInicial>
    {
        public AporteContract(AporteInicial aporteInicial)
        {
            Requires()
                .IsGreaterThan(aporteInicial.Valor, aporteInicial.Plano.ContribuicaoInicialMinima, "aporte",
                "Valor da contribuição mínima deve ser aportado");
        }
    }
}