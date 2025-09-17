using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update;

    public class UpdateClientUseCase
    {
    //Recebe o id do cliente e os dados para atualizar
    public void Execute(Guid clientId, RequestClientJson request)
        {
        //aqui vai a lógica para atualizar um cliente
        Validate(request);
        //variavel criada para instanciar o contexto do banco de dados
        var dbContext = new ProductClientHubDbContext();
        //variavel criada para buscar o cliente no banco de dados pelo id
        var entity = dbContext.Clients.FirstOrDefault(Clients => Clients.Id == clientId);

        if(entity is null)
            throw new NotFoundException("Cliente não encontrado");

        //atualiza os dados do cliente com os dados da requisição
        entity.Name = request.Name;
        entity.Email = request.Email;

        //atualiza o cliente no banco de dados
        dbContext.Clients.Update(entity);

        //salva as alterações no banco de dados
        dbContext.SaveChanges();
    }

    public void Validate(RequestClientJson request)
    {
        //variavel criada para chamar a função de validação dos parametros
        var validattor = new RequestClientValidator();
        //variavel criada para receber o resultado da validação
        var result = validattor.Validate(request);
        //este if valida se os campos Name e Email da requisição são válidos
        if (result.IsValid == false)
        {
            //variavel criada para receber uma lista com mensagens de erro
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            //lança a exceção com a lista de erros
            throw new ErrorOnValidationException(errors);
        }
    }
}

