using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CpfIsValid
{
    public class CpfIsValid
    {
        private readonly ILogger<CpfIsValid> _logger;

        public CpfIsValid(ILogger<CpfIsValid> logger)
        {
            _logger = logger;
        }

        [Function("CpfIsValid")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            
            // Leitura do corpo da requisição
            string requestBody = await new System.IO.StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            // Extraindo o CPF do corpo da requisição
            string cpf = data?.cpf;

            // Verificar se o CPF foi passado
            if (string.IsNullOrEmpty(cpf))
            {
                return new BadRequestObjectResult("CPF não fornecido.");
            }

            // Validar CPF
            var valid = ValidarCPF(cpf);

            if (valid) 
            {
                return new OkObjectResult("CPF válido!");
            }
            else
            {
                return new OkObjectResult("CPF não é válido!");
            }
               
        }

        public static bool ValidarCPF(string cpf)
        {
            // Remover todos os caracteres não numéricos (pontos, hífens)
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificar se o CPF tem 11 caracteres
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verificar se o CPF não é uma sequência de números repetidos (ex: 111.111.111-11)
            if (cpf.All(c => c == cpf[0]))
            {
                return false;
            }

            // Validar os dois dígitos verificadores
            int[] digitos = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // Calcular o primeiro dígito verificador
            int soma1 = 0;
            for (int i = 0; i < 9; i++)
            {
                soma1 += digitos[i] * (10 - i);
            }
            int digito1 = soma1 % 11;
            if (digito1 < 2) digito1 = 0;
            else digito1 = 11 - digito1;

            // Calcular o segundo dígito verificador
            int soma2 = 0;
            for (int i = 0; i < 10; i++)
            {
                soma2 += digitos[i] * (11 - i);
            }
            int digito2 = soma2 % 11;
            if (digito2 < 2) digito2 = 0;
            else digito2 = 11 - digito2;

            // Verificar se os dois dígitos verificadores estão corretos
            return digitos[9] == digito1 && digitos[10] == digito2;
        }
    }
}
