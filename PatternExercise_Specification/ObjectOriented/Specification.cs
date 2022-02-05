using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.ObjectOriented
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T entity);

        public Specification<T> And(Specification<T> specification) => new AndSpecification<T>(this, specification);
        public Specification<T> Or(Specification<T> specification) => new OrSpecification<T>(this, specification);
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override bool IsSatisfiedBy(T entity)
            => _right.IsSatisfiedBy(entity) && _left.IsSatisfiedBy(entity);
    }

    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override bool IsSatisfiedBy(T entity)
           => _right.IsSatisfiedBy(entity) || _left.IsSatisfiedBy(entity);
    }
}