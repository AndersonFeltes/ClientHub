using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

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
            try
            {
                //cria um novo objeto de registro
                var useCase = new RegisterClientUseCase();

                //chama a função Execute da classe RegisterClientUseCase
                var response = useCase.Execute(request);

                //retorna o Created
                return Created(string.Empty, response);
            }
            catch (ProductClientHubException ex) {

                var errors = ex.GetErrors();
                return BadRequest(new ResponseErrosMessageJson(errors));
            }
            catch
            {
                //Configuração para devolver uma excessão de erro desconhecido código HTTP 500
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrosMessageJson("ERRO DESCONHECIDO"));
            }
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
