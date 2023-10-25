using Microsoft.AspNetCore.Mvc;
using ValdoBase.Database.Repository.Alunos;

namespace ValdoBase.Controllers
{
    [Route("api/v1/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}