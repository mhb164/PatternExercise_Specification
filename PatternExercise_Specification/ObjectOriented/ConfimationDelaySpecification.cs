namespace Exercise.ObjectOriented
{
    public class ConfimationDelaySpecification : Specification<Campaign>
    {
        private readonly double delayInDays;

        public ConfimationDelaySpecification(double delayInDays)
        {
            this.delayInDays = delayInDays;
        }

        public override bool IsSatisfiedBy(Campaign campaign)
            => campaign.ConfirmationDelay.TotalDays > delayInDays;
    }
}
