using System.Text.Json;

internal class CalculaComissao
{
    
    //Esta é a variavel que guarda o nome do vendedor;
    public required string Vendedor { get; set; }
    //Esta é a variavel que guarda os valores das vendas;
    public decimal ValorVenda { get; set; }
    //Esta é a variavel que guarda a data da venda;
    public required string Data { get; set; }

    public static void Executar()
    {
        // Caminho do arquivo JSON contendo os dados das vendasb 
        string caminhoArquivo = Path.Combine(
            AppContext.BaseDirectory,"vendas.json");
        
        // Verifica se o arquivo existe
        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo 'vendas.json' não encontrado.");
            return;
        }

        //Se o arquivo existe, lê o conteudo do arquivo e desserializa para uma lista de objetos CalculaComissao
        string json = File.ReadAllText(caminhoArquivo);
        var dados = JsonSerializer.Deserialize<vendasDTO>(json);
        var vendas = dados?.vendas ?? new List<ResultadoVendasDTO>();

        //Aplicação de regras de negócio com LINQ
        var relatorio = vendas
            .GroupBy(v => v.vendedor)
            .Select(g => new
             {
                 Vendedor = g.Key,
                 TotalVendas = g.Sum(v => v.valor),
                 TotalComissao = g.Sum(v => CalcularComissao(v.valor))
             }).ToList();

        // Exibe os resultados das comissões no console
        foreach (var item in relatorio)
        {
            Console.WriteLine($"Vendedor: {item.Vendedor}");
            Console.WriteLine($"Total de Vendas: {item.TotalVendas}");
            Console.WriteLine($"Total de Comissão: {item.TotalComissao}");
            Console.WriteLine();
        }
    }

    private static decimal CalcularComissao(decimal valorVenda)
    {
        if(valorVenda <= 100)
        {
            return valorVenda * 0.00m; // 0% de comissão
        }
        else if (valorVenda <= 500)
        {
            return valorVenda * 0.01m; // 1% de comissão
        }
        else
        {
            return valorVenda * 0.05m; // 5% de comissão
        }
    }
}