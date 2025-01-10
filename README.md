
# Validação de CPF - API (Desafio Curso Azure 204 - DIO)
Este projeto consiste em uma API desenvolvida para validar o CPF fornecido, utilizando Azure Functions. A validação do CPF segue as regras padrão do número, incluindo a verificação dos dois dígitos verificadores. Este desafio foi realizado como parte do curso Azure 204 na plataforma DIO.me.

# Funcionalidades
Validação de CPF: A API valida o CPF recebido via requisição HTTP POST.
Mensagem de Erro: Caso o CPF não seja fornecido ou o formato esteja incorreto, uma mensagem de erro será retornada.
Requisição Simples: A API recebe o CPF no corpo da requisição em formato JSON e retorna uma resposta com o status da validação.
Como Usar
Requisição
Método HTTP: POST
Endpoint: /CpfIsValid
Formato de Corpo da Requisição:
A requisição deve conter um JSON com o campo cpf, onde o valor é o CPF a ser validado.

# Exemplo de Requisição:
``` 
{
  "cpf": "123.456.789-09"
}
```

Respostas
CPF válido: Se o CPF for válido, a resposta será:

```
{
  "message": "CPF válido!"
}
```

CPF inválido: Se o CPF for inválido, a resposta será:

```
{
  "message": "CPF não é válido!"
}
```

CPF não fornecido: Se o CPF não for enviado, a resposta será:

```
{
  "message": "CPF não fornecido."
}
```

# Tecnologias Utilizadas
Azure Functions: Plataforma de serverless utilizada para implementar a API.
C#: Linguagem de programação utilizada para desenvolver a lógica de validação do CPF.
JSON: Formato utilizado para enviar dados na requisição e resposta.
Visual Studio: IDE utilizada para o desenvolvimento da função no Azure Functions.

# Como Rodar Localmente
Pré-requisitos
.NET Core SDK: Necessário para executar funções localmente.

Download .NET SDK
Azure Functions Core Tools: Ferramenta para executar funções Azure localmente.

Download Azure Functions Core Tools
Conta Azure (opcional): Para deployar a função na Azure, você precisará de uma conta no Azure.

Passos para Rodar Localmente
Clone este repositório para sua máquina local:

```
git clone https://github.com/seuusuario/validador-cpf-azure.git
```

Navegue até o diretório do projeto:

```
cd validador-cpf-azure
Instale as dependências do projeto (se necessário):
```

```
dotnet restore
Inicie a função localmente:
```

```
func start
```
A função estará disponível em http://localhost:7071. Você pode testar a API utilizando ferramentas como Postman ou cURL, enviando uma requisição POST com um CPF no corp
