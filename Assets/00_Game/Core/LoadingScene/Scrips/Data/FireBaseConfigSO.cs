using System.Collections.Generic;
using Firebase.RemoteConfig;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "new FireBaseConfigSO", menuName = "DATA/FIRE BASE CONFIG")]
public class FireBaseConfigSO : ScriptableObject
{



    [Range(1, 40000)]
    [SerializeField] private int[] coinPackRewards = new int[] { 400, 500, 1200, 4000, 10000, 15000 };
    [Header("Spin Wheel")]
    [SerializeField]
    private WheelSpinData[] wheelSpinDatas = new WheelSpinData[]
    {
        WheelSpinData.Coin(1000, 68),
        WheelSpinData.Coin(1500, 43),
        WheelSpinData.Booster1(1, 49),
        WheelSpinData.Booster2(1, 56),
        WheelSpinData.Booster3(1, 56),
    };
    [SerializeField] private bool isLuckyWheelEnabled = true;
    [SerializeField] private int spinWheelCost = 100;

    [Header("Lobby")]
    [SerializeField] private int startingCoins = 50;
    [SerializeField] private int maxHeart = 5;
    [SerializeField] private int minuteRecoveryHeart = 30;

    [Header("Win")]
    [SerializeField] private int coinsRewardPerLevel = 50;


    [Header("Skin Shop")]
    [SerializeField] private int skinUpgradeCost = 50;
    [SerializeField] private int skinBaseCost = 50;

    [SerializeField] private int levelUnlockSkin = 5;

    [Header("Cheat")]
    [SerializeField] private bool isCheatEnabled = false;

    [Header("Ads")]
    [SerializeField] private bool isRemoveAdsPackVisible = true;
    [SerializeField] private bool isBannerAdEnabled = false;
    [SerializeField] private bool isInterstitialAdEnabled = true;

    [SerializeField] private bool isAppOpendAdsEnabled = true;
    [SerializeField] private int levelShowBanner = 1;
    [SerializeField] private int levelShowInters = 10;
    [SerializeField] private int levelsBetweenInterstitial = 2;

    [Header("Booster Unlock")]
    [SerializeField] private int[] levelUnlockBoosters = new int[] { 3, 6, 9 };
    [Range(1, 100)]
    [SerializeField] private int initialAmountBooster = 2;

    [Range(50, 1000)]
    [SerializeField] private int[] costBuyBoosters = new int[] { 50, 100, 150 };

    [Header("Restore Popup")]
    [SerializeField] private int restoreHeartQuantity = 1;
    [SerializeField] private int restoreHeartCost = 50;


    [Header("Continue Popup")]
    [SerializeField] private int continueBonusTime = 60;
    [SerializeField] private int continueCost = 300;


    [Header("Win Popup")]
    [Range(2, 10)]
    [SerializeField] private int[] multiCoins = new int[] { 2, 3, 4, 3, 2 };


    [Header("Customer")]
    [SerializeField] int customerLevelAppear = 10;
    [SerializeField] int customerOrderCompletion = 1;
    [SerializeField] int customerSkipCostCoin = 20;
    [SerializeField] int customerWaitTimePerItem = 30;
    [SerializeField] int customerSpawnInterval = 20;
    [SerializeField] int customerMinInventoryThreshold = 15;
    [SerializeField] int customerInitialDelay = 10;

    [Header("---DailyQuest---")]
    [Header("Video Bar")]
   // [SerializeField] VideoBarItemRow[] videoBarItemRows;

    [Header("Cat Ads")]
    [SerializeField] int petLevelAppear = 5;
    [SerializeField] int petCatSpawnInterval = 30;
    [SerializeField] int petCatInitialDelay = 20;
    //[SerializeField] CatDataReward[] catDataRewards;



