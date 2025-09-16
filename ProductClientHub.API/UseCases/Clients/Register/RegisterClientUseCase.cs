using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register;

    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
        //chama a função que valida os parametros da requisição
        Validate(request);

        //criando uma variavel para instanciar o contexto do banco de dados
        var dbContext = new ProductClientHubDbContext();
        //criando uma variavel para instanciar a entidade Client
        var enttity = new Client
        {
            Name = request.Name,
            Email = request.Email,
        };
        //adiciona o novo cliente na tabela de clientes do banco de dados
        dbContext.Clients.Add(enttity);
        //salva as alterações no banco de dados
        dbContext.SaveChanges();

        return new ResponseClientJson
        {
            Id = enttity.Id,
            Name = enttity.Name,
        };
     }

        private void Validate(RequestClientJson request)
        {
            //variavel criada para chamar a função de validação dos parametros
            var validator = new RegisterClientValidator();

            //variavel criada para receber o resultado da validação
            var result = validator.Validate(request);

            //este if valida se os campos Name e Email da requisição são válidos
            if (result.IsValid == false)
            {

                //variavel criada para receber uma lista com mensagens de erro
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }

