using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator
{
    //RegisterClientValidator recebe a herança de AbstractValidator
    //RequestClientJson é passado como parametro para receber o objeto
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            //criando uma regra para as propriedades Name e Email que vem do objeto RequestClientJson
            //NotEmpty para impedir que venha vazio o Name. EmailAddrress para ser um e-mail válido
            RuleFor( client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
            RuleFor( client => client.Email).EmailAddress().WithMessage("O e-mail não é valido");
        }
    }
}
