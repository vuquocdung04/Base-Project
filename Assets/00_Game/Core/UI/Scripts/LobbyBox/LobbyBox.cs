using Cysharp.Threading.Tasks;
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
    
    protected override void Init()
    {
        OnClicked(btnSetting, delegate
        {
            
        });
        
        OnClicked(btnAvatar, delegate
        {
            
        });
    }

    protected override void InitState()
    {
        
    }

    private void OnClicked(Button btn, System.Action callback)
    {
        btn.onClick.AddListener(delegate
        {
            AudioManager.Instance.PlaySfx("Click");
            callback.Invoke();
        });
    }
}