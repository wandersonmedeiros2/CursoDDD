﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = None;
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();
            
            MoneyInTransaction += money;            
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BusySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }


    }
}
