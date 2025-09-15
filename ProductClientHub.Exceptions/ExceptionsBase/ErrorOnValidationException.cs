namespace ProductClientHub.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : ProductClientHubException
{
    //criando um atributo privado para a classe ErrorOnValidationException, é uma lista de texto que foi nomeada como "errors"

    // readonly significa que essa lista so pode sofrer alterações, apagada ou adicionar valor dentro do construtor da classe
    // quando o atributo tiver private e readonly é uma boa pratica o nome ser declarado com underline no começo
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors() => _errors;
}
