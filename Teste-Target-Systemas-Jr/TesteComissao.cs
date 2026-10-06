internal class CalculaComissao
{
    //Esta é a variavel que guarda o nome do vendedor;
    public string Vendedor { get; set; }
    //Esta é a variavel que guarda os valores das vendas;
    public decimal ValorVenda { get; set; }
    //Esta é a variavel que guarda a data da venda;
    public string Data { get; set; }

    public static void Executar()
    {
        Console.WriteLine("Digite o valor da venda:");
        decimal valorVenda = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Digite a porcentagem da comissão (em %):");
        decimal porcentagemComissao = Convert.ToDecimal(Console.ReadLine());
        decimal comissao = CalcularComissao(valorVenda, porcentagemComissao);
        Console.WriteLine($"A comissão calculada é: {comissao:C}");
    }
}