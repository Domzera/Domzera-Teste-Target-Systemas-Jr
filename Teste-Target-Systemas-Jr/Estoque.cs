using System.Text.Json;

internal class Estoque
{
    internal static void Executar()
    {
        //Abre o json para a escolha dos produtos
        string caminhoArquivo = Path.Combine(
            AppContext.BaseDirectory, "estoque.json");

        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo 'estoque.json' não encontrado!");
            return;
        }

        // Se o arquivo exitir, o programa o lê.
        string json = File.ReadAllText(caminhoArquivo);
//        Console.WriteLine(json.Substring(0, json.Length));
        // Logo em seguida deserializa o arquivo e salva o resultado em dados
        var dados = JsonSerializer.Deserialize<VendasDTO>(json);
        // Monta uma lista de retornoVendas com os dados
        var estoque = dados?.estoque ?? new List<RetornoVendasDTO>();

        var tabela = estoque
            .Select(p => new
            {
                codigo = p.codigoProduto,
                descricao = p.descricaoProduto,
                estoqe = p.estoque
            });

        foreach(var item in tabela)
        {
            Console.WriteLine($"Código de produto: {item.codigo }");
            Console.WriteLine($"Código de produto: {item.descricao}");
            Console.WriteLine($"Código de produto: {item.estoqe}\n");
        }
        Console.WriteLine("Você quer fazr uma venda(v) ou dar entrada(e)?");
        string escolha = Console.ReadLine()!;

        switch (escolha)
        {
            case "v" or "V":
                Console.WriteLine("Qual produto você pretende vender?(Use o código do produto)");
                int codigo = Convert.ToInt32(Console.ReadLine());
                Venda(codigo, tabela);
                break;
            case "e" or "E":
                //Console.WriteLine("Qual produto você pretende dar entrada?");
                //codigo = Convert.ToInt32(Console.ReadLine());
                Entrada(tabela);
                break;
            default:
                Console.WriteLine("Escolha uma opção valida. v V ou e E\n");
                break;
        }
    }

    private static void Entrada(IEnumerable<object> tabela)
    {
        Console.WriteLine("Qual a descrição do produto")
    }

    private static void Venda(int codigo, IEnumerable<object> tabela)
    {
        throw new NotImplementedException();
    }
}

internal class VendasDTO
{
    public List<RetornoVendasDTO>? estoque { get; set; }
}

internal class RetornoVendasDTO
{
    public int codigoProduto { get; set; }
    public string? descricaoProduto { get; set; }
    public int estoque { get; set; }
}