using System;
using UnityEngine;

public class StringHelper
{
    public const string ONOFF_MUSIC = "ONOFF_MUSIC";
    public const string ONOFF_SOUND = "ONOFF_SOUND";
    public const string ONOFF_VIB = "ONOFF_VIB";
    public const string COIN = "CoinsAmount";

    public const string LEVEL = "Level";

    // Booster
    public const string BOOSTER_1 = "PickFoodCount";
    public const string BOOSTER_2 = "SwapFoodPositionsCount";
    public const string BOOSTER_3 = "PauseTimerCount";


    #region HEART_STRING

    #endregion

    public const string HEART = "HEART";
    public const string IS_UNLIMITER_HEART = "IS_UNLIMITER_HEART";
    public const string TIME_UNLIMITER_HEART = "TIME_UNLIMITER_HEART";
    public const string TIME_LAST_OVER_HEART = "TIME_LAST_OVER_HEART";


    public const string REMOVE_ADS = "REMOVE_ADS";

    public const string LAST_TIME_LOGIN = "LastTimeLogin";
    
    
    public const string IS_BACK_LOBBY_OPTION = "IS_BACK_LOBBY_OPTION";

    // Done Tut booster 
    public const string IS_DONE_TUT_BOOSTER_1 = "IS_DONE_TUT_BOOSTER_SWAP";
    public const string IS_DONE_TUT_BOOSTER_2 = "IS_DONE_TUT_BOOSTER_PICK";
    public const string IS_DONE_TUT_BOOSTER_3 = "IS_DONE_TUT_BOOSTER_FREEZE";
    
    /// Remote Config Key
    public const string KEY_STARTING_COINS = "initial_coin";

    public const string KEY_COIN_PACK_REWARDS = "shop_coinpack";

    public const string KEY_LUCKY_WHEEL_DATA = "luckywheel_data";
    public const string KEY_SPIN_WHEEL_COST = "luckywheel_costSpin";
    public const string KEY_IS_LUCKY_WHEEL_ENABLED = "luckywheel_isEnable";

    public const string KEY_COINS_PER_LEVEL = "winpopup_coinQuantity";
    public const string KEY_MULTI_COINS = "winpopup_coinMulti";


    public const string KEY_SKIN_BASE_COST = "skinnavbar_startCost";
    public const string KEY_SKIN_UPGRADE_COST = "skinnavbar_growthCost";

    public const string KEY_IS_CHEAT_ENABLED = "cheat_isEnable";
    public const string KEY_IS_REMOVE_ADS_PACK_VISIBLE = "removeads_isEnable";
    public const string KEY_IS_BANNER_AD_ENABLED = "banner_isEnable";
    public const string KEY_IS_INTERSTITIAL_AD_ENABLED = "interstitital_isEnable";
    public const string KEY_APP_OPNED_AD_ENABLED = "aoa_isEnable";

    public const string KEY_LEVEL_UNLOCK_SKIN = "skinnavbar_unlocklevel";

    public const string KEY_LEVEL_UNLOCK_BOOSTER = "unlock_booster";
    public const string KEY_INITIAL_AMOUNT_BOOSTER = "claim_booster";
    public const string KEY_BUY_BOOSTER = "cost_booster";

    public const string KEY_LEVEL_SHOW_BANNER_ADS = "banner_startLevel";
    public const string KEY_LEVEL_SHOW_INTERS_ADS = "interstitial_startLevel";
    public const string KEY_LEVELS_BETWEEN_INTERS = "interstitial_intervalLevel";

    public const string KEY_RESTORE_HEART_COST = "restoreheartpopup_cost";
    public const string KEY_RESTORE_HEART_QUANTITY = "restoreheartpopup_quantity";
    public const string KEY_MAX_HEART = "max_heart";
    public const string KEY_MINUTE_HEART_REFILL = "recoverytime_heart";

    public const string KEY_CONTINUE_POPUP_COST = "continuepopup_cost";
    public const string KEY_CONTINUE_POPUP_BONUS_TIME = "continuepopup_bonusTime";

    public const string KEY_CUSTOMER_LEVEL_APPEAR = "customer_level_appear";
    public const string KEY_CUSTOMER_ORDER_COMPLETION = "customer_order_completion";
    public const string KEY_CUSTOMER_SKIP_COST_COIN = "customer_skip_cost_coin";
    public const string KEY_CUSTOMER_WAIT_TIME_PER_ITEM = "customer_wait_time_per_item";
    public const string KEY_CUSTOMER_SPAWN_INTERVAL = "customer_spawn_interval";
    public const string KEY_CUSTOMER_MIN_INVENTORY_THRESHOLD = "customer_min_inventory_threshold";
    public const string KEY_CUSTOMER_INITIAL_DELAY = "customer_initial_delay";

