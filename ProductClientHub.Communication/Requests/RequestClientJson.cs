namespace ProductClientHub.Communication.Requests
{
    //Aqui são recebidos os parametros da requisição
    public class RequestClientJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //strings não podem ser nulas por isso o comando string.Empty ao final da linha
    }
}
