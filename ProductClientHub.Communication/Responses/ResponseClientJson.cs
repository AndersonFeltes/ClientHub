namespace ProductClientHub.Communication.Responses
{
    public class ResponseClientJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //strings não podem ser nulas por isso o comando string.Empty ao final da linha
    }
}
