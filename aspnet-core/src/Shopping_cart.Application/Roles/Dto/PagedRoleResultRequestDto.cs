using Abp.Application.Services.Dto;

namespace Shopping_cart.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

