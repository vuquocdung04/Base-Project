using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[RequireComponent(typeof(CanvasGroup))] // Đảm bảo luôn có CanvasGroup
public abstract class BaseBox<T> : MonoBehaviour where T : BaseBox<T>
{
    // ==========================================
    // 1. SINGLETON & ADDRESSABLES LOGIC
    // ==========================================
    public static T Instance { get; private set; }
    private static AsyncOperationHandle<GameObject> handle;
    private static bool isInstantiating = false;
    
    public static async UniTaskVoid Setup(string addressableKey, Transform parent, System.Action<T> callback)
    {
        var instance = await GetInstanceAsync(addressableKey, parent);
        callback?.Invoke(instance);
    }

    public static async UniTask<T> GetInstanceAsync(string addressableKey, Transform parent)
    {
        if (Instance != null)
        {
            Instance.InitState();
            return Instance;
        }

        if (isInstantiating)
        {
            await UniTask.WaitUntil(() => Instance != null || !isInstantiating);
            return Instance;
        }

        isInstantiating = true;
        handle = Addressables.InstantiateAsync(addressableKey, parent);
        GameObject obj = await handle.Task;

        if (obj == null)
        {
            Debug.LogError($"[BaseBox] Không tìm thấy key: {addressableKey}");
            isInstantiating = false;
            return null;
        }

        Instance = obj.GetComponent<T>();
        if (Instance == null)
        {
            Addressables.ReleaseInstance(obj);
            isInstantiating = false;
            return null;
        }

        Instance.Init();
        Instance.InitState();

        isInstantiating = false;
        Instance.ForceHide();

        return Instance;
    }

    protected abstract void Init();
    protected abstract void InitState();

    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
            isInstantiating = false;
        }

        if (handle.IsValid())
        {
            Addressables.ReleaseInstance(gameObject);
        }
    }

    // ==========================================
    // 2. UI ANIMATION & CANVAS GROUP LOGIC
    // ==========================================
    [Header("UI Animation Settings")] [SerializeField]
    protected RectTransform mainPanel;

    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected bool isAnim = true;
    [SerializeField] protected float durationAppeared = 0.3f;
    [SerializeField] protected float durationSlide = 0.2f;

    private Tween currentTween;
    private Tween fadeTween;

    public void Show()
    {
        KillCurrentTweens();

        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        if (isAnim)
        {
            mainPanel.localScale = Vector3.zero;
            canvasGroup.alpha = 0f;
            DoAppearAnimation();
        }
        else
        {
            mainPanel.localScale = Vector3.one;
            canvasGroup.alpha = 1f;
        }
    }

    protected virtual void DoAppearAnimation()
    {
        currentTween = mainPanel.DOScale(Vector3.one, durationAppeared).SetEase(Ease.OutBack);
        fadeTween = canvasGroup.DOFade(1f, durationAppeared * 0.8f).SetEase(Ease.OutQuad);
    }


    public void Close()
    {
        KillCurrentTweens();

        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        if (isAnim)
        {
            currentTween = mainPanel.DOScale(Vector3.zero, durationAppeared * 0.8f).SetEase(Ease.InBack);
            fadeTween = canvasGroup.DOFade(0f, durationAppeared * 0.8f)
                .SetEase(Ease.InQuad)
                .OnComplete(ForceHide);
        }
        else
        {
            ForceHide();
        }
    }

    // ==========================================
    // 3. SLIDING LOGIC (Cũng áp dụng Canvas Group)
    // ==========================================
    public Tween ShowSliding(bool slideInFromLeft)
    {
        KillCurrentTweens();
        transform.SetAsLastSibling();

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        float startX = slideInFromLeft ? -mainPanel.rect.width : mainPanel.rect.width;
        mainPanel.anchoredPosition = new Vector2(startX, 0);

        currentTween = mainPanel.DOAnchorPos(Vector2.zero, durationSlide).SetEase(Ease.OutCubic);
        return currentTween;
    }

    public Tween CloseSliding(bool slideOutToLeft)
    {
        KillCurrentTweens();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        float endX = slideOutToLeft ? -mainPanel.rect.width : mainPanel.rect.width;

        currentTween = mainPanel.DOAnchorPos(new Vector2(endX, 0), durationSlide)
            .SetEase(Ease.InCubic)
            .OnComplete(ForceHide);

        return currentTween;
    }

    private void ForceHide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    private void KillCurrentTweens()
    {
        currentTween?.Kill();
        fadeTween?.Kill();
        currentTween = null;
        fadeTween = null;
    }
}