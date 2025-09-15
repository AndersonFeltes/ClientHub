namespace ProductClientHub.Communication.Responses;

    public class ResponseErrosMessageJson
    {
        //criando uma lista de erros
        //o set esta como private para outras classes não poderem alterar o valor do parametro
        public List<string> Errors { get; private set; }

    //o construtor obriga que o parametro message seja passado para instanciar a função

    //contrutor recebendo uma mensagem
    public ResponseErrosMessageJson(string message)
    {
        Errors = [message];
    }

    //construtor recebendo uma lista de mensagens
    public ResponseErrosMessageJson(List<string> messages)
    {
        Errors = messages;
    }
}

