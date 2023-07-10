## Aplicação de Exemplo: Calculadora de Investimento CDB
Esta é uma aplicação de exemplo que combina o Angular e o .NET Framework para criar uma calculadora de investimento em **CDB (Certificado de Depósito Bancário)**. A aplicação permite calcular o rendimento bruto, rendimento líquido, valor final bruto e valor final líquido de um investimento em CDB com base em um valor inicial e quantidade de meses fornecidos.

![](https://i.ibb.co/T2hTLfq/cdb.png)

### Tecnologias Utilizadas
**Angular:** um framework de desenvolvimento de aplicativos web em TypeScript.

**.NET Framework (4.7.2):** um framework de desenvolvimento para criar aplicativos Windows e web em C#.
### Visão Geral da Estrutura do Projeto
A aplicação é composta por duas partes principais: o front-end em Angular e o back-end em .NET Framework.

### Front-end (Angular)
A parte frontend da aplicação foi desenvolvida usando o Angular, um framework JavaScript baseado em TypeScript para construção de aplicações web modernas. Para efetuar as requisições HTTP, foi utilizado o Axios. Já para testes unitários, foi utilizado o Jasmine.

*src/app:* Esta pasta contém os componentes, serviços e modelos relacionados à lógica do frontend.

### Back-end (.NET Framework)
A parte backend da aplicação foi desenvolvida usando o .NET Framework, um framework de desenvolvimento robusto para criar aplicativos Windows e web usando a linguagem C#.

**B3.WebApi:** contém as Controllers necessárias para cada requisição. Também possui Model para requests;

**B3.Services:** camada responsável pelas regras de negócios. Nela há a classe chamada `CalculoCdb.cs` onde é responsável apenas por realizar o cálculo de CDB, respeitando o princípio de ter apenas uma única responsabilidade. Além disso, temos uma classe dentro de Helpers/Moeda, chamada `FormatacaoMonetaria` do tipo *static*, onde a mesma é responsável apenas por converter valores decimais para o R$.

**B3.Models:** Esta pasta contém as classes de modelo que representam os objetos de domínio da aplicação. Dentro da pasta Ativos/CDB, temos 3 classes:
1. `Aliquotas.cs` -> Classe static responsável por referenciar todas as aliquotas necessárias para os cálculos de CDB. Nela contém seus períodos e seus respectivos valores setados como decimais. O tipo foi pensando por ser de 128 bit, **recomendado** quando lidamos com porcentagem e aplicações financeiras. 
Temos também um método que possui uma lógica para obtermos o percentual da taxa do IR pelo tempo fornecido (em meses).
2. `Cdb.cs` -> Classe de domínio do CDB. Nela temos as propriedades de rendimentos, valores finais brutos e líquidos, além de informações sobre o IR.
3. `TaxasConfig` -> Classe static onde compartilha com toda a aplicação os valores de taxas do Cdi e Tb.

No projeto, também temos uma pasta de Enums onde podemos guardar os Enums da aplicação. Além disso, foi criado a pasta Extensions para servir de extensão para enums quando necessitar de implementar lógicas de retorno. Essas duas pastas, neste projeto, foram utilizadas para fornecer o tempo de investimento (`EtempoInvestimento`) e assim facilitar a manutenção do código.

E como não poderia faltar nesta camada, temos a pasta Response, onde fica a classe ApiResponse, que é responsável por retornar dados para a Controller. Esta classe é do tipo Genérica e possui um construtor para passagem dos dados e montagem dos mesmos. Nesta pasta também poderá ficar outras Responses, caso surja necessidade ao decorrer do tempo.

### Como Executar a Aplicação
1. Certifique-se de ter o Node.js e o Angular CLI instalados em seu ambiente de desenvolvimento.
2. Clone o repositório do projeto em sua máquina local através do comando `git clone https://github.com/diogomarv/B3`
3. Navegue para a pasta do projeto front-end (cd frontend) e execute o comando `npm install` ou `npm i` para instalar as dependências do projeto.
4. Execute o comando `npm start` para iniciar o servidor de desenvolvimento do Angular.
5. Navegue para a pasta do projeto back-end e execute o projeto usando sua IDE ou executando `dotnet run` no terminal.
6. Agora você pode acessar a aplicação em seu navegador em http://localhost:4200 e começar a usar a calculadora de investimento CDB.
7. O back-end roda na porta 44380 (`https://localhost:44380/`) e a rota no qual o front-end chama é: `https://localhost:44380/api/ativos/calcular-cdb` passando o seguinte JSON como body (método POST):

```json
{
    "Valor":1000,
    "QtdMeses":2
}
```

### Como executar os Testes Unitários?
**Back-end: ** No Visual Studio, clique com o botão direito do mouse no projeto de testes e depois clique em "Run Tests". Certifique-se de efetuar um "Clean" antes de rodar o projeto.
**Front-end: ** No Visual Studio Code ou editor de sua preferência, navegue até a pasta do projeto e digite `npm test`
### Observações
##### 1. Não foi utilizado IoC no projeto por conta do tamanho do mesmo. Também não foi utilizado nenhuma biblioteca para validação, como o FluentValidation.
##### Em projetos maiores o recomendável é seguir todas as práticas e padrões de projeto, incluindo libs para facilitar o desenvolvimento, porém em projetos menores, menos, pode ser mais.
