using DashboardAPI.Dto;
using DashboardAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DashboardAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AuthorizeAttribute]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public ResponseDto<List<SelectedListItemDto>> GetAll()
        {
            var departmentList = new List<SelectedListItemDto>()
            {
                new SelectedListItemDto(){ Id=1,Name="Developemnt"},
                new SelectedListItemDto(){ Id=2,Name="Support"},
                new SelectedListItemDto(){ Id=3,Name="Sales"},
                new SelectedListItemDto(){ Id=4,Name="Marketing"},
                new SelectedListItemDto(){ Id=5,Name="Finance"},
                new SelectedListItemDto(){ Id=6,Name="Human Resoureces"}
            };
            return new ResponseDto<List<SelectedListItemDto>>() { Result = departmentList, IsSuccess = true };
        }
    }
}
