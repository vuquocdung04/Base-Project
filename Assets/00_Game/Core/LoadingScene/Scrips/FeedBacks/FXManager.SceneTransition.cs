using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class FXManager
{
    public Canvas wipeCanvas;
    public float transitionDurationOut = 1f;
    public float transitionDurationIn = 1f;

    public void LoadSceneWithIrisWipe(string sceneName, bool skipOutPhase = false)
    {
        IrisWipeAsync(sceneName, skipOutPhase).Forget();
    }

    private async UniTaskVoid IrisWipeAsync(string sceneName, bool skipOutPhase)
    {
        wipeCanvas.gameObject.SetActive(true);
        wipeCanvas.worldCamera = Camera.main;
        Material wipeMat = wipeCanvas.GetComponentInChildren<RawImage>().material;

        if (skipOutPhase)
        {
            wipeMat.SetFloat("_IsInvert", 1f);
            wipeMat.SetFloat("_Radius", 0f);
        }
        else
        {
            wipeMat.SetFloat("_IsInvert", 0f);
            wipeMat.SetFloat("_Radius", 0f);
            
            await wipeMat.DOFloat(1.5f, "_Radius", transitionDurationOut).ToUniTask();
        }
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            await UniTask.Yield();
        }

        // camera moi cua scene
        wipeCanvas.worldCamera = Camera.main;
        wipeMat.SetFloat("_IsInvert", 1f);
        wipeMat.SetFloat("_Radius", 0f);

        await wipeMat.DOFloat(1.5f, "_Radius", transitionDurationIn).ToUniTask();

        Debug.Log("Completed Transition");
        wipeCanvas.gameObject.SetActive(false);
    }
}