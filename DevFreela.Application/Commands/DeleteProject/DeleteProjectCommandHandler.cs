using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            project.Cancel();
            
            await _projectRepository.SaveChangesAsync();

            // ASYNC = quando faz uma requisição no banco de dados a sua thread vai ficar esperando essa resposta,
            // então ela fica inativa quando utliza o AWAIT você basicamente deleta essa operação de entrada e saida
            // de acesso ao banco de dados e a sua thread fica livre para fazer outras coisas. Então em casos que você
            // tem uma grande quantidade de acessos a sua aplicação, sua aplicação vai ter muito menos riscos de travar

            return Unit.Value;
        }

    }
}
