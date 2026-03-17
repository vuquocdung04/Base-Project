using Cysharp.Threading.Tasks;
using EventDispatcher;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreLivesBox : BaseBox<MoreLivesBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<MoreLivesBox> onComplete)
    {
        return Setup(PathPrefabs.MORE_LIVES_BOX, parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;
    public TextMeshProUGUI txtDisplayLives;
    public TextMeshProUGUI txtDisplayCooldownLives;
    

    protected override void Init()
    {
        btnClose.OnClicked(Close);
        btnCloseByPanel.OnClicked(Close);
        
        this.RegisterListener(EventID.CHANGE_HEART, UpdateHeartUI);
    }

    protected override void InitState()
    {
        Refresh();
    }

    private void Refresh()
    {
        UpdateHeartUI(null);
        
        txtDisplayCooldownLives.BindCountdownRealtime(
            getTimeRemaining: () => LivesManager.Instance.GetTimeToNextHeart(),
            textWhenZero: "Full",
            checkUnlimited: () => UseProfile.IsUnlimitedHeart,
            token: this.GetCancellationTokenOnDestroy() 
        ).Forget();
    }
    
    private void UpdateHeartUI(object param)
    {
        txtDisplayLives.text = CurrencyManager.TotalHeart().ToString();
    }
    
    protected override void OnDestroy()
    {
        base.OnDestroy();
        this.RemoveListener(EventID.CHANGE_HEART, UpdateHeartUI);
    }
    
    
    
}