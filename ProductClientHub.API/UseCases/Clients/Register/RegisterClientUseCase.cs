using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            //variavel criada para chamar a função de validação dos parametros
            var validator = new RegisterClientValidator();

            //variavel criada para receber o resultado da validação
            var result = validator.Validate(request);

            //este if valida se os campos Name e Email da requisição são válidos
            if (result.IsValid == false) {

                //variavel criada para receber uma lista com mensagens de erro
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}
