Console.WriteLine("  ┌---------------------------------------------┐");
Console.WriteLine("  |     Escolha o teste a ser efetuado:         |");
Console.WriteLine("  ├---------------------------------------------┤");
Console.WriteLine("  │  - Teste 1 = Calculo de comissão            │");
Console.WriteLine("  │  - Teste 2 = Movimentação de estoque        │");
Console.WriteLine("  │  - Teste 3 = Calculo de juros               │");
Console.WriteLine("  └---------------------------------------------┘");
int numero = Convert.ToInt32(Console.ReadLine());

switch (numero)
{
    case 1:
        CalculaComissao.Executar();
        break;
    case 2:
        //Estoque.Executar();
        break;
    case 3:
        //CalculoDeJuros.Executar();
        break;
    default:
        Console.WriteLine("Opção inválida. Por favor, escolha um teste válido.");
        break;
}