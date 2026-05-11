using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUnlockBox : BaseBox<BoosterUnlockBox>
{
    public Image imgBooster;
    public Button btnClaim;

    protected override void Init()
    {
        btnClaim.onClick.AddListener(() =>
        {
            OnClickedClaim();
        });
    }

    protected override void InitState()
    {

    }

    private void OnClickedClaim()
    {
        int currentLevel = UseProfile.Level.Value;
        int[] unlocksBooster = new int[] { 1, 3, 6 };
        int boosterIndex = System.Array.IndexOf(unlocksBooster, currentLevel);

        if (boosterIndex == -1) boosterIndex = 0;

        BoosterItem targetBoosterItem = BoosterController.Instance.GetBoosterItemByIndex(boosterIndex);
        RectTransform targetRect = targetBoosterItem.GetComponent<RectTransform>();

        var currentTimeAnim = 0f;
        var duration = 0.75f;
        RectTransform boosterRect = imgBooster.GetComponent<RectTransform>();

        Sequence seq = DOTween.Sequence();

        seq.Insert(
            currentTimeAnim,
            imgBooster.transform.DOJump(
                targetRect.position,
                10,
                1,
                duration
            )
        );

        seq.Insert(
            currentTimeAnim,
            boosterRect.DOSizeDelta(targetRect.sizeDelta, duration)
        );

        currentTimeAnim += duration;

        seq.InsertCallback(
            currentTimeAnim,
            () =>
            {
                Close();
                HandAnimation.Instance.PlayAnimUI(targetBoosterItem.transform);
                HandAnimation.Instance.PlayAnimUI(targetRect);
            }
        );
    }
}