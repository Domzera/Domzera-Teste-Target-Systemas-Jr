using System.Text.Json;

internal class Estoque
{

    internal class EstoqueDTO
    {
        public int? movimentação { get; set; }
        public string? tipo { get; set; }
        public int codigoProduto { get; set; }
        public string? descricaoProduto { get; set; }
        public int estoque { get; set; }
    }
    internal static void Executar()
    {
        // Cria um objeto dos produtos com as informações do desafio.
        List<EstoqueDTO> movimenta = new List<EstoqueDTO>();

        //Salva o caminho do json para a futura escolha dos produtos
        string caminhoArquivo = Path.Combine(
            AppContext.BaseDirectory, "estoque.json");

        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo 'estoque.json' não encontrado!");
            return;
        }

        // Se o arquivo exitir, o programa o lê.
        string json = File.ReadAllText(caminhoArquivo);
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

        foreach (var item in tabela)
        {
            EstoqueDTO p1 = new EstoqueDTO
            {
                codigoProduto = item.codigo,
                descricaoProduto = item.descricao,
                estoque = item.estoqe
            };
            movimenta.Add(p1);
        }

        foreach (var item in movimenta)
        {
            Console.WriteLine($"Código de produto: {item.codigoProduto}");
            Console.WriteLine($"Código de produto: {item.descricaoProduto}");
            Console.WriteLine($"Código de produto: {item.estoque}\n");
        }
        Console.WriteLine("\nDigite V para venda ou E para entrada?\n");
        string escolha = Console.ReadLine()!;
        int codigo = 0;

        switch (escolha)
        {
            case "v" or "V":
                Console.WriteLine("\nQual produto você pretende vender?(Use o código do produto)");
                codigo = Convert.ToInt32(Console.ReadLine());
                if (codigo >= 101 || codigo <= 105)
                {
                    Console.WriteLine("\nQual quantidade pretende vender?");
                    var quant = Convert.ToInt32(Console.ReadLine());
                    
                    if (quant < 0) quant = quant * -1;

                    EstoqueDTO busca = movimenta.Find(p => p.codigoProduto == codigo)!;

                    if(busca.estoque < quant)
                    {
                        Console.WriteLine("\nQuantidade em estoque insuficiente para esta venda.\n");
                        break;
                    }
                    else
                    {
                        busca.estoque = busca.estoque - quant;
                        busca.movimentação = busca.movimentação =+ 1;
                        busca.tipo = "Venda";
                    }
                    foreach (var item in movimenta)
                    {
                        if (item.tipo != null)
                        {
                            Console.WriteLine($"Quantas movimentações: {item.movimentação}");
                            Console.WriteLine($"Tipo de movimentação: {item.tipo}");
                        }
                        Console.WriteLine($"Código de produto: {item.codigoProduto}");
                        Console.WriteLine($"Descrição do produto: {item.descricaoProduto}");
                        Console.WriteLine($"Estoque do produto: {item.estoque}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Digite um código de produto valido.");
                }

                break;
            case "e" or "E":
                Console.WriteLine("\nQual produto você pretende dar entrada?(Use o código do produto)");
                codigo = Convert.ToInt32(Console.ReadLine());
                if (codigo >= 101 || codigo <= 105)
                {
                    Console.WriteLine("\nQual quantidade da entrada?");
                    var quant = Convert.ToInt32(Console.ReadLine());

                    if (quant < 0) quant = quant * -1;

                    EstoqueDTO busca = movimenta.Find(p => p.codigoProduto == codigo)!;

                    busca.estoque = busca.estoque + quant;
                    busca.movimentação = busca.movimentação = +1;
                    busca.tipo = "Entrada";

                    foreach (var item in movimenta)
                    {
                        if (item.tipo != null)
                        {
                            Console.WriteLine($"Quantas movimentações: {item.movimentação}");
                            Console.WriteLine($"Tipo de movimentação: {item.tipo}");
                        }
                        Console.WriteLine($"Código de produto: {item.codigoProduto}");
                        Console.WriteLine($"Descrição do produto: {item.descricaoProduto}");
                        Console.WriteLine($"Estoque do produto: {item.estoque}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Digite um código de produto valido.");
                }

                break;
            default:
                Console.WriteLine("Escolha uma opção valida. v V ou e E\n");
                break;
        }
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

