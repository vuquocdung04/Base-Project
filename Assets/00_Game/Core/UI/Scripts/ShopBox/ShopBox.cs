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
    }

    protected override void InitState()
    {
    }
}