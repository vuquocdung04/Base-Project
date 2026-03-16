using Cysharp.Threading.Tasks;
using UnityEngine;

public class RankBox : BaseBox<RankBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<RankBox> onComplete)
    {
        return Setup(PathPrefabs.SHOP_BOX, parentHolder, onComplete);
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