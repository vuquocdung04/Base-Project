using Cysharp.Threading.Tasks;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    public NavController navController;

    public Transform canvasHolderNav;

    public async UniTask InitAsync()
    {
        navController.Init();

        var lobbyTcs = new UniTaskCompletionSource();
        var shopTcs = new UniTaskCompletionSource();
        var rankTcs = new UniTaskCompletionSource();

        LobbyBox.Setup(canvasHolderNav, box =>
        {
            box.Show();
            lobbyTcs.TrySetResult();
        });

        ShopBox.Setup(canvasHolderNav, _ => shopTcs.TrySetResult());

        RankBox.Setup(canvasHolderNav, _ => rankTcs.TrySetResult());
        
        await UniTask.WhenAll(lobbyTcs.Task, shopTcs.Task, rankTcs.Task);
        
        FXManager.Instance.isNextSceneReady = true;
    }
}