using System;

namespace TesteSinquia
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculoParcela calculoParcela = new CalculoParcela
            {
                Emprestimo = 100000,
                NumParcelas = 10,
                TaxaJuros = 1,
                PeriodoParcela = 30

            };
            calculoParcela.Calcular();
        }
    }
}
