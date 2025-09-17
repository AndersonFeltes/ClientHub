using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll;

    public class GetAllClientUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            //aqui vai a lógica para pegar todos os clientes
            var dbContext = new ProductClientHubDbContext();
            //pega todos os clientes do banco de dados
            var clients = dbContext.Clients.ToList();

        //retorna a resposta com a lista de clientes
        return new ResponseAllClientsJson
            {
            //aqui ele está convertendo a lista de clientes do banco de dados para a lista de ResponseShortClientJson
            Clients = clients.Select(client => new ResponseShortClientJson
                {
                    Id = client.Id,
                    Name = client.Name
                }).ToList()
            };
    }
}

