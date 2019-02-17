namespace OnBoarding.Contract.Policy
{
    using MediatR;

    public class PolicyValidateRequest : IRequest<Policy>
    {
        public PolicyValidateRequest(int policyId)
        {
            PolicyId = policyId;
        }
        public int PolicyId { get; set; }
    }
}
