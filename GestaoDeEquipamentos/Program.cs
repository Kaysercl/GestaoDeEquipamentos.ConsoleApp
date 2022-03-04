using System;

namespace GestaoDeEquipamentos
{
    internal class Program
    {

        // Váriaveis globais
        #region
        static int posicao = 0;
        static string[] defeitoEquipamento = new string[1000];
        static string[] chamadosEncerrados = new string[1000];
        static string[] nomeSolicitanteChamado = new string[1000];
        static string[] idSolicitante = new string[1000];
        static string[] telefoneSolicitante = new string[1000];
        static string[] emailSolicitante = new string[1000];
        static string[] nomeSolicitante = new string[1000];
        static string[] descricaoChamado = new string[1000];
        static string[] nomeChamado = new string[1000];
        static string[] nomeEquipamento = new string[1000];
        static decimal[] precoEquipamento = new decimal[1000];
        static string[] numeroSerieEquipamento = new string[1000];        
        static string[] nomeFabricanteEquipamento = new string[1000];
        static bool[] equipamentoemChamado = new bool[1000];
        #endregion



        // Menu inicial
        #region
        static void Main(string[] args)
        {

            DateTime[] dataDeAberturaChamado = new DateTime[1000];
            DateTime[] dataDeFabricacaoEquipamento = new DateTime[1000];
            

            string menu = "";
            while (menu != "sair")
            {
                Console.WriteLine("1-Cadastrar equipamentos");
                Console.WriteLine("2-Editar equipamentos");
                Console.WriteLine("3-Visualizar equipamentos");
                Console.WriteLine("4-Excluir equipamentos");
                Console.WriteLine("5-Abrir chamados");
                Console.WriteLine("6-Visualizar chamados");
                Console.WriteLine("7-Editar chamados");
                Console.WriteLine("8-Excluir chamados");
                Console.WriteLine("9-Registrar solicitante do chamado");
                Console.WriteLine("10-Visualizar solicitantes");
                Console.WriteLine("11-Editar solicitantes");
                Console.WriteLine("12-Excluir solicitantes");
                Console.WriteLine("13-Chamados agrupados");
                Console.WriteLine("14-Lista dos equipamentos que podem dar defeito");
                menu = Console.ReadLine();
                Console.Clear();

                switch (menu)
                {
                    case "1":
                        RegistrarEquipamento(Posicao(), dataDeAberturaChamado);
                        break;

                    case "2":
                        EditarEquipamentos(Posicao(), dataDeAberturaChamado);
                        break;

                    case "3":
                        VisualizarEquipamentos();
                        break;

                    case "4":
                        ExcluirEquipamento(Posicao(), dataDeAberturaChamado);
                        break;

                    case "5":
                        AbrirChamado(Posicao(), dataDeAberturaChamado);
                        break;

                    case "6":
                        VisualizarChamados(dataDeAberturaChamado);
                        break;

                    case "7":
                        EditarChamados(Posicao(), dataDeAberturaChamado);
                        break;

                    case "8":
                        ExcluirChamados(Posicao(), dataDeAberturaChamado);
                        break;

                    case "9":
                        RegistrarSolicitante(Posicao());
                        break;

                    case "10":
                        VisualizarSolicitantes();
                        break;

                    case "11":
                        EditarSolicitante(Posicao());
                        break;

                    case "12":
                        ExcluirSolicitante(Posicao());
                        break;

                    case "13":
                        ChamadosAgrupados();
                        break;
                    case "14":
                        ListaDeDefeitos();
                        break;

                        
                }
            }

        }
        #endregion // Menu inicial 



