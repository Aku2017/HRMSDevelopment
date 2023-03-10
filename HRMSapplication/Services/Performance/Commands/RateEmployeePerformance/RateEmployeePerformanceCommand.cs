using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.RateEmployeePerformance
{
    public record RateEmployeePerformanceCommand(Guid EmployeeId,int MonthlyRating, DateTime Month):
        IRequest<PerformanceResponse>;
}
