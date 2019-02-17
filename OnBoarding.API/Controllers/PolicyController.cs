using MediatR;
using OnBoarding.Contract.Policy;
using System.Web.Http;

namespace OnBoardingWEB.Controllers
{
    [RoutePrefix("api/Policy")]
    public class PlicyController : ApiController
    {
        private readonly IMediator mediatr;

        public PlicyController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        [Route("Validate/{id}")]
        public Policy Validate(int id)
        {
            var response = this.mediatr.Send(new PolicyValidateRequest(id));

            return response.Result;
        }
    
    }
}
