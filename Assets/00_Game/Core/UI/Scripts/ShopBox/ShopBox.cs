using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShopBox : BaseBox<ShopBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<ShopBox> onComplete)
    {
        return Setup(PathPrefabs.SHOP_BOX,parentHolder, onComplete);
    }

    public Button btnClose;
    
     
    protected override void Init()
    {
        
    }

    protected override void InitState()
    {
    }
}