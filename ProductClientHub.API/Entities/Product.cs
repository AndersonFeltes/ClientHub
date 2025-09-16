namespace ProductClientHub.API.Entities;

//essa entidade vai representar o produto no sistema, no caso a linha no banco de dados na tabela de produtos
public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClientId { get; set; }
}

