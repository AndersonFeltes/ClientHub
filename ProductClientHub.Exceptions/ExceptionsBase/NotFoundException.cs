using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase;

public class NotFoundException : ProductClientHubException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {

    }

    //implementar a função abstrata herdada da classe base
    public override List<string> GetErrors() => [Message];

    //implementar a função abstrata herdada da classe base
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;

}

