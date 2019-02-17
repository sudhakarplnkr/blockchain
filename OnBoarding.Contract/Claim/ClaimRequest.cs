namespace OnBoarding.Contract.Claim
{
    using MediatR;

    public class ClaimRequest : IRequest<Claim>
    {
        public ClaimRequest(ClaimRequestModel claimRequestModel)
        {
            ClaimRequestModel = claimRequestModel;
        }
        public ClaimRequestModel ClaimRequestModel { get; set; }
    }
}
