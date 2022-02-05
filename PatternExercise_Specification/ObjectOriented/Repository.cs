using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.ObjectOriented
{
    public class Repository<T>
    {
        public Repository(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }
        List<T> items;
        public IEnumerable<T> Items => items;

        public IEnumerable<T> Find(Specification<T> specification)
        {
            return items.Where(specification.IsSatisfiedBy)
                .ToList();
        }
    }
}
