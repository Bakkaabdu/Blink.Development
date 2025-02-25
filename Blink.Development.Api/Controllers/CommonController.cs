using AutoMapper;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public CommonController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
