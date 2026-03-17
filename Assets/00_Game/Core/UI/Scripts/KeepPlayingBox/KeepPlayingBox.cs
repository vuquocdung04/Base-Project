using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeepPlayingBox : BaseBox<KeepPlayingBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<KeepPlayingBox> onComplete)
    {
        return Setup(PathPrefabs.KEEP_PLAYING_BOX, parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;
    public Button btnBuyTime;
    public TextMeshProUGUI txtCoinDisplay;

    private int[] cost = { 900, 1900, 2900 };
    private int countedShow;

    protected override void Init()
    {
        btnClose.OnClicked(Close);
        btnCloseByPanel.OnClicked(Close);

        btnBuyTime.OnClicked(delegate
        {
            // Logic add  time
            bool trySubtractCoin = CurrencyManager.TrySubtractCoin(cost[countedShow]);
            if (trySubtractCoin)
            {
                Close();
            }
            else
            {
                //NOTE: show shopBox
            }
        });
    }

    protected override void InitState()
    {
        txtCoinDisplay.text = cost[countedShow].ToString();
        countedShow++;
    }
}