using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic
{
    public class Money:ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCentCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }
        public decimal Amount { 
            get {
                return OneCentCount * 0.01m +
                    TenCentCount * 0.10m +
                    QuarterCentCount * 0.25m +
                    OneDollarCount +
                    FiveDollarCount * 5.0m +
                    TwentyDollarCount * 20.0m;
            } 
        }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {

            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0) 
                throw new InvalidOperationException();
            if (quarterCentCount < 0) 
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();

            OneCentCount += oneCentCount;
            TenCentCount += tenCentCount;
            QuarterCentCount += quarterCentCount;
            OneDollarCount += oneDollarCount;
            FiveDollarCount += fiveDollarCount;
            TwentyDollarCount += twentyDollarCount;
        }

        

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(                
                money1.OneCentCount += money2.OneCentCount,
                money1.TenCentCount += money2.TenCentCount,
                money1.QuarterCentCount += money2.QuarterCentCount,
                money1.OneDollarCount += money2.OneDollarCount,
                money1.FiveDollarCount += money2.FiveDollarCount,
                money1.TwentyDollarCount += money2.TwentyDollarCount);
            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount -= money2.OneCentCount,
                money1.TenCentCount -= money2.TenCentCount,
                money1.QuarterCentCount -= money2.QuarterCentCount,
                money1.OneDollarCount -= money2.OneDollarCount,
                money1.FiveDollarCount -= money2.FiveDollarCount,
                money1.TwentyDollarCount -= money2.TwentyDollarCount);
            return sum;
        }

        public override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount &&
                   TenCentCount == other.TenCentCount &&
                   QuarterCentCount == other.QuarterCentCount &&
                   OneDollarCount == other.OneDollarCount &&
                   FiveDollarCount == other.FiveDollarCount &&
                   TwentyDollarCount == other.TwentyDollarCount;
                   
        }

        public override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCentCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }
    }


}
