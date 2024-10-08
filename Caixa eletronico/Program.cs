using System;
using System.Threading;

bool termino = false;
double depositoC, saqueC, transC, transP, transCD;
double saldoC = 0;
double saldoP = 0;
double saldoCD = 0;
string extratoC = "";
double tentativa = 0;
double taxa = 0.005;
double taxat;
double taxaP = 0.05;
double taxaCD = 0.093;

Console.Clear();
Console.WriteLine("----- CAIXA ELETRÔNICO -----");
Console.WriteLine("Insira seu Cadastro");
Console.Write("CPF: ");
string cpf = Console.ReadLine();

Console.Write("Senha (6 dígitos): ");
string senha = Console.ReadLine();

if (senha.Length != 6)
{
    Console.WriteLine("A senha deve conter 6 dígitos.");
    return;
}

while (!termino)
{
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
        Thread.Sleep(1500);
        continue;
    }

    switch (opçãoC)
    {
        case 1:
            Console.Write("Valor do Depósito: ");
            if (!double.TryParse(Console.ReadLine(), out depositoC))
            {
                Console.WriteLine("Valor Inválido! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
            }
            saldoC += depositoC;
            extratoC += $"Depósito: R${depositoC:F2}\n";
            break;

        case 2:
            bool acerto = false;

            while (!acerto)
            {
                if (tentativa >= 3)
                {
                    Console.WriteLine("Número de tentativas excedidas.");
                    Console.WriteLine("CONTA BLOQUEADA!");
                    return;
                }

                Console.Write("Digite seu CPF: ");
                string tcpf = Console.ReadLine();
                if (tcpf != cpf)
                {
                    Console.WriteLine("Erro! CPF digitado não confere");
                    tentativa++;
                    Thread.Sleep(1500);
                    continue;
                }

                Console.Write("Digite sua Senha: ");
                string tsenha = Console.ReadLine();
                if (tsenha != senha)
                {
                    Console.WriteLine("Erro! Senha digitada não confere");
                    tentativa++;
                    Thread.Sleep(1500);
                    continue;
                }
                acerto = true;
            }

            Console.Write("Valor do Saque: ");
            if (!double.TryParse(Console.ReadLine(), out saqueC))
            {
                Console.WriteLine("Valor Inválido! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
            }
            if (saqueC > saldoC)
            {
                Console.WriteLine("Saldo Insuficiente! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
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
                extratoC += $"Saque: R${saqueC:F2}\n";
            }
            break;

        case 3:
            Console.WriteLine($"Saldo da Conta Corrente: R${saldoC:F2}");
            Console.WriteLine($"Saldo da Conta Poupança: R${saldoP:F2}");
            Console.WriteLine($"Saldo da Conta CDB: R${saldoCD:F2}");
            Console.ReadLine();
            break;

        case 4:
            Console.WriteLine("Extrato:");
            Console.WriteLine(extratoC);
            Console.ReadLine();
            break;

        case 5:
            Console.Write("Valor da Transferência: ");
            if (!double.TryParse(Console.ReadLine(), out transC))
            {
                Console.WriteLine("Valor Inválido! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
            }
            if (transC > saldoC)
            {
                Console.WriteLine("Saldo Insuficiente para Transferência! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
            }
            else
            {
                taxat = transC * taxa;
                saldoC -= (transC + taxat);
                extratoC += $"Transferência: R${transC:F2}\n";
                extratoC += $"Taxa Transferência: R${taxat:F2}\n";
                Console.WriteLine("Transferência realizada com sucesso!");
                Thread.Sleep(1500);
            }
            break;

        case 6:
            Console.Clear();
            Console.WriteLine("Central de Investimentos");
            Console.WriteLine("1 - Poupança");
            Console.WriteLine("2 - CDB");
            Console.WriteLine("3 - Sair");

            if (!double.TryParse(Console.ReadLine(), out double tipoinvestimento))
            {
                Console.WriteLine("Valor Inválido! Tente Novamente.");
                Thread.Sleep(1500);
                continue;
            }
            switch (tipoinvestimento)
            {
                case 1:
                    Console.Write("Valor que deseja investir na Poupança: ");
                    if (!double.TryParse(Console.ReadLine(), out transP))
                    {
                        Console.WriteLine("Valor Inválido! Tente Novamente.");
                        Thread.Sleep(1500);
                        continue;

                    }
                    if (transP > saldoC)
                    {
                        Console.WriteLine("Saldo Insuficiente! Tente Novamente.");
                        Thread.Sleep(1500);
                        continue;
                    }
                    saldoP = transP + (transP * taxaP);
                    Console.WriteLine($"Valor Poupança em 1 mês: R${saldoP:F2}");
                    Thread.Sleep(1500);
                    saldoC -= transP;
                    extratoC += $"Poupança: R${transP:F2}\n";

                    break;

                case 2:
                    Console.Write("Valor que deseja investir em CDB: ");
                    if (!double.TryParse(Console.ReadLine(), out transCD))
                    {
                        Console.WriteLine("Valor Inválido! Tente Novamente.");
                        Thread.Sleep(1500);
                        continue;
                    }
                    if (transCD > saldoC)
                    {
                        Console.WriteLine("Saldo Insuficiente! Tente Novamente.");
                        Thread.Sleep(1500);
                        continue;
                    }
                    saldoCD = transCD + (transCD * taxaCD);
                    Console.WriteLine($"Valor CDB em 1 mês: R${saldoCD}");
                    saldoC -= transCD;
                    extratoC += $"CDB: R${transCD:F2}\n";

                    Thread.Sleep(1500);
                    break;
                case 3:
                    break;

                default:
                    Console.WriteLine("Opção Inválida! Tente Novamente.");
                    Thread.Sleep(1500);
                    break;
            }
            break;

        case 7:
            Console.WriteLine("Obrigado por usar o caixa eletrônico!");
            termino = true;
            break;

        default:
            Console.WriteLine("Opção Inválida! Tente Novamente.");
            Thread.Sleep(1500);
            break;
    }
}
