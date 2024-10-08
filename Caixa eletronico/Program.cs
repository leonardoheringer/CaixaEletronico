using System;
using System.Security.AccessControl;




bool termino = false;
double depositoC, depositoP, saqueC, saqueP, transC, transP;
double saldoC = 0;
double saldoP = 0;
string extratoC = "";
string extratoP = "";
double tentativa = 0;
double taxa = 0.005;
double taxat; 

Console.Clear();
Console.WriteLine("-----CAIXA ELETRONICO-----");
Console.WriteLine("Insira seu Cadastro");
Console.WriteLine("CPF: ");
string cpf = Console.ReadLine();

Console.WriteLine("Senha (6 digitos): ");
string senha = Console.ReadLine();

  int caracteres = senha.Length;

        if (caracteres != 6)
        {
            Console.WriteLine("A senha deve conter 6 dígitos.");
            return;
        }


while (!termino)
{
    Console.Clear();
    Console.WriteLine("Selecione o Tipo de conta");
    Console.WriteLine("1 - Conta Corrente");
    Console.WriteLine("2 - Conta Poupança");
    Console.WriteLine("3 - Sair");

    if (!double.TryParse(Console.ReadLine(), out double tipoconta))
    {
        Console.WriteLine("Valor Inválido! Tente Novamente.");
        continue;
    }

    if(tipoconta == 1)
    {
    
            while (true)
            {
                bool acerto = false;
                
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Depósito");
                Console.WriteLine("2 - Saque");
                Console.WriteLine("3 - Saldo");
                Console.WriteLine("4 - Extrato");
                Console.WriteLine("5 - Transferência");
                Console.WriteLine("6 - Investimentos");
                Console.WriteLine("7 - Sair");

                if (!double.TryParse(Console.ReadLine(), out double opçãoC))
                {
                    Console.WriteLine("Valor Inválido! Tente Novamente.");
                    continue;
                }

                switch (opçãoC)
                {
                    
                    case 1:
                        Console.WriteLine("Valor do Depósito:");
                        if (!double.TryParse(Console.ReadLine(), out depositoC))
                        {
                            Console.WriteLine("Valor Inválido! Tente Novamente.");
                            continue;
                        }
                        saldoC += depositoC;
                        extratoC += $"Depósito: R${depositoC}\n";
                        break;

                    case 2:
                    while(acerto == false){
                      
                    if(tentativa > 3){
                    Console.WriteLine("Numero de tentativas excedidas. ");
                    Console.WriteLine("CONTA BLOQUEADA! ");
                    return;
                    }

                    Console.WriteLine("Digite seu CPF: ");
                    string tcpf = Console.ReadLine();
                    if (tcpf != cpf){
                       Console.WriteLine("Erro! CPF digitado não confere");
                       Thread.Sleep(1500);
                        Console.Clear();
                      tentativa ++;
                      continue;
                      
                    }

                     Console.WriteLine("Digite sua Senha: ");
                    string tsenha = Console.ReadLine();
                    if (tsenha != senha){
                       Console.WriteLine("Erro! Senha digitada não confere");
                       Thread.Sleep(1500);
                        Console.Clear();
                      tentativa ++;
                      continue;
                     
                    }
                    acerto = true;
                
                
                }
                        Console.WriteLine("Valor do Saque:");
                        if (!double.TryParse(Console.ReadLine(), out saqueC))
                        {
                            Console.WriteLine("Valor Inválido! Tente Novamente.");
                            continue;
                        }
                        if (saqueC > saldoC)
                        {
                            Console.WriteLine("Saldo Insuficiente! Tente Novamente.");
                        }
                        if (saqueC > 2000)
                        {
                            Console.WriteLine("Limite Atingido! Limite saque R$: 2000.");
                            Thread.Sleep(1500);
                      continue;
                        }
                        else
                        {
                            saldoC -= saqueC;
                            extratoC += $"Saque: R${saqueC}\n";
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Saldo da Conta Corrente: R${saldoC}");
                        Thread.Sleep(1500);
                        break;

                    case 4:
                        Console.WriteLine("Extrato:");
                        Console.WriteLine(extratoC);
                        Thread.Sleep(1500);
                        break;

                    case 5:
                        Console.WriteLine("Valor da Transferência:");
                        if (!double.TryParse(Console.ReadLine(), out transC))
                        {
                            Console.WriteLine("Valor Inválido! Tente Novamente.");
                            continue;
                        }
                        if (transC > saldoC)
                        {
                            Console.WriteLine("Saldo Insuficiente para Transferência! Tente Novamente.");
                        }
                        else
                        {
                            taxat = transC * taxa ;
                            saldoC -= (transC+taxat);
                            extratoC += $"Transferência: R${transC}\n";
                            extratoC += $"Taxa Transferencia: R${taxat}\n";
                            Console.WriteLine($"Valor da Taxa {taxa}");
                        }
                        Console.WriteLine($"Valor da Taxa {taxa}");
                        Thread.Sleep(1500);
                        break;
case 6:
 Console.Clear();
    Console.WriteLine("Central Investimentos");
    Console.WriteLine("1 - Poupança");
    Console.WriteLine("2 - CDB");
    Console.WriteLine("3 - Sair");

    if (!double.TryParse(Console.ReadLine(), out double tipoinvestimento))
    {
        Console.WriteLine("Valor Inválido! Tente Novamente.");
        continue;
    }
    switch(tipoinvestimento){
        case 1:
        Console.WriteLine("Valor a ser Investido na Poupança:");
        if (!double.TryParse(Console.ReadLine(), out transP))
                        {
                            Console.WriteLine("Valor Inválido! Tente Novamente.");
                            continue;
                        }
                        
         Console.WriteLine($"Valor Poupança em 1 mes {}");
        break;
        case 2:
        break;
    }
break;
                    case 7:
                        goto case 3; // Sair do gerenciamento da conta corrente

                    default:
                        Console.WriteLine("Opção Inválida! Tente Novamente.");
                        break;
                }
            }
    
        
        }
        if(tipoconta == 2){
            Console.WriteLine("Obrigado!");
            termino = true;
            break;

        }
        else{
            Console.WriteLine("Opção Inválida! Tente Novamente.");
            break;
    
}
}

