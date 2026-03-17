using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LobbyBox : BaseBox<LobbyBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<LobbyBox> onComplete)
    {
        return Setup(PathPrefabs.LOBBY_BOX, parentHolder, onComplete);
    }

    public Button btnSetting;
    public Button btnAvatar;

    public Button btnNoAds;
    public Button btnPlay;

    protected override void Init()
    {
        var holder = LobbyController.Instance.topCanvas;
        btnSetting.OnClicked(delegate { SettingBox.Setup(holder, box => { box.Show(); }); });
        btnAvatar.OnClicked(delegate { });
        btnNoAds.OnClicked(delegate { NoAdsBox.Setup(holder, box => { box.Show(); }); });
        btnPlay.OnClicked(delegate { MoreLivesBox.Setup(LobbyController.Instance.midCanvas, box => { box.Show(); }); });
    }

    protected override void InitState()
    {
    }
}