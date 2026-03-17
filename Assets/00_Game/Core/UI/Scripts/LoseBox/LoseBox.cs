using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoseBox : BaseBox<LoseBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<LoseBox> onComplete)
    {
        return Setup(PathPrefabs.LOSE_BOX,parentHolder, onComplete);
    }
    public Button btnClose;
    public Button btnCloseByPanel;
    public Button btnRetry;
    
    protected override void Init()
    {
        btnClose.OnClicked(delegate
        {
            FXManager.Instance.LoadSceneWithIrisWipe(SceneName.LOBBY_SCENE);
        });
        btnCloseByPanel.OnClicked(delegate
        {
            FXManager.Instance.LoadSceneWithIrisWipe(SceneName.LOBBY_SCENE);
        });
        btnRetry.OnClicked(delegate
        {
            var heartAvaiable = CurrencyManager.TryUseHeart();
            FXManager.Instance.LoadSceneWithIrisWipe(heartAvaiable ? SceneName.GAME_PLAY : SceneName.LOBBY_SCENE);
        });
        
    }

    protected override void InitState()
    {
        
    }
}