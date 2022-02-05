using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