         // Métodos utilizados
        #region
        static void RegistrarEquipamento(int posicao, DateTime[] dataDeFabricacaoEquipamento)
        {

            Console.WriteLine("Digite o nome do equipamento: ");
            nomeEquipamento[posicao] = Console.ReadLine();
            while (nomeEquipamento[posicao].Length < 6)
            {
                Console.WriteLine("Poucos caractéres, digite um nome com no mínimo 6 caractéres");
                nomeEquipamento[posicao] = Console.ReadLine();
            }
            Console.WriteLine();
            

            Console.WriteLine("Digite o preço do equipamento: ");
            precoEquipamento[posicao] = decimal.Parse(Console.ReadLine());
            while (precoEquipamento[posicao] <= 0)
            {                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido, digite um valor maior do que 0");                
                precoEquipamento[posicao] = decimal.Parse(Console.ReadLine());
                Console.ResetColor();
            }            
            Console.WriteLine();

            
            string numeroDeSerie = "";
            int i = 0;
            
            do
            {
                Console.WriteLine("Digite o número de série do equipamento: ");
                numeroDeSerie = Console.ReadLine();

                if (numeroDeSerie.Length == 0)
                {
                    Console.WriteLine("O número de série é inválido, pois não pode ser vazio, digite outro");
                    continue;
                }
                
                else if (numeroDeSerie == numeroSerieEquipamento[i])
                {
                    Console.WriteLine("Número de série já existente, digite outro");
                    i++;
                    continue;
                }

                else
                {
                    numeroSerieEquipamento[posicao] = numeroDeSerie;
                    break;
                }
                                    
            } while (true);


            Console.WriteLine();

            Console.WriteLine("Digite a data de fabricação do equipamento: ");
            dataDeFabricacaoEquipamento[posicao] = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o nome do fabricante do equipamento: ");
            nomeFabricanteEquipamento[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("O equipamento tende a dar defeito?");
            Console.WriteLine("1 para sim e 2 para não");
            string defeito = Console.ReadLine();
            if (defeito == "1")
            {
                defeitoEquipamento[posicao] = nomeEquipamento[posicao];
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Equipamento cadastrado!");
            Console.ResetColor();
            Console.WriteLine();
            Console.Clear();

        }

        static void EditarEquipamentos(int posicao, DateTime[] dataDeFabricacaoEquipamento)
        {

            string editar = "";

            while (editar != "6")
            {
                Console.WriteLine("1-Editar o nome do equipamento: ");

                Console.WriteLine("2-Editar o preço do equipamento: ");

                Console.WriteLine("3-Editar o número de série do equipamento: ");

                Console.WriteLine("4-Editar a data de fabricação do equipamento: ");

                Console.WriteLine("5-Editar o nome do fabricante do equipamento: ");

                Console.WriteLine("6-Sair");

                editar = Console.ReadLine();

                Console.Clear();

                switch (editar)
                {
                    case "1":
                        Console.WriteLine("Digite o novo nome para o equipamento");
                        nomeEquipamento[posicao] = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Digite o novo preço do equipamento");
                        precoEquipamento[posicao] = Convert.ToDecimal(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("Digite o novo número de série do equipamento");
                        numeroSerieEquipamento[posicao] = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("Digite a nova data de fabricação do equipamento");
                        dataDeFabricacaoEquipamento[posicao] = Convert.ToDateTime(Console.ReadLine());
                        break;

                    case "5":
                        Console.WriteLine("Digite o novo nome do fabricante do equipamento");
                        nomeFabricanteEquipamento[posicao] = Console.ReadLine();
                        break;
                }

            }


        }

        static void VisualizarEquipamentos()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (nomeEquipamento[i] != null)
                {
                    Console.WriteLine(i + " - " + nomeEquipamento[i] + " / " + precoEquipamento[i] + " / " + numeroSerieEquipamento[i] + " / " 
                        + nomeFabricanteEquipamento[i]);
                }

            }
            Console.ReadLine();
        }

        static void ExcluirEquipamento(int posicao, DateTime[] dataDeFabricacaoEquipamento)
        {
            if (equipamentoemChamado[posicao] != null)
            {
                Console.WriteLine("Exclua o chamado primeiro");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                defeitoEquipamento[posicao] = null;
                nomeEquipamento[posicao] = null;
                precoEquipamento[posicao] = 0;
                dataDeFabricacaoEquipamento[posicao] = DateTime.MinValue;
                nomeFabricanteEquipamento[posicao] = null;
                numeroSerieEquipamento[posicao] = null;
            }

        }

        static void AbrirChamado(int posicao, DateTime[] dataDeAberturaChamado)
        {
            Console.WriteLine("Digite o titulo do chamado");
            nomeChamado[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Descreva o chamado");
            descricaoChamado[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite qual o nome do equipamento atribuido a este chamado");
            nomeEquipamento[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite a data de abertura do chamado");
            dataDeAberturaChamado[posicao] = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o nome do solicitante neste chamado");
            nomeSolicitanteChamado[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.Clear();
        }

        static void VisualizarChamados(DateTime[] dataDeAbeturaChamado)
        {

            for (int i = 0; i < 1000; i++)
            {
                if (nomeChamado[i] != null)
                {
                    Console.WriteLine(i + " - " + nomeChamado[i] + " / " + descricaoChamado[i] + " / " + nomeEquipamento[i] + " / " +
                        dataDeAbeturaChamado[i] + " / " + nomeSolicitante[i]);
                }

            }
            Console.ReadLine();
            Console.Clear();

        }

        static void EditarChamados(int posicao, DateTime[] dataDeAberturaChamado)
        {
            string editar = "";
            while (editar != "0")
            {
                Console.WriteLine("1-Editar o nome do chamado: ");

                Console.WriteLine("2-Editar a descrição do chamado: ");

                Console.WriteLine("3-Editar o nome do equipamento em chamado: ");

                Console.WriteLine("4-Editar a data de abertura do chamado: ");

                Console.WriteLine("5-Editar solicitante do chamado: ");
              
                Console.WriteLine("0-Sair");

                editar = Console.ReadLine();

                Console.Clear();

                switch (editar)
                {
                    case "1":
                        Console.WriteLine("Digite o novo nome do chamado");
                        nomeChamado[posicao] = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Digite a nova descrição do chamado");
                        descricaoChamado[posicao] = Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("Digite o novo nome do equipamento em chamado");
                        nomeEquipamento[posicao] = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("Digite a nova data de abertura do chamado");
                        dataDeAberturaChamado[posicao] = Convert.ToDateTime(Console.ReadLine());
                        break;

                    case "5":
                        Console.WriteLine("Digite o novo solicitante do chamado");
                        nomeSolicitanteChamado[posicao] = Console.ReadLine();
                        break;
                   
                }
            }
        }

        static void ExcluirChamados(int posicao, DateTime[] dataDeAberturaChamado)
        {
            chamadosEncerrados[posicao] = nomeChamado[posicao];
            nomeChamado[posicao] = null;
            descricaoChamado[posicao] = null;
            nomeEquipamento[posicao] = null;
            dataDeAberturaChamado[posicao] = DateTime.MinValue;
        }

        static void RegistrarSolicitante(int posicao)

        {
            Console.WriteLine("Digite o nome do solicitante");
            nomeSolicitante[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o e-mail do solicitante");
            emailSolicitante[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o telefone do solicitante");
            telefoneSolicitante[posicao] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o ID do solicitante");
            idSolicitante[posicao] = Console.ReadLine();
            Console.WriteLine();
        }

        static void VisualizarSolicitantes()


        {

            for (int i = 0; i < 1000; i++)
            {
                if (nomeSolicitante[i] != null)
                {
                    Console.WriteLine(i + " - " + nomeSolicitante[i] + " / " + emailSolicitante[i] + " - " +
                        telefoneSolicitante[i] + " / " + idSolicitante[i]);
                }
            }
            Console.ReadLine();

        }

        static void EditarSolicitante(int posicao)
        {
            string editar = "";

            while (editar != "5")
            {
                Console.WriteLine("1-Editar o nome do solicitante");

                Console.WriteLine("2-Editar o email do solicitante");

                Console.WriteLine("3-Editar o telefone do solicitante");

                Console.WriteLine("4-Editar o ID do solicitante");

                Console.WriteLine("5-Sair");

                editar = Console.ReadLine();

                Console.Clear();

                switch (editar)
                {
                    case "1":
                        Console.WriteLine("Digite o novo nome do solicitante");
                        nomeSolicitante[posicao] = Console.ReadLine();
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("Digite o novo email do solicitante");
                        emailSolicitante[posicao] = Console.ReadLine();
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("Digite o novo telefone do solicitante");
                        telefoneSolicitante[posicao] = Console.ReadLine();
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine("Digite o novo ID do solicitante");
                        idSolicitante[posicao] = Console.ReadLine();
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void ExcluirSolicitante(int posicao)
        {
            nomeSolicitante[posicao] = null;
            emailSolicitante[posicao] = null;
            telefoneSolicitante[posicao] = null;
            idSolicitante[posicao] = null;
        }

        static void ListaDeDefeitos()
        {
            for (int i = 0; i < defeitoEquipamento.Length; i++)
            {
                Console.WriteLine(defeitoEquipamento[i]);
            }
            Console.ReadLine(); 
        }

        static void ChamadosAgrupados()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Chamados encerrados: ");
            for (int i = 0; i < chamadosEncerrados.Length; i++)
            {
                if (nomeChamado == null)
                    break;
                else
                {
                    Console.WriteLine(chamadosEncerrados[i]);
                }
                
            }

           
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chamados em abertos:");
                for (int i = 0; i < nomeChamado.Length; i++)
                {
                    if (chamadosEncerrados == null)
                        break;
                    else
                    {
                        Console.WriteLine(nomeChamado[i]);
                    }
                        
                }
                Console.ResetColor();
            }
           
        }

        static string MenuInicial()
        {
            string opcaoMenu;
            Console.WriteLine("Escolha a opcao desejada:\n");
            Console.WriteLine("1- Registrar equipamento\n2-Visualizar equipamentos\n3-Editar equipamento\n" +
                 "4-Excluir equipamento");
            opcaoMenu = Console.ReadLine();
            return opcaoMenu;
        }

        static int Posicao()
        {
            //int posicao = 0;
            //Console.WriteLine("Escreva a posição na array");
            //posicao = int.Parse(Console.ReadLine()); 
            return posicao++;
        }
        #endregion   // Métodos utilizados

    }
}
