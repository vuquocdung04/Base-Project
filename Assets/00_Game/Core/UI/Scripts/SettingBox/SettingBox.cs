using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SettingBox : BaseBox<SettingBox>
{
    public static UniTaskVoid Setup(Transform parentHolder, System.Action<SettingBox> onComplete)
    {
        return Setup(PathPrefabs.SETTING_BOX, parentHolder, onComplete);
    }

    public Button btnClose;
    public Button btnCloseByPanel;

    public Button btnSound;
    public Button btnMusic;
    public Button btnVib;

    public Image imgSound;
    public Image imgMusic;
    public Image imgVib;

    public Sprite sprOn, sprOff;

    protected override void Init()
    {
        btnClose.OnClicked(Close);
        btnCloseByPanel.OnClicked(Close);
        
        btnSound.OnClicked(delegate
        {
            UseProfile.OnSound = !UseProfile.OnSound;
            imgSound.SetSprite(UseProfile.OnSound ? sprOn : sprOff);
        });

        btnVib.OnClicked(delegate
        {
            UseProfile.OnVib = !UseProfile.OnVib;
            imgVib.SetSprite(UseProfile.OnVib ? sprOn : sprOff);
        });

        btnMusic.OnClicked(delegate
        {
            UseProfile.OnMusic = !UseProfile.OnMusic;
            imgMusic.SetSprite(UseProfile.OnMusic ? sprOn : sprOff);
        });

        Refresh();
    }

    protected override void InitState()
    {
        
    }

    private void Refresh()
    {
        imgSound.SetSprite(UseProfile.OnSound ? sprOn : sprOff);
        imgVib.SetSprite(UseProfile.OnVib ? sprOn : sprOff);
        imgMusic.SetSprite(UseProfile.OnMusic ? sprOn : sprOff);
    }
}