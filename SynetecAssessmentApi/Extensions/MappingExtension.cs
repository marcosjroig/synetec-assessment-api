using System.Collections.Generic;
using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.Extensions
{
    public static class MappingExtension
    {
        public static IEnumerable<EmployeeDto> MapEmployeesToEmployeeDto(this IEnumerable<Employee> employees, IMapper mapper)
        {
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }
    }
}
