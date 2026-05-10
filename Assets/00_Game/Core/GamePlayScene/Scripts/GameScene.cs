
using UnityEngine;
using UnityEngine.UI;

public class GameScene : StaffSingleton<GameScene>
{
    public Transform popupHolder;


    [Header("Button")]
    public Button btnSetting;
    public Button btnCoin;
    public Button btnHeart;
    public override void Init()
    {
        btnSetting.OnClicked(delegate
        {
            _ = SettingBox.Setup(popupHolder, box => box.Show());
        });

        btnCoin.OnClicked(delegate
        {
            _ = ShopBox.Setup(popupHolder, box => box.Show());
        });

        btnHeart.OnClicked(delegate
        {
            
        });
    }

    public static Transform GetPopupHolder() => GameScene.Instance.popupHolder;
}
