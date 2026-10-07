int numero = 0;
do
{
    Console.WriteLine("  ┌---------------------------------------------┐");
    Console.WriteLine("  |     Escolha o teste a ser efetuado:         |");
    Console.WriteLine("  ├---------------------------------------------┤");
    Console.WriteLine("  │  - Gigite 1 = Calculo de comissão           │");
    Console.WriteLine("  │  - Gigite 2 = Movimentação de estoque       │");
    Console.WriteLine("  │  - Gigite 3 = Calculo de juros              │");
    Console.WriteLine("  │  - Gigite 4 = SAIR                          │");
    Console.WriteLine("  └---------------------------------------------┘");
    numero = Convert.ToInt32(Console.ReadLine());

    switch (numero)
    {
        case 1:
            CalculaComissao.Executar();
            break;
        case 2:
            Estoque.Executar();
            break;
        case 3:
            //CalculoDeJuros.Executar();
            break;
        case 4:
            Console.WriteLine("Volte sempre!");
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, escolha um teste válido.\n 1 - 2 - 3 - 4");
            break;
    }
} while (numero!=4);