    public const string KEY_PETCAT_DATA = "petcat_data";
    public const string KEY_PETCAT_LEVEL_APPEAR = "petcat_level_appear";
    public const string KEY_PETCAT_SPAWN_INTERVAL = "petcat_spawn_interval";
    public const string KEY_PETCAT_INITIAL_DELAY = "petcat_initial_delay";


    /// TutorialLevel10 Config Key
    public const string IS_DONE_TUT_CUMTOMER = "IS_DONE_TUT_CUMTOMER";

    /// DailyQuest Config Key
    public const string KEY_DAILYQUEST_JSON = "KEY_DAILYQUEST_JSON";

    public const string KEY_DAILYQUEST_CONFIG = "dailyquest";

    public const string KEY_QUEST_REWARD_CONFIG = "questreward";

    public const string KEY_REWARDS_VIDEO_BAR_ITEM_ROW = "watchadspopup_data";

    /// DailyQuestReward Config Key
    public const string KEY_REWARD_DAILYQUEST_COIN = "Coin";

    public const string KEY_REWARD_DAILYQUEST_BOOSTER1 = "Booster1";
    public const string KEY_REWARD_DAILYQUEST_BOOSTER2 = "Booster2";
    public const string KEY_REWARD_DAILYQUEST_BOOSTER3 = "Booster3";

    //VIDEO BAR
    public const string CURRENT_PROGRESS_VIDEO_BAR = "CURRENT_PROGRESS_VIDEO_BAR";

    //WheelSpine
    public const string KEY_LAST_WHEEL_SPINE = "KEY_LAST_WHEEL_SPINE";
}

public class SceneName
{
    public const string GAME_PLAY = "GamePlayScene";
    public const string LOBBY_SCENE = "LobbyScene";
    public const string LOADING_SCENE = "LoadingScene";
}

public static class UseProfile
{
    public static int DefaultBoosterAmount = 3;
    public static int DefaultStartingCoins = 500;

    public static readonly PrefVar<int> Level = new(StringHelper.LEVEL, 1);
    public static readonly PrefVar<int> Booster1 = new(StringHelper.BOOSTER_1, DefaultBoosterAmount);
    public static readonly PrefVar<int> Booster2 = new(StringHelper.BOOSTER_2, DefaultBoosterAmount);
    public static readonly PrefVar<int> Booster3 = new(StringHelper.BOOSTER_3, DefaultBoosterAmount);
    public static readonly PrefVar<int> Coin = new(StringHelper.COIN, DefaultStartingCoins);
    
    // --- SETTINGS ---
    public static readonly PrefVar<bool> OnMusic = new(StringHelper.ONOFF_MUSIC, true);
    public static readonly PrefVar<bool> OnSound = new(StringHelper.ONOFF_SOUND, true);
    public static readonly PrefVar<bool> OnVib = new(StringHelper.ONOFF_VIB, true);

    // --- TIM & QUẢNG CÁO ---
    public static readonly PrefVar<int> Heart = new(StringHelper.HEART, 5);
    public static readonly PrefVar<bool> IsUnlimitedHeart = new(StringHelper.IS_UNLIMITER_HEART, false);
    public static readonly PrefVar<bool> IsRemoveAds = new(StringHelper.REMOVE_ADS, false);

    // --- TUTORIAL & TIẾN TRÌNH ---
    public static readonly PrefVar<bool> IsDoneBooster1 = new(StringHelper.IS_DONE_TUT_BOOSTER_1, false);
    public static readonly PrefVar<bool> IsDoneBooster2 = new(StringHelper.IS_DONE_TUT_BOOSTER_2, false);
    public static readonly PrefVar<bool> IsDoneBooster3 = new(StringHelper.IS_DONE_TUT_BOOSTER_3, false);
    // ========================================================
    // --- XỬ LÝ THỜI GIAN (TÍCH HỢP TIMEMANAGER) ---
    // ========================================================
    
    public static DateTime TimeUnlimitedHeart
    {
        get => DateTime.FromBinary(GamePrefs.Get(StringHelper.TIME_UNLIMITER_HEART, TimeManager.GetCurrentTime().AddDays(-1).ToBinary()));
        set => GamePrefs.Set(StringHelper.TIME_UNLIMITER_HEART, value.ToBinary());
    }

    public static DateTime TimeLastOverHeart
    {
        get => DateTime.FromBinary(GamePrefs.Get(StringHelper.TIME_LAST_OVER_HEART, TimeManager.GetCurrentTime().ToBinary()));
        set => GamePrefs.Set(StringHelper.TIME_LAST_OVER_HEART, value.ToBinary());
    }

    public static DateTime LastTimeLogin
    {
        get => DateTime.FromBinary(GamePrefs.Get(StringHelper.LAST_TIME_LOGIN, TimeManager.GetCurrentTime().ToBinary()));
        set => GamePrefs.Set(StringHelper.LAST_TIME_LOGIN, value.ToBinary());
    }
}