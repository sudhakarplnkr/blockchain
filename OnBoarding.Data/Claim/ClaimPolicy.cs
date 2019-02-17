namespace OnBoarding.Data
{
    using Contract.Repository;
    using MediatR;
    using OnBoarding.Contract.Claim;
    using System.Linq;

    public class ClaimPolicy : IRequestHandler<ClaimRequest, Claim>
    {
        private readonly IRepository repository;
        public ClaimPolicy(IRepository repository)
        {
            this.repository = repository;
        }

        public Claim Handle(ClaimRequest query)
        {
            var policy = this.repository.Query<Entities.Policy>().Where(i => i.PolicyId == query.ClaimRequestModel.PolicyId && i.IsActive).FirstOrDefault();
            if (policy == null)
            {
                return new Claim
                {
                    Status = false,
                    Message = "Claim failed due to insufficient balance"
                };
            }
            return new Claim
            {
                Status = true,
                ClaimAmmount = 20000
            };
        }
    }
}
