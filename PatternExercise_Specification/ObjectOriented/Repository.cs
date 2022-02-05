using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.ObjectOriented
{
    public class Repository<T>
    {
        public Repository(List<T> items)
        {
            this.items = items;
        }
        List<T> items;
        public IEnumerable<T> Items => items;

        public List<T> Find(Specification<T> specification)
        {
            var result = new List<T>();
            foreach (var item in items)
            {
                if (specification.IsSatisfiedBy(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
