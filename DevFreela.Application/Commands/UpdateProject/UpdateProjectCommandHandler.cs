using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            // ASYNC = quando faz uma requisição no banco de dados a sua thread vai ficar esperando essa resposta,
            // então ela fica inativa quando utliza o AWAIT você basicamente deleta essa operação de entrada e saida
            // de acesso ao banco de dados e a sua thread fica livre para fazer outras coisas. Então em casos que você
            // tem uma grande quantidade de acessos a sua aplicação, sua aplicação vai ter muito menos riscos de travar

            return Unit.Value;
        }
    }
}
