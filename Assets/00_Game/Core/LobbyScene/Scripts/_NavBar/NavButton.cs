using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class NavButton : MonoBehaviour
{
    public ENavType navType;
    [Space(5)] [SerializeField] private Button btnMain;

    [SerializeField] RectTransform icon;

    //[SerializeField] Image imgDisplayText;
    [SerializeField] private Sprite sprUnSelected;
    [SerializeField] private Image imgMain;
    [SerializeField] private RectTransform rectMain;

    public void Init()
    {
        UIImageUtils.FitToTargetHeight(icon.GetComponent<Image>(), 200f);
    }

    public void HandleSelected(bool isSelected, Sprite sprSelected, Vector2 targetSize, Vector2 defaultSize)
    {
        rectMain.sizeDelta = isSelected ? targetSize : defaultSize;
        imgMain.sprite = isSelected ? sprSelected : sprUnSelected;
        //imgDisplayText.gameObject.SetActive(isSelected);
        if (isSelected)
        {
            icon.DOScale(Vector3.one * 1.3f, 0.15f);
            icon.DOAnchorPosY(100f, 0.15f);
        }
        else
        {
            icon.DOScale(Vector3.one * 0.7f, 0.15f);
            icon.DOAnchorPosY(0f, 0.15f);
        }
    }

    public void OnClicked(System.Action callback = null)
    {
        btnMain.onClick.AddListener(delegate { callback?.Invoke(); });
    }


    public void InitSetup()
    {
        rectMain = GetComponent<RectTransform>();
        btnMain = GetComponent<Button>();
        icon = transform.GetComponentInChildren<RectTransform>();
        imgMain = GetComponent<Image>();
    }
}

public enum ENavType
{
    Shop = 0,
    Home = 1,
    Skin = 2,
}