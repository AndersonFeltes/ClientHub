namespace ProductClientHub.API.Entities;


//essa entidade vai representar o cliente no sistema, no caso a linha no banco de dados na tabela de clientes
public class Client
    {
        //o Id é gerado automaticamente quando um novo cliente é criado
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
}

