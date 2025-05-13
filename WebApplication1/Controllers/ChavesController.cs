using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChavesController : ControllerBase
    {
        private readonly Teste _teste;

        public ChavesController(Teste teste)
        {
            _teste = teste;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_teste.ObterConexao());
        }
    }

    public class Teste
    {
        private string _conexao;

        public Teste(string conexao)
        {
            _conexao = conexao;
        }

        public string ObterConexao()
        {
            return _conexao;
        }
    }
}
