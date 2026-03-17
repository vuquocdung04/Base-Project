using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NoAdsBox : BaseBox<NoAdsBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<NoAdsBox> onComplete)
    {
        return Setup(PathPrefabs.NO_ADS_BOX, parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;

    public Button btnPurchase;

    protected override void Init()
    {
        btnClose.OnClicked(Close);        
        btnCloseByPanel.OnClicked(Close);
        
        btnPurchase.OnClicked(delegate
        {
            
        });
    }

    protected override void InitState()
    {
        
    }
}