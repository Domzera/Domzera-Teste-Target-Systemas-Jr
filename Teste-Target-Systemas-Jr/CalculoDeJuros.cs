using System.Globalization;
using System.Numerics;

internal class CalculoDeJuros
{
    internal static void Executar()
    {
        Console.WriteLine("Qual o valor do titulo?");
        double valor = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\nQual foi a data do vencimento?(formato DD/MM/AAAA):");
        string input = Console.ReadLine()!;

        string formato = "dd/MM/yyyy";
        CultureInfo tipoBr = new CultureInfo("pt-br");

        int totalDias = 0;

        if (DateTime.TryParseExact(input, formato, tipoBr, DateTimeStyles.None, out DateTime dataCerta));

        if (dataCerta >= DateTime.Today)
        {
            Console.WriteLine("O boleto não venceu!");
        }
        else
        {
            TimeSpan dias = DateTime.Today - dataCerta;
            totalDias = dias.Days;
        }



        Console.WriteLine($"Quantidade de dias de atraso: {totalDias}");

        var jurosSimples = (valor * .025) * totalDias;

        Console.WriteLine($"\nJuros simples: {jurosSimples}%");
        Console.WriteLine($"\nO valor total da divida é de : R$ {valor + jurosSimples}\n");

        double jurosCompostos =  Math.Pow(1.025, totalDias);

        Console.WriteLine($"\nJuros compostos: {jurosCompostos:F2}%");
        Console.WriteLine($"\nO valor total da divida é de : R$ {valor * jurosCompostos:F2}\n");
    }
}