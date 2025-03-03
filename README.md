# Teste para AB inBev em dotnet e angular
** Implemetado modificações no template recebido e com isso foi solicitado adapatar algumas bibbliotecas e realização de testes no frontend e no backend.  

## Tecnologias usadas
- Frontend  => Angular e jest para testes
- Backend => Dotnet  e  xUnit para testes
- Banco de dados Postgresql


## Configuração para rodar frontend
** git clone https://github.com/leandro-cabeda/ab-in-bev
** Primeiro entre na pasta "cd abi-gth-omnia-developer-evaluation/serverest-front"
- Nela tu realiza a instalação das dependencias
- Executa "npm start" para subir a aplicação que estária na url: http://localhost:4200
- Executar os testes no frontend com cypress via interface, execute  =>   "npx cypress open" , isso vai abrir uma interface e pode realizar os testes por la.
-> Executar os testes no frontend com cypress via terminal =>  "npx cypress run --spec "cypress/integration/api/*" "


## Configuração para rodar backend
** git clone https://github.com/leandro-cabeda/ab-in-bev
** Primeiro entre na pasta "cd abi-gth-omnia-developer-evaluation/template/backend"
** Dentro da pasta vai ter varios modulos da aplicação, para executar a instalação das bibliotecas referenciadas, execute as operações:
** Entre nesse diretorio:  "cd abi-gth-omnia-developer-evaluation/template/backend/src/Ambev.DeveloperEvaluation.WebApie" execute as instalações:
- Primeiro instale o dotnet versão 8.0 se não tiver na maquina.
- Segundo altere as configurações do banco de dados nesse diretorio: "abi-gth-omnia-developer-evaluation/template/backend/src/Ambev.DeveloperEvaluation.WebApi/appsettings.json"
para qual vc achar melhor, por padrão está com banco de dados postgresql e a database para ser criada é: "DeveloperEvaluation"
- Terçeiro instale as dependencias do donet dentro do diretorio: "abi-gth-omnia-developer-evaluation/template/backend/src/Ambev.DeveloperEvaluation.WebApi" executando o comando:
"dotnet restore" .
- Execute as migrações do banco dentro dessa pasta => "dotnet ef database update"
- Buildar o projeto  => "dotnet build"
- Pode-ser iniciar api manualmente através desse comando   =>   "dotnet run --project src/Ambev.DeveloperEvaluation.WebApi"
- Executar todos os testes do projeto  =>  "dotnet test"
- Executar RabbitMQ via docker  =>  "docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management"
- Habilitar painel web com RabbitMQ  =>  "rabbitmq-plugins enable rabbitmq_management"
- Startar RabbitMQ caso tiver parado, ou reniciar  =>   "docker (start ou restart) rabbitmq"
- Parar RabbitMQ  =>  "docker stop rabbitmq"
- Se quiser rodar apenas os testes de um arquivo especifico no backend, exemplo execute => "dotnet test --filter FullyQualifiedName~UserServiceTests"
- Se o seu projeto de testes estiver dentro da pasta tests/Ambev.DeveloperEvaluation.Unit/, e quiser rodar todos os testes dentro dessa pasta, execute exemplo => "dotnet test tests/Ambev.DeveloperEvaluation.Unit"


