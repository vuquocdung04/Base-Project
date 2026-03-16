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
    public const string GAME_PLAY = "GamePlay";
    public const string LOBBY_SCENE = "LobbyScene";
    public const string LOADING_SCENE = "LoadingScene";
}

public class PathPrefabs
{
    private const string DEFAULT_PATH = "Assets/00_Game/PopupPrefabs/";
    public const string SETTINGS_PANEL = DEFAULT_PATH + "SettingsPanel.prefab";

    public const string SHOP_BOX = DEFAULT_PATH + "ShopBox.prefab";
    public const string RANK_BOX = DEFAULT_PATH + "RankBox.prefab";

    public const string LOBBY_BOX = DEFAULT_PATH + "LobbyBox.prefab";

    public const string RESTORE_HEART_BOX = DEFAULT_PATH + "RestoreHeartBox.prefab";
    public const string REMOVE_ADS_BOX = DEFAULT_PATH + "RemoveAdsBox.prefab";

    public const string WHEEL_SPIN_BOX = DEFAULT_PATH + "WheelSpinBox.prefab";

    public const string QUIT_LEVEL_BOX = DEFAULT_PATH + "QuitLevelBox.prefab";

    public const string RESULT_DISPLAY_SKIN_BOX = DEFAULT_PATH + "ResultDisplaySkinBox.prefab";
    public const string WIN_BOX = DEFAULT_PATH + "WinBox.prefab";
    public const string CONTINUE_BOX = DEFAULT_PATH + "ContinueBox.prefab";
    public const string LOSE_BOX = DEFAULT_PATH + "LoseBox.prefab";
    public const string BUY_SUCCESS_BOX = DEFAULT_PATH + "BuySuccessBox.prefab";
    public const string NEW_BOOSTER_UNLOCK_BOX = DEFAULT_PATH + "NewBoosterUnlockBox.prefab";
    public const string BUY_BOOSTER_BOX = DEFAULT_PATH + "BuyBoosterBox.prefab";
    public const string SKIP_ORDER_BOX = DEFAULT_PATH + "SkipOrderBox.prefab";
    public const string VIDEO_BAR_BOX = DEFAULT_PATH + "VideoBarBox.prefab";
    public const string DAILY_QUEST_BOX = DEFAULT_PATH + "DailyQuestBox.prefab";
    public const string GILT_OPEN_BOX = DEFAULT_PATH + "GiftOpenBox.prefab";
}

public static class UseProfile
{
    public static int DefaultBoosterAmount = 3;
    public static int DefaultStartingCoins = 500;

    public static int Level
    {
        get => PlayerPrefs.GetInt(StringHelper.LEVEL, 1);
        set
        {
            PlayerPrefs.SetInt(StringHelper.LEVEL, value);
            PlayerPrefs.Save();
        }
    }

    public static int Booster1
    {
        get => PlayerPrefs.GetInt(StringHelper.BOOSTER_1,
            DefaultBoosterAmount);
        set
        {
            PlayerPrefs.SetInt(StringHelper.BOOSTER_1, value);
            PlayerPrefs.Save();
        }
    }

    public static int Booster2
    {
        get => PlayerPrefs.GetInt(StringHelper.BOOSTER_2,
            DefaultBoosterAmount);
        set
        {
            PlayerPrefs.SetInt(StringHelper.BOOSTER_2, value);
            PlayerPrefs.Save();
        }
    }

    public static int Booster3
    {
        get => PlayerPrefs.GetInt(StringHelper.BOOSTER_3,
            DefaultBoosterAmount);
        set
        {
            PlayerPrefs.SetInt(StringHelper.BOOSTER_3, value);
            PlayerPrefs.Save();
        }
    }

    public static int CurrentCoin
    {
        get => PlayerPrefs.GetInt(StringHelper.COIN,
            DefaultStartingCoins);
        set
        {
            PlayerPrefs.SetInt(StringHelper.COIN, value);
            PlayerPrefs.Save();
        }
    }

    #region SOUND_MUSIC_VIB

    #endregion

