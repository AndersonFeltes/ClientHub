using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete;

public class DeletClienteUseCase
{
    public void Execute(Guid id)
    {
        //lógica para deletar o cliente pelo id
        var dbContext = new ProductClientHubDbContext();

        var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);

        if (entity is null)
            throw new NotFoundException("Cliente não encontrado");



        dbContext.Clients.Remove(entity);   

        dbContext.SaveChanges();
    }
}
