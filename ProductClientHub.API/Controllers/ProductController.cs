using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Products.Delete;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost]
    [Route("{clientId}")]

    [ProducesResponseType(typeof(ResponseShortProducJson), StatusCodes.Status201Created)]
    //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, usando a classe ResponseClientJson

    [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status400BadRequest)]
    //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, caso tenha parametros incorretos na requisição

    [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status404NotFound)]
    //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, caso o cliente não seja encontrado
    public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
    {
        //aqui vai a lógica para registrar um produto
        var useCase = new RegisterProductUseCase();
        //pega o produto que foi registrado
        var response = useCase.Execute(clientId, request);
        //retorna o produto registrado com o código 201 (Created)
        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        //lógica para deletar o produto pelo id
        var useCase = new DeleteProductUseCase();
        useCase.Execute(id);
        return NoContent();
    }
}
