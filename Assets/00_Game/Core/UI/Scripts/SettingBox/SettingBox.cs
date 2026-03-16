using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SettingBox : BaseBox<SettingBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<SettingBox> onComplete)
    {
        return Setup(PathPrefabs.LOBBY_BOX,parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;
    protected override void Init()
    {
        btnClose.OnClicked(delegate
        {
        
        });
        
    }

    protected override void InitState()
    {
        
    }
    

}