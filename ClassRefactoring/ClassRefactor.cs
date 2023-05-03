using System;

namespace DeveloperSample.ClassRefactoring
{
    public interface ISwallow
    {
        double GetAirspeedVelocity();
    }

    public abstract class SwallowBase : ISwallow
    {
        protected abstract double BaseAirspeedVelocity { get; }
        protected abstract double LoadFactor { get; }

        private readonly SwallowLoad _load;

        protected SwallowBase(SwallowLoad load)
        {
            _load = load;
        }

        public double GetAirspeedVelocity()
        {
            return BaseAirspeedVelocity - _load.GetLoadFactor() * LoadFactor;
        }
    }

    public class AfricanSwallow : SwallowBase
    {
        protected override double BaseAirspeedVelocity => 22;
        protected override double LoadFactor => 4;

        public AfricanSwallow(SwallowLoad load) : base(load)
        {
        }
    }

    public class EuropeanSwallow : SwallowBase
    {
        protected override double BaseAirspeedVelocity => 20;
        protected override double LoadFactor => 3;

        public EuropeanSwallow(SwallowLoad load) : base(load)
        {
        }
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public static class SwallowLoadExtensions
    {
        public static double GetLoadFactor(this SwallowLoad load)
        {
            switch (load)
            {
                case SwallowLoad.None:
                    return 0;
                case SwallowLoad.Coconut:
                    return 1;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
