using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyBox : BaseBox<LobbyBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<LobbyBox> onComplete)
    {
        return Setup(PathPrefabs.LOBBY_BOX,parentHolder, onComplete);
    }

    public Button btnSetting;
    public Button btnAvatar;
    public Image txt;
    
    protected override void Init()
    {
        btnSetting.OnClicked(delegate
        {
            Debug.Log("Setting button clicked");
            
        });
        btnAvatar.OnClicked(delegate
        {
            
        });
    }

    protected override void InitState()
    {
        
    }
}