    public static bool OnMusic
    {
        get => PlayerPrefs.GetInt(StringHelper.ONOFF_MUSIC, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.ONOFF_MUSIC, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool OnSound
    {
        get => PlayerPrefs.GetInt(StringHelper.ONOFF_SOUND, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.ONOFF_SOUND, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool OnVib
    {
        get => PlayerPrefs.GetInt(StringHelper.ONOFF_VIB, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.ONOFF_VIB, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    // Heart

    #region HEART

    #endregion

    public static int Heart
    {
        get => PlayerPrefs.GetInt(StringHelper.HEART, 5);
        set
        {
            PlayerPrefs.SetInt(StringHelper.HEART, value);
            PlayerPrefs.Save();
        }
    }

    public static DateTime TimeUnlimitedHeart
    {
        get
        {
            if (PlayerPrefs.HasKey(StringHelper.TIME_UNLIMITER_HEART))
            {
                var temp = Convert.ToInt64(PlayerPrefs.GetString(StringHelper.TIME_UNLIMITER_HEART));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = DateTime.Now.AddDays(-1);
                PlayerPrefs.SetString(StringHelper.TIME_UNLIMITER_HEART, newDateTime.ToBinary().ToString());
                PlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.TIME_UNLIMITER_HEART, value.ToBinary().ToString());
            PlayerPrefs.Save();
        }
    }

    public static bool IsUnlimitedHeart
    {
        get => PlayerPrefs.GetInt(StringHelper.IS_UNLIMITER_HEART, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_UNLIMITER_HEART, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static DateTime TimeLastOverHeart
    {
        get
        {
            if (PlayerPrefs.HasKey(StringHelper.TIME_LAST_OVER_HEART))
            {
                var temp = Convert.ToInt64(PlayerPrefs.GetString(StringHelper.TIME_LAST_OVER_HEART));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = DateTime.Now;
                PlayerPrefs.SetString(StringHelper.TIME_LAST_OVER_HEART, newDateTime.ToBinary().ToString());
                PlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.TIME_LAST_OVER_HEART, value.ToBinary().ToString());
            PlayerPrefs.Save();
        }
    }

    #region REMOVE_ADS

    #endregion

    public static bool IsRemoveAds
    {
        get { return PlayerPrefs.GetInt(StringHelper.REMOVE_ADS, 0) == 1; }
        set
        {
            PlayerPrefs.SetInt(StringHelper.REMOVE_ADS, value ? 1 : 0);
            PlayerPrefs.Save();
            // if (value && GoogleAds.Instance != null)
            // {
            //     GoogleAds.Instance.DestroyBanner();
            // }
        }
    }

    #region SettingType

    #endregion

    public static bool IsBackToLobbyOptionSetting
    {
        get { return PlayerPrefs.GetInt(StringHelper.IS_BACK_LOBBY_OPTION, 0) == 1; }
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_BACK_LOBBY_OPTION, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    #region Bool Tut

    #endregion

    public static bool IsDoneBooster1
    {
        get => PlayerPrefs.GetInt(StringHelper.IS_DONE_TUT_BOOSTER_1, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_DONE_TUT_BOOSTER_1, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool IsDoneBooster2
    {
        get => PlayerPrefs.GetInt(StringHelper.IS_DONE_TUT_BOOSTER_2, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_DONE_TUT_BOOSTER_2, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool IsDoneBooster3
    {
        get => PlayerPrefs.GetInt(StringHelper.IS_DONE_TUT_BOOSTER_3, 0) == 1;
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_DONE_TUT_BOOSTER_3, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    //VIDEO BAR

    public static int CurrentProgressVideoBar
    {
        get { return PlayerPrefs.GetInt(StringHelper.CURRENT_PROGRESS_VIDEO_BAR, 0); }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_PROGRESS_VIDEO_BAR, value);
            PlayerPrefs.Save();
        }
    }

    public static DateTime LastTimeLogin
    {
        get
        {
            if (PlayerPrefs.HasKey(StringHelper.LAST_TIME_LOGIN))
            {
                var temp = Convert.ToInt64(PlayerPrefs.GetString(StringHelper.LAST_TIME_LOGIN));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = DateTime.Now;
                PlayerPrefs.SetString(StringHelper.LAST_TIME_LOGIN, newDateTime.ToBinary().ToString());
                PlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.LAST_TIME_LOGIN, value.ToBinary().ToString());
            PlayerPrefs.Save();
        }
    }
}