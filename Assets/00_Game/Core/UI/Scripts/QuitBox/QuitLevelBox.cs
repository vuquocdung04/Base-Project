using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class QuitLevelBox : BaseBox<QuitLevelBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<QuitLevelBox> onComplete)
    {
        return Setup(PathPrefabs.DAILY_QUEST_BOX,parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;

    public Button btnLeave;
    public Button btnRestart;

    private bool isLeave;
    
    protected override void Init()
    {
        btnClose.OnClicked(Close);
        btnCloseByPanel.OnClicked(Close);
        
        btnRestart.OnClicked(delegate
        {
            
        });
        btnLeave.OnClicked(delegate
        {
            
        });
    }

    protected override void InitState()
    {
        Refresh();
    }

    private void Refresh()
    {
        btnLeave.SetActive(isLeave);
        btnRestart.SetActive(isLeave);
    }
}