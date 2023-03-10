using AutoMapper;
using HRMS.Application.Services.EmployeeService.Common;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapEmployee _map;
        private readonly IDepartmentRepo _dprepo;

        public UpdateEmployeeCommandHandler(IEmployeeRepo repo, IMapEmployee map,IDepartmentRepo dprepo)
        {
            _repo = repo;
            _map = map;
            _dprepo = dprepo;
        }
        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empy=await _repo.FindAsync(request.Id);
            if (empy != null)
            {
                _repo.PatchUpdate(empy);
                UpdateCreateEmployee(request, empy);
                if (request.ManagerId != null)
                    empy.Manager = (await _repo.FindByPredicate(x => x.Id == request.ManagerId)).FirstOrDefault();

                if (request.DepartmentId != null)
                    empy.Department = await _dprepo.FindAsync(request.Id); 
               
                await _repo.Complete();
                return _map.EntityToResponse(empy);
            }
            else
                throw new ArgumentException("record not found.");
           
        }
        private void UpdateCreateEmployee(UpdateEmployeeCommand request,Employee employee)
        {
            employee.Nationality = request.Nationality;
            employee.ConfirmedStatus = request.ConfirmedStatus;
            employee.ContactAddress = request.ContactAddress;
            employee.DateEmployed = request.DateEmployed;
            employee.DOB = request.DOB;
            employee.FirstName = request.FirstName;
            employee.Surname= request.Surname;
            employee.OtherName = request.OtherName;
            employee.Gender = request.Gender;
            employee.PhoneNo= request.PhoneNo;
            employee.StateOfOrigin= request.StateOfOrigin;
            employee.LastModifyDate = DateTime.Now;

            employee.NextOfKingPhoneNo = request.NextOfKingPhoneNo;
            employee.NextOfKingEmail= request.NextOfKingEmail;
            employee.NextOfKingSurName= request.NextOfKingSurName;
            employee.NextOfKingFirstName= request.NextOfKingFirstName;
            employee.NextOfKingAddress= request.NextOfKingAddress;
            employee.Relationship= request.Relationship;

            employee.ContractType = request.ContractType;
            employee.StaffId = request.StaffId;
            employee.JobRole = request.JobRole;
            employee.RecievedOfferLetter= request.RecievedOfferLetter;
            employee.WorkType = request.WorkType;
            employee.LastDatePromoted= request.LastDatePromoted;
            employee.JobLocation= request.JobLocation;

            employee.SpouseName = request.SpouseName;
            employee.SpousePhoneNumber = request.SpousePhoneNumber;
            employee.SpouseProfession = request.SpouseProfession;
            employee.ResidentialAddress = request.ResidentialAddress;
            employee.NumberOfChildren = request.NumberOfChildren;
            employee.DateOfBirth = request.DateOfBirth;
    }
    }
}
