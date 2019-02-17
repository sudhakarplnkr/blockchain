namespace OnBoarding.Contract.Claim
{
    using MediatR;

    public class ClaimRequestModel
    {
        public int PolicyId { get; set; }

        public string BillNumber { get; set; }

        public string Decise { get; set; }
    }
}
