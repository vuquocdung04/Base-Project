using Cysharp.Threading.Tasks;
using UnityEngine;

public class RankBox : BaseBox<RankBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<RankBox> onComplete)
    {
        return Setup(PathPrefabs.RANK_BOX, parentHolder, onComplete);
    }

    protected override void Init()
    {
    }

    protected override void InitState()
    {
    }
}