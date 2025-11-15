using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Reason
{
    None = 0,
    WatchVideo = 1,
    WatchVideoClaimItemHome = 4,
}

public enum GiftType
{
    None = 0,
    RemoveAds = 1,
    Coin = 2,
    Heart = 3,
    Star = 4,
    HeartUnlimit = 5,
    
    BoosterBoxBuffet = 19,
    BoosterCompass = 20,
    BoosterFrozenTime = 21,
    BoosterHint = 22,
    BoosterMagicWand = 23,
    BoosterMagnet = 24,
    BoosterMagnifier = 25,
    BoosterTimeBuffer = 26,
    BoosterX2Star = 27,
}


[CreateAssetMenu(fileName = "GiftDataBase", menuName = "DATA/GiftDataBase", order = 1)]
public class GiftDataBase : ScriptableObject
{
    public List<GiftDataEntry> lsGiftData;

    public bool GetGift(GiftType giftType, out Gift gift)
    {
        var entry = lsGiftData.FirstOrDefault(g => g.type == giftType);

        if (entry != null)
        {
            gift = entry.giftData;
            return true;
        }

        gift = null;
        return false;
    }

    public void DeDuct(GiftType giftType, int amount)
    {
        switch (giftType)
        {
            case GiftType.Coin:
                UseProfile.Coin -= amount;
                break;
            case GiftType.Star:
                UseProfile.Star -= amount;
                break;
        }
    }

    public void Claim(GiftType giftType, int amount, Reason reason = Reason.None)
    {
        switch (giftType)
        {
            case GiftType.Coin:
                UseProfile.Coin += amount;
                break;
            case GiftType.Heart:
                UseProfile.Heart += amount;
                break;
            case GiftType.Star:
                UseProfile.Star += amount;
                break;
            case GiftType.RemoveAds:
                GameController.Instance.useProfile.IsRemoveAds = true;
                break;
            case GiftType.BoosterBoxBuffet:
                UseProfile.Booster_BoxBuffer += amount;
                break;
            case GiftType.BoosterCompass:
                UseProfile.Booster_Compass += amount;
                break;
            case GiftType.BoosterFrozenTime:
                UseProfile.Booster_FrozeTime += amount;
                break;
            case GiftType.BoosterHint:
                UseProfile.Booster_Hint += amount;
                break;
            case GiftType.BoosterMagicWand:
                UseProfile.Booster_MagicWand += amount;
                break;
            case GiftType.BoosterMagnet:
                UseProfile.Booster_Maget += amount;
                break;
            case GiftType.BoosterMagnifier:
                UseProfile.Booster_Magnifier += amount;
                break;
            case GiftType.BoosterTimeBuffer:
                UseProfile.Booster_TimeBuffer += amount;
                break;
            case GiftType.BoosterX2Star:
                UseProfile.Booster_X2Star += amount;
                break;
            case GiftType.HeartUnlimit:
                GameController.Instance.heartGame.AddUnlimitedHeart(amount);
                break;
        }
    }
}

[Serializable]
public class GiftDataEntry
{
    public GiftType type;
    public Gift giftData;
}

[Serializable]
public class Gift
{
    public Sprite giftSprite;
    //public GameObject giftAnim;
}