using DashboardAPI.Dto;
using DashboardAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AuthorizeAttribute]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public ResponseDto<List<SelectedListItemDto>> GetAll()
        {
            var locationList = new List<SelectedListItemDto>()
            {
                new SelectedListItemDto(){ Id=1,Name="Brighton"},
                new SelectedListItemDto(){ Id=2,Name="Camberley"},
                new SelectedListItemDto(){ Id=3,Name="Southamption"},
                new SelectedListItemDto(){ Id=4,Name="Birmingham"},
                new SelectedListItemDto(){ Id=5,Name="Leicester"},
                new SelectedListItemDto(){ Id=6,Name="Londan"}
            };
            return new ResponseDto<List<SelectedListItemDto>>() { Result = locationList, IsSuccess = true };
        }
    }
}
