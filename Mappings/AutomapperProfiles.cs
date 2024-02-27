using AutoMapper;
using GMP.API.Models.Domain;
using GMP.API.Models.DTO;
using Task = GMP.API.Models.Domain.Task;

namespace GMP.API.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ApplicantDto, Applicant>().ReverseMap();
            CreateMap<AwardeeDto, Awardees>().ReverseMap();
            CreateMap<DocumentDto, Document>().ReverseMap();
            CreateMap<GrantDto, Grant>().ReverseMap();
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<ReviewerDto, Reviewer>().ReverseMap();    
            CreateMap<TaskDto, Task>().ReverseMap();
            CreateMap<AddApplicantDto, Applicant>().ReverseMap();
            CreateMap<UpdateApplicantDto, Applicant>().ReverseMap();
            CreateMap<AddAwardeeDto, Awardees>().ReverseMap();    
            CreateMap<UpdateAwardeeDto, Awardees>().ReverseMap();
            CreateMap<AddGrantRequestDto, Grant>().ReverseMap();
            CreateMap<UpdateGrantRequestDto, Grant>().ReverseMap();
            CreateMap<AddTaskRequestDto, Task>().ReverseMap();
            CreateMap<UpdateTaskRequestDto, Task>().ReverseMap();
        }
    }
}
