namespace Exercise.ObjectOriented
{
    public class NotConfimedSpecification : Specification<Campaign>
    {
        public NotConfimedSpecification()
        {
        }

        public override bool IsSatisfiedBy(Campaign campaign)
           => campaign.Confirmed == false;
    }

}
