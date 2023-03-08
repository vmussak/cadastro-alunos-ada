using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ada.Aluno.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Presentation.Filters;

namespace Ada.Aluno.Presentation.Controllers
{
    [Route("api/student")]
    //[TypeFilter(typeof(MinhaExceptionFilter))] -> específico
    public class AlunoController : Controller
    {
        private readonly ICriarAlunoUseCase _criarAlunoUseCase;
        private readonly IBuscarAlunosUseCase _buscarAlunosUseCase;

        public AlunoController(
            ICriarAlunoUseCase criarAlunoUseCase,
            IBuscarAlunosUseCase buscarAlunosUseCase
        )
        {
            _criarAlunoUseCase = criarAlunoUseCase;
            _buscarAlunosUseCase = buscarAlunosUseCase;
        }
     
        [HttpPost]
        [AcceptProfiles("admin", "professor")]
        public IActionResult Post([FromBody] CriarAlunoRequest request)
        {
            var response = _criarAlunoUseCase.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return StatusCode((int)response.StatusCode, response.Data);
            }

            return StatusCode((int)response.StatusCode, response.Messages);
        }

        [HttpGet]
        //[AcceptProfiles("professor")]
        public IActionResult Get()
        {
            var alunosResponse = _buscarAlunosUseCase.Execute();

            return Ok(alunosResponse.Data);
        }
    }
}