    public void Init()
    {
        _totalKeysDeclared = 0;
        _totalKeysLoaded = 0;

        // Coin Packs
        coinPackRewards = GetRemoteValueJson(StringHelper.KEY_COIN_PACK_REWARDS, coinPackRewards);

        // Lucky Wheel
        wheelSpinDatas = GetRemoteValueJson(StringHelper.KEY_LUCKY_WHEEL_DATA, wheelSpinDatas);
        spinWheelCost = GetRemoteValueJson(StringHelper.KEY_SPIN_WHEEL_COST, spinWheelCost);
        isLuckyWheelEnabled = GetRemoteValueJson(StringHelper.KEY_IS_LUCKY_WHEEL_ENABLED, isLuckyWheelEnabled);

        // Coins
        startingCoins = GetRemoteValueJson(StringHelper.KEY_STARTING_COINS, startingCoins);
        coinsRewardPerLevel = GetRemoteValueJson(StringHelper.KEY_COINS_PER_LEVEL, coinsRewardPerLevel);
        multiCoins = GetRemoteValueJson(StringHelper.KEY_MULTI_COINS, multiCoins);

        // Skin Shop
        skinUpgradeCost = GetRemoteValueJson(StringHelper.KEY_SKIN_UPGRADE_COST, skinUpgradeCost);
        skinBaseCost = GetRemoteValueJson(StringHelper.KEY_SKIN_BASE_COST, skinBaseCost);
        levelUnlockSkin = GetRemoteValueJson(StringHelper.KEY_LEVEL_UNLOCK_SKIN, levelUnlockSkin);

        // Cheat
        isCheatEnabled = GetRemoteValueJson(StringHelper.KEY_IS_CHEAT_ENABLED, isCheatEnabled);

        // Ads
        isRemoveAdsPackVisible = GetRemoteValueJson(StringHelper.KEY_IS_REMOVE_ADS_PACK_VISIBLE, isRemoveAdsPackVisible);
        isBannerAdEnabled = GetRemoteValueJson(StringHelper.KEY_IS_BANNER_AD_ENABLED, isBannerAdEnabled);
        isInterstitialAdEnabled = GetRemoteValueJson(StringHelper.KEY_IS_INTERSTITIAL_AD_ENABLED, isInterstitialAdEnabled);
        isAppOpendAdsEnabled = GetRemoteValueJson(StringHelper.KEY_APP_OPNED_AD_ENABLED, isAppOpendAdsEnabled);
        levelShowBanner = GetRemoteValueJson(StringHelper.KEY_LEVEL_SHOW_BANNER_ADS, levelShowBanner);
        levelShowInters = GetRemoteValueJson(StringHelper.KEY_LEVEL_SHOW_INTERS_ADS, levelShowInters);
        levelsBetweenInterstitial = GetRemoteValueJson(StringHelper.KEY_LEVELS_BETWEEN_INTERS, levelsBetweenInterstitial);

        // Booster
        levelUnlockBoosters = GetRemoteValueJson(StringHelper.KEY_LEVEL_UNLOCK_BOOSTER, levelUnlockBoosters);
        initialAmountBooster = GetRemoteValueJson(StringHelper.KEY_INITIAL_AMOUNT_BOOSTER, initialAmountBooster);
        costBuyBoosters = GetRemoteValueJson(StringHelper.KEY_BUY_BOOSTER, costBuyBoosters);

        // Heart
        restoreHeartCost = GetRemoteValueJson(StringHelper.KEY_RESTORE_HEART_COST, restoreHeartCost);
        restoreHeartQuantity = GetRemoteValueJson(StringHelper.KEY_RESTORE_HEART_QUANTITY, restoreHeartQuantity);
        maxHeart = GetRemoteValueJson(StringHelper.KEY_MAX_HEART, maxHeart);
        minuteRecoveryHeart = GetRemoteValueJson(StringHelper.KEY_MINUTE_HEART_REFILL, minuteRecoveryHeart);

        //Continue popup
        continueBonusTime = GetRemoteValueJson(StringHelper.KEY_CONTINUE_POPUP_BONUS_TIME, continueBonusTime);
        continueCost = GetRemoteValueJson(StringHelper.KEY_CONTINUE_POPUP_COST, continueCost);

        // Customer
        customerLevelAppear = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_LEVEL_APPEAR, customerLevelAppear);
        customerOrderCompletion = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_ORDER_COMPLETION, customerOrderCompletion);
        customerSkipCostCoin = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_SKIP_COST_COIN, customerSkipCostCoin);
        customerWaitTimePerItem = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_WAIT_TIME_PER_ITEM, customerWaitTimePerItem);
        customerSpawnInterval = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_SPAWN_INTERVAL, customerSpawnInterval);
        customerMinInventoryThreshold = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_MIN_INVENTORY_THRESHOLD, customerMinInventoryThreshold);
        customerInitialDelay = GetRemoteValueJson(StringHelper.KEY_CUSTOMER_INITIAL_DELAY, customerInitialDelay);

        // DailyQuest
        

        // Video Bar
        //videoBarItemRows = GetRemoteValueJson(StringHelper.KEY_REWARDS_VIDEO_BAR_ITEM_ROW, videoBarItemRows);

        //Cat
        petLevelAppear = GetRemoteValueJson(StringHelper.KEY_PETCAT_LEVEL_APPEAR, petLevelAppear);
        petCatSpawnInterval = GetRemoteValueJson(StringHelper.KEY_PETCAT_SPAWN_INTERVAL, petCatSpawnInterval);
        petCatInitialDelay = GetRemoteValueJson(StringHelper.KEY_PETCAT_INITIAL_DELAY, petCatInitialDelay);
        //catDataRewards = GetRemoteValueJson(StringHelper.KEY_PETCAT_DATA, catDataRewards);


        DebugRemote();
    }

    private void DebugRemote()
    {
        bool allLoaded = _totalKeysLoaded == _totalKeysDeclared;
        string color = allLoaded ? "lime" : "orange";
        Debug.Log($"<color={color}>{'═'.ToString().PadRight(60, '═')}</color>");
        Debug.Log($"<color={color}>📋 Remote Config Summary: {_totalKeysLoaded}/{_totalKeysDeclared} keys loaded successfully</color>");
        if (!allLoaded)
            Debug.LogWarning($"<color=orange>⚠ {_totalKeysDeclared - _totalKeysLoaded} key(s) missing or failed — using default values</color>");
        Debug.Log($"<color={color}>{'═'.ToString().PadRight(60, '═')}</color>");
    }

    private ConfigValue GetRemoteValue(string key) => FirebaseRemoteConfig.DefaultInstance.GetValue(key);

    private int _totalKeysDeclared = 0;
    private int _totalKeysLoaded = 0;
    private T GetRemoteValueJson<T>(string key, T defaultValue)
    {
        _totalKeysDeclared++;
        var json = GetRemoteValue(key).StringValue;

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(json);
                _totalKeysLoaded++;
                Debug.Log($"<color=cyan>✔ Remote Config loaded: <b>{key}</b> = {json}</color>");
                return result;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"<color=red>✘ Remote Config parse error: <b>{key}</b> — {e.Message} | Using default: {defaultValue}</color>");
            }
        }
        else
        {
            // ← thêm log này
            Debug.LogWarning($"<color=orange>⚠ Remote Config missing or empty: <b>{key}</b> | Using default: {JsonConvert.SerializeObject(defaultValue)}</color>");
        }

        return defaultValue;
    }
    #region Coin Pack Rewards
    public int GetCoinPackReward(int packIndex)
    {
        if (coinPackRewards == null || packIndex < 0 || packIndex >= coinPackRewards.Length)
        {
            Debug.LogError($"Invalid coin pack index: {packIndex}. Valid range: 0-{coinPackRewards?.Length - 1 ?? 0}");
            return 0;
        }
        return coinPackRewards[packIndex];
    }

    public int GetCoinPackCount() => coinPackRewards?.Length ?? 0;

    public int[] GetAllCoinPackRewards() => coinPackRewards;
    #endregion

    #region Lucky Wheel
    public WheelSpinData[] GetWheelSpinDatas() => wheelSpinDatas;

    public int GetSpinWheelCost() => spinWheelCost;

    public bool IsLuckyWheelEnabled() => isLuckyWheelEnabled;

    #endregion

    #region LOBBY
    public int GetStartingCoins() => startingCoins;

    public int GetCoinsRewardPerLevel() => coinsRewardPerLevel;

    public int GetMaxHeart() => maxHeart;

    public int GetMinuteRecoveryHeart() => minuteRecoveryHeart;


    #endregion

    #region Skin Shop
    public int GetSkinUpgradeCost() => skinUpgradeCost;

    public int GetSkinBaseCost() => skinBaseCost;

    public int GetLevelUnlockSkin() => levelUnlockSkin;

    #endregion

    #region Cheat
    public bool IsCheatEnabled() => isCheatEnabled;
    #endregion

    #region Ads
    public bool IsRemoveAdsPackVisible() => isRemoveAdsPackVisible;

    public bool IsBannerAdEnabled() => isBannerAdEnabled;

    public bool IsInterstitialAdEnabled() => isInterstitialAdEnabled;

    public bool IsAppOpendAdsEnabled() => isAppOpendAdsEnabled;

    public int GetLevelShowBanner() => levelShowBanner;
    public int GetLevelShowInters() => levelShowInters;

    public int GetLevelBetweenInters() => levelsBetweenInterstitial;
    #endregion

    #region Booster Unlock

    public int[] GetLevelUnlockBooster() => levelUnlockBoosters;

    public int GetInititalAmountBooster() => initialAmountBooster;
    public int[] GetCostBuyBoosters() => costBuyBoosters;
    #endregion


    #region  Heart
    public int GetRestoreHeartCost() => restoreHeartCost;
    public int GetResotreHeartQuantity() => restoreHeartQuantity;
    #endregion

    #region Continue Popup
    public int GetContinueCost() => continueCost;
    public int GetContinueBonusTime() => continueBonusTime;
    #endregion

    #region  Win Popup
    public int[] GetMultiCoins() => multiCoins;
    #endregion

    #region Customer
    public int GetCustomerLevelAppear() => customerLevelAppear;
    public int GetCustomerOrderCompletion() => customerOrderCompletion;
    public int GetCustomerSkipCostCoin() => customerSkipCostCoin;
    public int GetCustomerWaitTimePerItem() => customerWaitTimePerItem;
    public int GetCustomerSpawnInterval() => customerSpawnInterval;
    public int GetCustomerrMinInventoryThreshold() => customerMinInventoryThreshold;
    public int GetCustomerInitialDelay() => customerInitialDelay;
    #endregion
    #region DailyQuest

    #endregion 

    #region Video Bar
    //public VideoBarItemRow[] GetRewardsVideoBar() => videoBarItemRows;
    #endregion

    #region  PetCat

    //public CatDataReward[] GetCatDataRewards() => catDataRewards;
    public int GetPetCatLevelAppear() => petLevelAppear;
    public int GetPetCatSpawnInterval() => petCatSpawnInterval;
    public int GetPetCatInitialDelay() => petCatInitialDelay;
    #endregion




}



[System.Serializable]
public struct WheelSpinData
{
    [JsonProperty("type")]
    public string type;

    [Range(1, 20000)]
    [JsonProperty("quantity")]
    public int quantity;

    [Range(0, 100)]
    [JsonProperty("rate")]
    public int rate;

    public static WheelSpinData Coin(int quantity, int rate) => new() { type = "coin", quantity = quantity, rate = rate };
    public static WheelSpinData Heart(int quantity, int rate) => new() { type = "heart", quantity = quantity, rate = rate };
    public static WheelSpinData Booster1(int quantity, int rate) => new() { type = "booster1", quantity = quantity, rate = rate };
    public static WheelSpinData Booster2(int quantity, int rate) => new() { type = "booster2", quantity = quantity, rate = rate };
    public static WheelSpinData Booster3(int quantity, int rate) => new() { type = "booster3", quantity = quantity, rate = rate };

}
