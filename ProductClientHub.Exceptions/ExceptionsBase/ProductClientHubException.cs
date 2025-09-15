using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase;

//a classe é transformada em exceção após ser feito a herança de SystemException
//essa é uma excessão customizada
public abstract class ProductClientHubException : SystemException
    {
    //é informado o base em herança do construtor para chamar o construtor da classe SystemException
    public ProductClientHubException(string errorMessage) : base(errorMessage)
    {
        
    }

    //função que não tem um corpo
    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatusCode();
}

