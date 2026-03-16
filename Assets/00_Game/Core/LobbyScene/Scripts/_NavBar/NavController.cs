using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavController : MonoBehaviour
{
    [SerializeField] private Sprite sprSelected;
    public List<NavButton> navButtons;
    private Vector2 sizeSelected;
    private Vector2 sizeUnselected;

    private NavButton currentNavSelected;

    public void Init()
    {

        foreach (var nav in navButtons)
        {
            nav.Init();
            nav.OnClicked(delegate
            {
                if (nav != currentNavSelected)
                {
                    AudioManager.Instance.PlaySfx("Click");
                    UpdateNavButtonState(nav);
                }
            });
        }
        InitNavButtonStateWith(ENavType.Home);
    }

    private void InitSize()
    {
        int countNavBar = navButtons.Count;
        float totalWidth = GetComponent<RectTransform>().rect.width;
        float widthSelected = totalWidth * 0.45f;

        float height = 250;
        sizeSelected = new Vector2(widthSelected, height);
        if (countNavBar > 1)
        {
            float remainingPercent = 1.0f - 0.45f;
            float widthUnselected = totalWidth * remainingPercent / (countNavBar - 1);
            sizeUnselected = new Vector2(widthUnselected, height);
        }
    }

    private void InitNavButtonStateWith(ENavType type)
    {
        InitSize();
        foreach (var t in navButtons)
        {
            if (t.navType == type)
            {
                currentNavSelected = t;
                t.HandleSelected(true, sprSelected, sizeSelected, sizeUnselected);
            }
            else
            {
                t.HandleSelected(false, sprSelected, sizeSelected, sizeUnselected);
            }

        }
    }
    private void UpdateNavButtonState(NavButton navButton)
    {
        foreach (var t in navButtons)
        {
            t.HandleSelected(false, sprSelected, sizeSelected, sizeUnselected);
        }
        HandleScreenSliding(navButton);
        currentNavSelected = navButton;
        navButton.HandleSelected(true, sprSelected, sizeSelected, sizeUnselected);
    }
    private void HandleScreenSliding(NavButton clicked)
    {
        bool slideToLeft = clicked.transform.localPosition.x > currentNavSelected.transform.localPosition.x;


        ClosePrevBox(currentNavSelected.navType, slideToLeft);
        OpenCurrentBox(clicked.navType, !slideToLeft);
    }
    private void OpenCurrentBox(ENavType type, bool slideInFromLeft)
    {
        // var heartHolder = HomeController.Instance.lobbyScene.consumableBox;
        // switch (type)
        // {
        //     case ENavType.Shop:
        //         //ShopBox.Setup(box => box.ShowSliding(slideInFromLeft));
        //         heartHolder.EnableHeartHolder(false);
        //         break;
        //     case ENavType.Home:
        //         //HomeBox.Setup(box => box.ShowSliding(slideInFromLeft));
        //         heartHolder.EnableHeartHolder(true);
        //         break;
        //     case ENavType.Skin:
        //         //ShopSkinBox.Setup(box => box.ShowSliding(slideInFromLeft));
        //         heartHolder.EnableHeartHolder(true);
        //         break;
        // }
    }
    private void ClosePrevBox(ENavType type, bool slideOutToLeft)
    {
        // switch (type)
        // {
        //     case ENavType.Shop:
        //         if (ShopBox.Instance != null)
        //             ShopBox.Instance.CloseSliding(slideOutToLeft);
        //         break;
        //     case ENavType.Home:
        //         if (HomeBox.Instance != null) HomeBox.Instance.CloseSliding(slideOutToLeft);
        //         break;
        //     case ENavType.Skin:
        //         if (ShopSkinBox.Instance != null) ShopSkinBox.Instance.CloseSliding(slideOutToLeft);
        //         break;
        // }
    }

    [ContextMenu("Setup Nav button")]
    private void Setup()
    {
        navButtons.Clear();
        navButtons = GetComponentsInChildren<NavButton>().ToList();

        foreach (var t in navButtons)
        {
            t.InitSetup();
        }
    }
}
