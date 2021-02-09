using NUnit.Framework;
using System;
using TesteSinquia;

namespace ProjetoTeste
{
    public class TesteCalculo
    {
        public CalculoParcela calculoParcela;

        [SetUp]
        public void Setup()
        {
            calculoParcela = new CalculoParcela
            {
                Emprestimo = 100000,
                NumParcelas = 10,
                TaxaJuros = 1,
                PeriodoParcela = 30
            };
        }

        [Test]
        public void TestarNumeroParcelasZerada()
        {
            calculoParcela.NumParcelas = 0;
            Assert.Throws<ArgumentException>(() => calculoParcela.Calcular());
        }

        [Test]
        public void TesteValorZeroEmprestimo()
        {            
            calculoParcela.Emprestimo = 0;
            Assert.Throws<ArgumentException>(() => calculoParcela.Calcular());
        }

        [Test]
        public void TestarEmprestimoDezMil()
        {
            try
            {
                calculoParcela.Calcular();
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}