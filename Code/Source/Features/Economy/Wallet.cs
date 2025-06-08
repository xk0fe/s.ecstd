using System;

namespace Sandbox.Source.Features.Economy
{
    public class Wallet
    {
        private int _currentMoney;
        
        public int CurrentMoney
        {
	        get => _currentMoney;
	        private set
	        {
		        var appliedValue = Math.Min(value, MaxMoney); // cannot exceed MaxMoney
		        _currentMoney = Math.Max( 0, appliedValue ); // cannot be negative
	        }
        }

        public int MaxMoney { get; private set; } = int.MaxValue;
        
        // Events for UI updates and game logic
        public event Action<int, int> MoneyChanged; // oldAmount, newAmount
        public event Action<int> MoneyAdded;
        public event Action<int> MoneySpent;
        
        public Wallet(int startingMoney = 0, int maxMoney = int.MaxValue)
        {
            if (startingMoney < 0)
                throw new ArgumentException("Starting money cannot be negative", nameof(startingMoney));
            if (maxMoney < 0)
                throw new ArgumentException("Max money cannot be negative", nameof(maxMoney));
            
            MaxMoney = maxMoney;
            CurrentMoney = Math.Min(startingMoney, maxMoney);
        }
        
        public bool TryAddCurrency(int amount)
        {
            if (amount <= 0)
                return false;
            
            // Check for overflow and max capacity
            if (CurrentMoney > MaxMoney - amount)
            {
                // Add only what we can fit
                var amountToAdd = MaxMoney - CurrentMoney;
                if (amountToAdd > 0)
                {
                    var oldAmount = CurrentMoney;
                    CurrentMoney += amountToAdd;
                    OnMoneyChanged(oldAmount, CurrentMoney);
                    OnMoneyAdded(amountToAdd);
                }
                return false; // Couldn't add the full amount
            }
            
            var previousAmount = CurrentMoney;
            CurrentMoney += amount;
            OnMoneyChanged(previousAmount, CurrentMoney);
            OnMoneyAdded(amount);
            return true;
        }
        
        public bool TrySpendCurrency(int amount)
        {
            if (amount <= 0)
                return false;
            
            if (CurrentMoney < amount)
                return false;
            
            var previousAmount = CurrentMoney;
            CurrentMoney -= amount;
            OnMoneyChanged(previousAmount, CurrentMoney);
            OnMoneySpent(amount);
            return true;
        }
        
        public bool CanAfford(int amount)
        {
            return amount > 0 && CurrentMoney >= amount;
        }
        
        public void SetMoney(int amount)
        {
	        if ( amount < 0 )
	        {
		        Log.Error( "Trying to set negative amount of money" );
	        }
	        
            var oldAmount = CurrentMoney;
            CurrentMoney = amount;
            OnMoneyChanged(oldAmount, CurrentMoney);
        }
        
        public void Reset()
        {
            var oldAmount = CurrentMoney;
            CurrentMoney = 0;
            OnMoneyChanged(oldAmount, CurrentMoney);
        }
        
        private void OnMoneyChanged(int oldAmount, int newAmount)
        {
            MoneyChanged?.Invoke(oldAmount, newAmount);
        }
        
        private void OnMoneyAdded(int amount)
        {
            MoneyAdded?.Invoke(amount);
        }
        
        private void OnMoneySpent(int amount)
        {
            MoneySpent?.Invoke(amount);
        }
        
        public override string ToString()
        {
            return $"Wallet: ${CurrentMoney:N0}";
        }
    }
}
