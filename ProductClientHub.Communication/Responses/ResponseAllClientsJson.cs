namespace ProductClientHub.Communication.Responses;

    public class ResponseAllClientsJson
    {
    //essa classe é para retornar todos os clientes
    // toda vez que for fazer um new dessa classe, a lista de clientes já vai ser iniciada vazia
    public List<ResponseShortClientJson> Clients { get; set; } = [];

}

