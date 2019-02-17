using MediatR;
using OnBoarding.Contract.Claim;
using System.Web.Http;

namespace OnBoardingWEB.Controllers
{
    [RoutePrefix("api/Claim")]
    public class ClaimController : ApiController
    {
        private readonly IMediator mediatr;

        public ClaimController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpPost]
        [Route("")]
        public Claim Claim(ClaimRequestModel claimRequestModel)
        {
            var response = this.mediatr.Send(new ClaimRequest(claimRequestModel));

            return response.Result;
        }
    
    }
}
