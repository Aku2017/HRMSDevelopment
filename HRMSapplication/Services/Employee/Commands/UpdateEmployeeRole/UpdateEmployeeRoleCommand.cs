using HRMScore.HRMSenums;
using MediatR;


namespace HRMSapplication.Commands.UpdateEmployeeDepartment
{
    public record UpdateEmployeeRoleCommand(Guid EmployeeId, Role Role) :IRequest;
    
}
