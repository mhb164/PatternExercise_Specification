using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.LinqExpression
{
    public class NotConfimedSpecification : Specification<Campaign>
    {
        public NotConfimedSpecification()
        {
        }

        public override Expression<Func<Campaign, bool>> ToExpression()
        {
            return campain => campain.Confirmed == false;
        }
    }

}
