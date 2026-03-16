using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class UIUtils
{
    public static void FitToTargetHeight(this Image image, float targetHeight)
    {
        if (image == null || image.sprite == null)
            return;

        Rect rect = image.sprite.rect;
        float aspectRatio = rect.width / rect.height;
        float newWidth = targetHeight * aspectRatio;

        image.rectTransform.sizeDelta = new Vector2(newWidth, targetHeight);
    }
    
    public static void FitToTargetWidth(this Image image, float targetWidth)
    {
        if (image == null || image.sprite == null)
            return;

        Rect rect = image.sprite.rect;
        float aspectRatio = rect.height / rect.width; 
        float newHeight = targetWidth * aspectRatio;

        image.rectTransform.sizeDelta = new Vector2(targetWidth, newHeight);
    }

    public static void FitToSquareBase(this Image image, float baseSize = 100f)
    {
        if (image == null || image.sprite == null)
            return;

        Rect rect = image.sprite.rect;
        float aspectRatio = rect.width / rect.height;

        float width, height;
        if (aspectRatio >= 1f)
        {
            width = baseSize;
            height = baseSize / aspectRatio;
        }
        else
        {
            height = baseSize;
            width = baseSize * aspectRatio;
        }

        image.rectTransform.sizeDelta = new Vector2(width, height);
    }
    
    
    public static void OnClicked(this Button btn, System.Action callback)
    {
        btn.onClick.AddListener(delegate
        {
            AudioManager.Instance.PlaySfx("Click");
            callback.Invoke();
        });
    }

    public static async UniTask CountTo(this TextMeshProUGUI textElement, int targetValue, float duration = 0.5f)
    {
        int.TryParse(textElement.text, out int startValue);

        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / duration;
            
            int currentValue = (int)Mathf.Lerp(startValue, targetValue, progress);
            textElement.text = currentValue.ToString();

            await UniTask.Yield();
        }
        
        textElement.text = targetValue.ToString();
    }

    public static void SetSprite(this Image image, Sprite newSprite)
    {
        image.sprite = newSprite;
    }
    public static void SetCanvasState(this CanvasGroup cg, bool isInteractable, float alpha = -1f)
    {
        if (cg == null) return;
        cg.interactable = isInteractable;
        cg.blocksRaycasts = isInteractable;
        if (alpha >= 0) cg.alpha = alpha;
    }
    // --- SLIDING ANIMATION ---
    public static Tween SlideTo(this RectTransform rect, Vector2 targetPos, float duration, Ease ease = Ease.OutCubic)
    {
        return rect.DOAnchorPos(targetPos, duration).SetEase(ease);
    }

    // --- SCALE ANIMATION ---
    public static Tween ScaleTo(this RectTransform rect, Vector3 targetScale, float duration, Ease ease = Ease.OutBack)
    {
        return rect.DOScale(targetScale, duration).SetEase(ease);
    }
}