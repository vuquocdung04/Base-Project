using Cysharp.Threading.Tasks;
using UnityEngine;

public class ShopBox : BaseBox<ShopBox>
{
    public static UniTaskVoid Setup(Transform parentHolder,System.Action<ShopBox> onComplete)
    {
        return Setup(PathPrefabs.SHOP_BOX,parentHolder, onComplete);
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