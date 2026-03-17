
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WinBox : BaseBox<WinBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<WinBox> onComplete)
    {
        return Setup(PathPrefabs.WIN_BOX, parentHolder, onComplete);
    }
    
    
    protected override void Init()
    {
        throw new System.NotImplementedException();
    }

    protected override void InitState()
    {
        throw new System.NotImplementedException();
    }
}
