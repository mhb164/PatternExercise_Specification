using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
