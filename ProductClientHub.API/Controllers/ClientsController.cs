using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]

        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, usando a classe ResponseClientJson

        [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status400BadRequest)]
        //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, caso tenha parametros incorretos na requisição
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            //aqui vai a lógica para registrar um cliente
            var useCase = new RegisterClientUseCase();
            //pega o cliente que foi registrado
            var response = useCase.Execute(request);
            //retorna o cliente registrado com o código 201 (Created)
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]

        //linha identificando o código 204 (NoContent) como uma possível resposta dessa rota
        //requisição que não retorna nada
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //linha identificando o código 400 (BadRequest) como uma possível resposta dessa rota
        [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status400BadRequest)]
        //linha identificando o código 404 (NotFound) como uma possível resposta dessa rota
        [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id,[FromBody] RequestClientJson request)
        {
            var UseCase = new UpdateClientUseCase();

            UseCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]

        //linha identificando o código 204 (NoContent) como uma possível resposta dessa rota
        //requisição que não retorna nada
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            //aqui vai a lógica para pegar todos os clientes
            var useCase = new GetAllClientUseCase();
            //pega todos os clientes do banco de dados
            var response = useCase.Execute();

            //se não tiver nenhum cliente, retorna o código 204 (NoContent)
            if (response.Clients.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id, string sobrenome)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete()
        {
            var useCase = new DeletClienteUseCase();

            useCase.Execute();

            return NoContent();
        }
    }
}
