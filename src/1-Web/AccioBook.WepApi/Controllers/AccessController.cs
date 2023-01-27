using AccioBook.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;
        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }
    }
}
