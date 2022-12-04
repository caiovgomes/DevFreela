using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);

            await _userRepository.AddAsync(user);

            // ASYNC = quando faz uma requisição no banco de dados a sua thread vai ficar esperando essa resposta,
            // então ela fica inativa quando utliza o AWAIT você basicamente deleta essa operação de entrada e saida
            // de acesso ao banco de dados e a sua thread fica livre para fazer outras coisas. Então em casos que você
            // tem uma grande quantidade de acessos a sua aplicação, sua aplicação vai ter muito menos riscos de travar

            //return Task.FromResult(user.Id);
            return user.Id;
        }
    }
}
