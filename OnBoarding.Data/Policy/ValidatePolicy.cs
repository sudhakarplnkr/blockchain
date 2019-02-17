namespace OnBoarding.Data
{
    using Contract.Repository;
    using MediatR;
    using OnBoarding.Contract.Policy;
    using System.Linq;

    public class ValidatePolicy : IRequestHandler<PolicyValidateRequest, Policy>
    {
        private readonly IRepository repository;
        public ValidatePolicy(IRepository repository)
        {
            this.repository = repository;
        }

        public Policy Handle(PolicyValidateRequest query)
        {
            var policy = this.repository.Query<Entities.Policy>().Where(i => i.PolicyId == query.PolicyId && i.IsActive).FirstOrDefault();
            if (policy == null)
            {
                return new Policy
                {
                    Status = false,
                    Message = "Invalid Policy"
                };
            }
            return new Policy
            {
                Status = true
            };
        }
    }
}
