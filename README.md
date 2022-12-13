<h1>SharpCesc</h1> 

<h2>O projeto SHARPCESC é uma simulação de uma rotina em um clube que possui serviços, sócios e não-sócios.</h2>

- Serviços podem ser cadastrados possuindo capacidade máxima, preço e a lista de pessoas inseridas naquele serviço.
<br/>

- Pessoas (ou os não sócios) podem ser cadastradas possuindo nome, idade e sexo. Não-sócios devem pagar ao clube a taxa de serviço entrando, assim, na lista de pagantes.
<br/>
- Sócios podem ser cadastrados [HERDANDO](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/inheritance) (link para a documentação da linguagem) atributos e métodos da Classe Pessoa. Como diferencial, um sócio pode usar o clube com seus dependentes (cadastrados com os atributos da Classe Pessoa), não entrando na lista de pagantes.
<br/>
- O sistema permite o usuário consultar cadastro de todos os clientes inseridos no serviço.
<br>
- O sistema trabalha com permanência de dados por meios de arquivos .txt . É dada a opção de carregar os dados (ler o arquivo /dados/pessoas.txt) e gravar os dados (escrever no arquivo /dados/clientes.txt).
<br/>
- Relatórios podem ser gerados e expostos no console. O sistema também conta com a opção de gerar um relatório em HTML (salva no arquivo /dados/exportclientes.html).

<h2>Tratamentos do sistema</h2>

- [x] O sistema deve decrementar a capacidade total do serviço a medida que novos clientes são cadastrados.
 
<br/>

- [x] Caso apenas tenha 1 vaga restante no serviço, o sistema deve permitir o cadastramento de Sócios *SEM* dependentes ou de 1 não-sócio.
<br/>

- [x] O relatório deve mostrar a ocupação restante e o valor arrecadado baseado na quantidade de pagantes cadastrados.
