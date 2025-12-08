using gestao_escolar_api.Models;
using gestao_escolar_api.Services;

namespace gestao_escolar_api.Endpoints
{
    public static class AlunosEndpoints
    {
        public static void MapAlunosEndpoints(this WebApplication app)
        {
            app.MapGet("/alunos", async (IAlunoService alunoService) =>
            {
                var alunos = await alunoService.BuscarAlunos();
                return Results.Ok(alunos);
            });
            app.MapGet("/alunos/{id}", async (int id, IAlunoService alunoService) =>
            {
                var aluno = await alunoService.BuscarAlunoPorId(id);
                return aluno is not null ? Results.Ok(aluno) : Results.NotFound();
            });
            app.MapPost("/alunos", async (Aluno aluno, IAlunoService alunoService) =>
            {
                var novoAluno = await alunoService.CadastrarAluno(aluno);
                return Results.Created($"/alunos/{novoAluno.AlunoId}", novoAluno);
            });
            app.MapPut("/alunos/{id}", async (int id, Aluno aluno, IAlunoService alunoService) =>
            {
                if (id != aluno.AlunoId)
                {
                    return Results.BadRequest();
                }
                var atualizado = await alunoService.EditarAluno(aluno);
                return atualizado ? Results.NoContent() : Results.NotFound();
            });
            app.MapDelete("/alunos/{id}", async (int id, IAlunoService alunoService) =>
            {
                var removido = await alunoService.DeletarAluno(id);
                return removido ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
