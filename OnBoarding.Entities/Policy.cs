namespace OnBoarding.Entities
{
    using System;

    public class Policy
    {
        public Guid Id { get; set; }

        public int PolicyId { get; set; }

        public string Code { get; set; }

        public decimal Premium { get; set; }

        public decimal PolicyBenifit { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime MaturityDate { get; set; }

        public bool IsActive { get; set; }
    }
}
