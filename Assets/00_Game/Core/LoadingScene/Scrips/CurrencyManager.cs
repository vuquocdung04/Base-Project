
public class CurrencyManager
{
    public static int TotalCoin() => UseProfile.CurrentCoin;
    
    public static void AddCoin(int amount)
    {
        UseProfile.CurrentCoin += amount;
    }

    public static bool TrySubtractCoin(int amount)
    {
        if(amount < 0) return false;
        if (UseProfile.CurrentCoin < amount) return false;
        
        UseProfile.CurrentCoin -= amount;
        return true;
    }

    public static int TotalHeart() => UseProfile.Heart;

    public static void AddHeart(int amount)
    {
        UseProfile.Heart += amount;
        var maxHeart = LivesManager.Instance.maxHearts;
        if (UseProfile.Heart > maxHeart)
        {
            UseProfile.Heart = maxHeart;
        }
        EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.CHANGE_HEART, UseProfile.Heart);
    }

    public static bool TryUseHeart()
    {
        bool success = LivesManager.Instance.TryUseHeart();
        if (success) 
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.CHANGE_HEART, UseProfile.Heart);
        }
        return success;
    }

    public static void AddHeartUnlimitedHeart(int minutes)
    {
        LivesManager.Instance.AddUnlimitedHeart(minutes);
    }
}