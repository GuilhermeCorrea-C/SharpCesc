<h1>SharpCesc</h1> 

<h2>O projeto SHARPCESC é uma simulação de uma rotina em um clube que possui serviços, sócios e não-sócios.</h2>

- Serviços podem ser cadastrados possuindo capacidade máxima, preço e a lista de pessoas inseridas naquele serviço.
- Pessoas (ou os não sócios) podem ser cadastradas possuindo nome, idade e sexo. Não-sócios devem pagar ao clube a taxa de serviço entrando, assim, na lista de pagantes.
- Sócios podem ser cadastrados [HERDANDO](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/inheritance) (link para a documentação da linguagem) atributos e métodos da Classe Pessoa. Como diferencial, um sócio pode usar o clube com seus dependentes (cadastrados com os atributos da Classe Pessoa), não entrando na lista de pagantes.
- O sistema trabalha com permanência de dados por meios de arquivos .txt . É dada a opção de carregar os dados (ler o arquivo pessoas.txt) e gravar os dados (escrever no arquivo clientes.txt).

<h2>Tratamentos do sistema</h2>

- [x] O sistema deve decrementar a capacidade total do serviço a medida que novos clientes são cadastrados.
- [x] Caso apenas tenha 1 vaga restante no serviço, o sistema deve permitir o cadastramento de Sócios sem dependentes ou de 1 não-sócio.