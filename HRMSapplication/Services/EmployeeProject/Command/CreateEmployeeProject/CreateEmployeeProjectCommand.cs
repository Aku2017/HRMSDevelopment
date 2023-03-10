using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.EmployeeProject.Command.CreateEmployeeProject
{
    public record CreateEmployeeProjectCommand(Guid EmployeeId,string Name, string? Link ,ProjectState Status, string description):IRequest;

    public record CreateEmployeeProjectCommandHandler : IRequestHandler<CreateEmployeeProjectCommand>
    {
        private readonly IEmployeeProjectRepo _repo;
        private readonly IEmployeeRepo _empRepo;

        public CreateEmployeeProjectCommandHandler(IEmployeeProjectRepo repo, IEmployeeRepo empRepo)
        {
            _repo = repo;
            _empRepo = empRepo;
        }
        public async Task<Unit> Handle(CreateEmployeeProjectCommand request, CancellationToken cancellationToken)
        {
            var emp = await _empRepo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                var employeeProject = new HRMS.Domain.Entities.EmployeeProject();
                employeeProject.Employee = emp;
                employeeProject.Name = request.Name;
                employeeProject.Link = request.Link;
                employeeProject.Status = request.Status;
                employeeProject.Description = request.description;
                _repo.AddEntity(employeeProject);
                await _repo.Complete();
                return Unit.Value;
            }
            else
                throw new NullReferenceException("Employee not found.");
        }
    }
}
