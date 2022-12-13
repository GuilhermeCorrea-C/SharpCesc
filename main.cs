using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    public static void Main(string[] args)
    {
        Servico servico = new Servico();
        string opcao = "";
        servico = CadastrarServico(servico);
        Console.WriteLine(servico.Descricao);
        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine("===== Menu de Opções =====\n");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Cadastrar Pessoa");
            Console.WriteLine("2 - Consultar Cadastro");
            Console.WriteLine("3 - Relatório de serviço");
            Console.WriteLine("4 - Carregar Dados");
            Console.WriteLine("5 - Exportar Clientes");
            Console.WriteLine("===========================");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    break;
                case "1":
                    Console.Clear();
                    CadastrarPessoa(servico);
                    break;
                case "2":
                    ConsultaCliente(servico);
                    break;
                case "3":
                    InformacoesServicos(servico);
                    break;
                case "4":
                    CarregarDados(servico);
                    Console.ReadKey();
                    break;
                case "5":
                    GravarDados("dados/clientes.txt", servico);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

    }


    // ==============================================
    // INFORMAÇÕES DO SERVIÇO
    // ==============================================
    public static void InformacoesServicos(Servico servico)
    {
        Console.Clear();
        Console.WriteLine("===== Relatório de Serviço =====\n");
        Console.WriteLine($"Total Clientes: {servico.TotalClientes()}\nCapacidade: {servico.Capacidade}\nTotal Arrecadado: R${servico.TotalArrecadado()}");

        Console.WriteLine("==============================================");
        Console.WriteLine("Deseja exportar html? S - Sim | N - Não");
        string resposta = Console.ReadLine();
        if (resposta == "s" && servico.TotalClientes() > 0)
        {
            GravarDadosHtml("dados/modelo.html", servico);
            Console.WriteLine("HTML gerado com sucesso.");
        }
        Console.WriteLine("\nInsira qualquer tecla para continuar");
        Console.ReadKey();
    }

    // ==============================================
    // CADASTRAR SERVICO
    // ==============================================
    public static Servico CadastrarServico(Servico servico)
    {
        Console.WriteLine("===== Cadastrar Serviço =====\n");
        Console.WriteLine("Insira a descrição do Serviço: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Insira a capacidade total de usuários do Serviço: ");
        int capacidade = int.Parse(Console.ReadLine());

        Console.WriteLine("Insira o preço unitário do Serviço: ");
        int preco = int.Parse(Console.ReadLine());
        servico = new Servico(descricao, capacidade, preco);
        return servico;
    }

    // ==============================================
    // CADASTRAR PESSOA
    // ==============================================
    public static bool CadastrarPessoa(Servico servico)
    {
        if (servico.VerificarLotacao(1))
        {
            Console.WriteLine("===== Cadastrar Pessoa =====\n");
            Console.WriteLine("Insira o nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira a idade");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o sexo do Cliente");
            string sexo = Console.ReadLine();

            Console.WriteLine("O cliente é sócio? 0 - Não | 1 - Sim");
            string isSocio = Console.ReadLine();


            if (isSocio == "1")
            {
                Console.WriteLine("Quanto tempo o cliente é sócio?");
                int tempoSocio = int.Parse(Console.ReadLine());

                Console.WriteLine("Possui Quantos dependentes?");
                int possuiDependentes = int.Parse(Console.ReadLine());
                if (servico.VerificarLotacao(possuiDependentes + 1))
                {
                    Socio socio = new Socio(nome, idade, sexo, tempoSocio);
                    for (int i = 0; i < possuiDependentes; i++)
                    {
                        Pessoa dependente = CadastrarDependentes();
                        socio.AddDependente(dependente);
                    }

                    servico.DecrementaCap(possuiDependentes + 1);
                    servico.InsereSocio(socio);
                    return true;
                }
                Console.WriteLine($"Desculpe, não temos capacidade suficiente para a quantidade de pessoas informada. Ocupação atual: {servico.TotalClientes()}, Capacidade total: {servico.Capacidade }");
                Console.ReadKey();
                return false;
            }
            else
            {
                Pessoa pessoa = new Pessoa(nome, idade, sexo);
                servico.InserePessoa(pessoa);
                servico.DecrementaCap(1);
                Console.ReadKey();
                return true;
            }

        }
        else
        {
            Console.WriteLine("Ocupação máxima atingida, não é possível cadastrar mais cleintes neste serviço.\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
            return false;
        }
    }

    // ==============================================
    // CADASTRAR DEPENDENTES
    // ==============================================
    public static Pessoa CadastrarDependentes()
    {
        Console.WriteLine("===== Cadastrar Dependentes =====\n");
        Console.WriteLine("Insira o nome do Dependente: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Insira a idade");
        int idade = int.Parse(Console.ReadLine());

        Console.WriteLine("Insira o sexo do Dependente");
        string sexo = Console.ReadLine();
        Pessoa dependente = new Pessoa(nome, idade, sexo);

        return dependente;
    }
    // ==============================================
    // CONSULTAR CLIENTES
    // ==============================================
    public static void ConsultaCliente(Servico servico)
    {
        List<Socio> l_socio = servico.ListaSocios();
        List<Pessoa> l_pessoa = servico.ListaPessoa();

        if (l_socio.Count == 0 && l_pessoa.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("===== Consultar Clientes =====\n");
            Console.WriteLine("Ainda não há Clientes cadastrados no sistema");
            Console.WriteLine("\nInformações apresentadas, pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("===== Consultar Clientes =====\n");
            Console.WriteLine("O cliente é sócio? S - sim // N - nao");
            string e_socio = Console.ReadLine();

            if (e_socio.ToLower() == "s")
            {
                if (l_socio.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("===== Lista de Sócios =====\n");

                    Socio start = l_socio[0];
                    for (int i = 0; i < l_socio.Count; i++)
                    {
                        Console.WriteLine("|| {0} - {1} ||", i + 1, l_socio[i].Nome);
                    }
                    Console.WriteLine("\nSelecione o número do sócio a consultar.");
                    int escolha = int.Parse(Console.ReadLine());

                    Console.WriteLine($" >>> Status: Sócio || Nome do cliente: {l_socio[escolha - 1].Nome} || Idade: {l_socio[escolha - 1].Idade} || Sexo: {l_socio[escolha - 1].Sexo} \n >>> Tempo de associação: {l_socio[escolha - 1].TempoSocio} || Depedentes: {l_socio[escolha - 1].RetornaDependentes()}");

                    Console.WriteLine("\nInformações apresentadas, pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Não há sócios cadastrados no sistema ainda.\nPressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
            }

            else if (e_socio.ToLower() == "n")
            {
                if (l_pessoa.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("===== Lista de Não-Sócios =====\n");

                    Pessoa start = l_pessoa[0];
                    for (int i = 0; i < l_pessoa.Count; i++)
                    {
                        Console.WriteLine("|| {0} - {1} ||", i + 1, l_pessoa[i].Nome);
                    }
                    Console.WriteLine("Selecione o número do cliente a consultar.");

                    int escolha = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Status: Não-Sócio || Nome do cliente: {l_pessoa[escolha - 1].Nome} || Idade: {l_pessoa[escolha - 1].Idade} || Sexo: {l_pessoa[escolha - 1].Sexo}");

                    Console.WriteLine("\nInformações apresentadas, pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ainda não há não-sócios cadastrados no sistema.\nPressione qualquer tecla para continuar");
                    Console.ReadKey();
                }

            }

        }

    }

    // ==============================================
    // CARREGAR DADOS
    // ==============================================

    public static void CarregarDados(Servico servico)
    {
        // int lotacao = 0;
        Console.WriteLine("\nCarregando dados ...");
        string[] linhas = File.ReadAllLines("dados/pessoas.txt");
        for (int j = 0; j < linhas.Length; j++)
        {
            if (servico.VerificarLotacao(1))
            {
                string[] dados = linhas[j].Split(";");

                string nome = "";
                int idade = 0;
                string sexo = "";

                // VERIFICA SE USUÁRIO É DEPENDENTE
                if (dados[0] != "dependente")
                {
                    // VERIFICA SE USUÁRIO É SÓCIO
                    if (dados[3] == "true")
                    {
                        int quantidadeDependentes = int.Parse(dados[5]);
                        int countLinhas = 1;

                        if (servico.VerificarLotacao(quantidadeDependentes + 1))
                        {
                            nome = dados[0];
                            idade = int.Parse(dados[1]);
                            sexo = dados[2];

                            int tempo = int.Parse(dados[4]);
                            Socio socio = new Socio(nome, idade, sexo, tempo);
                            servico.InsereSocio(socio);

                            for (int i = 0; i < quantidadeDependentes; i++)
                            {
                                string[] dadosDependentes = linhas[j + countLinhas].Split(";");
                                nome = dadosDependentes[1];
                                idade = int.Parse(dadosDependentes[2]);
                                sexo = dadosDependentes[3];
                                Pessoa pessoaDependente = new Pessoa(nome, idade, sexo);
                                socio.AddDependente(pessoaDependente);
                                countLinhas += 1;
                            }
                            servico.DecrementaCap(1 + quantidadeDependentes);
                        }

                    }
                    else
                    {

                        nome = dados[0];
                        idade = int.Parse(dados[1]);
                        sexo = dados[2];

                        Pessoa pessoa = new Pessoa(nome, idade, sexo);
                        servico.InserePessoa(pessoa);
                        servico.DecrementaCap(1);
                    }

                }
            }
        }

        Console.Clear();
        Console.WriteLine("===== Carregar Dados =====\n");
        Console.WriteLine("\nDados Carregados. \n\nPressione qualquer tecla para continuar!\n");

    }

    // ==============================================
    // GRAVAR DADOS
    // ==============================================

    public static void GravarDados(string arquivo, Servico servico)
    {
        using (StreamWriter gravador = new StreamWriter(arquivo))
        {
            foreach (Pessoa p in servico.ListaPessoa())
            {
                string linha = string.Format("{0};{1};{2}", p.Nome, p.Idade, p.Sexo);
                gravador.WriteLine(linha);
            }
            foreach (Socio s in servico.ListaSocios())
            {
                string linha = string.Format("{0};{1};{2}", s.Nome, s.Idade, s.Sexo);
                gravador.WriteLine(linha);
                if (s.Dependentes().Count > 0)
                {
                    foreach (Pessoa p in s.Dependentes())
                    {
                        string linhaDependente = string.Format("{0};{1};{2}", p.Nome, p.Idade, p.Sexo);
                        gravador.WriteLine(linhaDependente);
                    }
                }
            }
        }
        Console.Clear();
        Console.WriteLine("===== Exportar Clientes =====\n");
        Console.WriteLine("Dados gravados em arquivo! ✍️");
    }


    public static void GravarDadosHtml(string template, Servico servico)
    {

        string textoArquivo = File.ReadAllText(template);
        string linhaTabela = "<tr> <td>{{nomePessoa}}</td> <td style=\"text-align:center\">{{idadePessoa}}</td><td style=\"text-align:center\">{{sexo}}</td> </tr>";
        string linhasPreenchidas = "";
        List<Pessoa> pessoas = servico.ListaPessoa();

        for (int i = 0; i < pessoas.Count; i++)
        {
            Pessoa p = pessoas[i];
            string linhaAuxiliar = linhaTabela.Replace("{{nomePessoa}}", p.Nome);
            linhaAuxiliar = linhaAuxiliar.Replace("{{idadePessoa}}", p.Idade.ToString());
            linhaAuxiliar = linhaAuxiliar.Replace("{{sexo}}", p.Sexo.ToUpper());

            linhasPreenchidas += linhaAuxiliar + Environment.NewLine;
        }

        textoArquivo = textoArquivo.Replace("{{linhas_tabela}}", linhasPreenchidas);
        textoArquivo = textoArquivo.Replace("{{pagantes}}", servico.ListaPessoa().Count.ToString());
        textoArquivo = textoArquivo.Replace("{{preco_unitario}}", servico.Preco.ToString());
        textoArquivo = textoArquivo.Replace("{{receita_total}}", servico.TotalArrecadado().ToString());
        string nomeRelatorio = "dados/exportclientes.html";
        File.WriteAllText(nomeRelatorio, textoArquivo);
    }
}