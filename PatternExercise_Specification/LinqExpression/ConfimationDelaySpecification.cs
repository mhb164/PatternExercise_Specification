using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.LinqExpression
{   
    public class ConfimationDelaySpecification : Specification<Campaign>
    {
        private readonly double delayInDays;

        public ConfimationDelaySpecification(double delayInDays)
        {
            this.delayInDays = delayInDays;
        }

        public override Expression<Func<Campaign, bool>> ToExpression()
        {
            return campain => campain.ConfirmationDelay.TotalDays > delayInDays;
        }
    }
}
