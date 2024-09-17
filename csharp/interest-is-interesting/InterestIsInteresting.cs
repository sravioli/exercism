using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float interestRate = 2.475f;
        if (balance < 0) {
            interestRate = 3.213f;
        } else if (balance < 1000) {
            interestRate = 0.5f;
        } else if (balance >= 1000 && balance < 5000) {
            interestRate = 1.621f;
        }
        return interestRate;        
    }

    public static decimal Interest(decimal balance) => 
        balance * (decimal)InterestRate(balance) / 100;

    public static decimal AnnualBalanceUpdate(decimal balance) => 
        balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsBeforeDesiredBalance = 0;
        while (balance <= targetBalance) {
            balance = AnnualBalanceUpdate(balance);
            yearsBeforeDesiredBalance++;
        }
        return yearsBeforeDesiredBalance;
    }
}
