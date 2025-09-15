using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]

        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, usando a classe ResponseClientJson

        [ProducesResponseType(typeof(ResponseErrosMessageJson), StatusCodes.Status400BadRequest)]
        //linha mostrando o código correto do protocolo HTTP para retornar ao criar um usuário, caso tenha parametros incorretos na requisição
        public IActionResult Register([FromBody] RequestClientJson request)
        { 
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/Anderson/{sobrenome}" )]
        public IActionResult GetById([FromRoute] Guid id, string sobrenome)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
