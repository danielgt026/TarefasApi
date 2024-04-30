using Microsoft.AspNetCore.Mvc;
using TarefasApi.Models.Enuns;
using TarefasApi.Models;


namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefassController : ControllerBase
    {

        private static List<Tarefas> tarefas = new List<Tarefas>()
        {
            new Tarefas() { Id = 1, Nome = "Lavar a Louça", Descrição = "Lavar a louça antes da mãe chegar", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida },
            new Tarefas() { Id = 2, Nome = "Estudar para prova", Descrição = "Estudar c# para proxima prova", Prioridade = Prioridade.PrioridadeAlta, Status = Status.Incompleta },
            new Tarefas() { Id = 3, Nome = "Fazer trabalho escolar", Descrição = "Fazer o trabalho de fisica", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Incompleta },
            new Tarefas() { Id = 4, Nome = "Academia", Descrição = "Ir a academia", Prioridade = Prioridade.Prioridademedia, Status = Status.Concluida },
            new Tarefas() { Id = 5, Nome = "Revisar conteudo passado aula", Descrição = "Revisar conteudo passado na aula de DS", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida }

        };

        #region Get

    

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(tarefas);
        }

        [HttpGet("BuscaPorId/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(tarefas.FirstOrDefault(tarefas => tarefas.Id == id));
        }




        #endregion

        #region Post

        //CRIAR TAREFAS
        [HttpPost]
        public IActionResult Create(Tarefas novaTarefa)
        {
            if (novaTarefa == null)
            {
                return BadRequest("A nova tarefa não pode ser nula.");
            }

            novaTarefa.Id = tarefas.Max(t => t.Id) + 1;
            tarefas.Add(novaTarefa);

            return CreatedAtAction(nameof(GetById), new { id = novaTarefa.Id }, novaTarefa);

        }


        #endregion

        #region Put

       [HttpPut("{id}")]
        public IActionResult Update(int id, Tarefas updatedTarefa)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.Nome = updatedTarefa.Nome;
            tarefa.Descrição = updatedTarefa.Descrição;
            tarefa.Prioridade = updatedTarefa.Prioridade;
            tarefa.Status = updatedTarefa.Status;
            return Ok(tarefa);
        }

        #endregion

        #region Delete 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefas.Remove(tarefa);
            return NoContent();
        }



        #endregion

    }
}