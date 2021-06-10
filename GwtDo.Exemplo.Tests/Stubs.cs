using System;
using Exemplo.Application.Previdencia.Aportes;

namespace GwtDo.Exemplo.Tests
{
    public static class Stubs
    {
        public static Plano Plano0500 => 
            new Plano(1000, "Plano stub", 0, 500, 500);
        public static AporteInicial AporteInicial => 
            new AporteInicial(Stubs.Plano0500, 500, DateTime.Today);

        public static AporteExporadico AporteExporadico(decimal valor) =>
            new AporteExporadico(Stubs.Plano0500, valor, DateTime.Today);
    }
}