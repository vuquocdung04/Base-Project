
public class CurrencyManager
{
    public int TotalCoin() => UseProfile.CurrentCoin;
    
    public void AddCoin(int amount)
    {
        UseProfile.CurrentCoin += amount;
    }

    public bool TrySubtractCoin(int amount)
    {
        if(amount < 0) return false;
        if (UseProfile.CurrentCoin < amount) return false;
        
        UseProfile.CurrentCoin -= amount;
        return true;
    }
}