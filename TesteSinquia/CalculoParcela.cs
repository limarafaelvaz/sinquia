using System;
using System.Collections.Generic;
using System.Text;

namespace TesteSinquia
{
    public class CalculoParcela
    {
        private decimal emprestimo;
        private int numParcelas;
        private double taxaJuros;
        private int periodoParcela;

        public decimal Emprestimo
        {
            get { return emprestimo; }
            set { emprestimo = value; }
        }
        public int NumParcelas
        {
            get { return numParcelas; }
            set { numParcelas = value; }
        }
        public double TaxaJuros
        {
            get { return taxaJuros; }
            set { taxaJuros = value; }
        }
        public int PeriodoParcela
        {
            get { return periodoParcela; }
            set { periodoParcela = value; }
        }

        public void Calcular()
        {
            if (Emprestimo <= 0) throw new ArgumentException("Empréstimo deve ser maior do que 0");
            if (NumParcelas <= 0) throw new ArgumentException("Número de parcelas deve ser maior do que 0");

            System.Text.StringBuilder imprimir = new System.Text.StringBuilder();
            StringBuilder linha = GetLinha();

            for (int i = 1; i <= NumParcelas; i++)
            {
                //linha apenas para facilitar visualização.
                imprimir.AppendLine(linha.ToString());

                decimal jurosLinear = GetJurosLinear(i);
                decimal jurosExponencial = GetJurosExponencial(i);

                imprimir.AppendLine(" Parcela: " + i);
                imprimir.AppendLine(String.Format(" Principal Parcela: {0:0.##} ", GetValorParcela()));
                imprimir.AppendLine(String.Format(" Juros Linear: {0:0.##}", jurosLinear));
                imprimir.AppendLine(String.Format(" Total Parcela Linear: {0:0.##}", (GetValorParcela() + jurosLinear)));
                imprimir.AppendLine(String.Format(" Juros Exponencial: {0:0.##}", jurosExponencial));
                imprimir.AppendLine(String.Format(" Total Parcela Exponencial: {0:0.##}", (GetValorParcela() + jurosExponencial)));

                imprimir.AppendLine(linha.ToString());
                imprimir.AppendLine();
            }

            Console.WriteLine(imprimir.ToString());
        }
        private int GetQtdDiasDesdeInicio(int i)
        {
            return PeriodoParcela * i;
        }
        private StringBuilder GetLinha()
        {
            System.Text.StringBuilder linha = new System.Text.StringBuilder();

            for (int k = 0; k < 50; k++)
            {
                linha.Append("-");
            }

            return linha;
        }
        private decimal GetValorParcela()
        {
            return Emprestimo / NumParcelas;
        }
        private decimal GetJurosLinear(int numParcela)
        {
            if (PeriodoParcela == 0) throw new DivideByZeroException("Periodo da Parcela deve ser maior do que 0");
            return GetValorParcela() * Convert.ToDecimal(TaxaJuros) * GetQtdDiasDesdeInicio(numParcela) / (100 * PeriodoParcela);
        }
        private decimal GetJurosExponencial(int numParcela)
        {
            if (PeriodoParcela == 0) throw new DivideByZeroException("Periodo da Parcela deve ser maior do que 0");
            return GetValorParcela() * Convert.ToDecimal((Math.Pow((1 + TaxaJuros / 100), (GetQtdDiasDesdeInicio(numParcela) / PeriodoParcela)) - 1));
        }
    }
}
