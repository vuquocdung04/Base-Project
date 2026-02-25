
public class CurrencyManager
{
    public int TotalCoin() => UseProfile.Coin;
    
    public void AddCoin(int amount)
    {
        UseProfile.Coin += amount;
    }

    public bool TrySubtractCoin(int amount)
    {
        if(amount < 0) return false;
        if (UseProfile.Coin < amount) return false;
        
        UseProfile.Coin -= amount;
        return true;
    }
}