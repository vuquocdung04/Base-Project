using System.Collections.Generic;
using EventDispatcher;
using UnityEngine;

public partial class BoosterController : MonoBehaviour
{
    public List<BoosterItem> boosterItems;
    private BoosterItem _currentActiveBooster;

    public void Init()
    {
        boosterItems.AddRange(GetComponentsInChildren<BoosterItem>());
        foreach (var item in boosterItems) item.ChangeState(BoosterState.Available);

        this.RegisterListener(EventID.BOOSTER_USE_REQUEST, OnBoosterUseRequest);
        this.RegisterListener(EventID.BOOSTER_CANCEL_REQUEST, OnBoosterCancelRequest);
    }

    void OnDestroy()
    {
        this.RemoveListener(EventID.BOOSTER_USE_REQUEST, OnBoosterUseRequest);
        this.RemoveListener(EventID.BOOSTER_CANCEL_REQUEST, OnBoosterCancelRequest);
    }

    private void OnBoosterUseRequest(object param)
    {
        BoosterType type = (BoosterType)param;
        BoosterItem item = GetBoosterItem(type);

        if (item == null) return;

        if (_currentActiveBooster != null)
        {
            Debug.LogWarning("Đang có Booster được chọn, hãy thao tác xong hoặc hủy nó trước!");
            return;
        }

        _currentActiveBooster = item;
        _currentActiveBooster.ChangeState(BoosterState.InUse);

        HandleBoosterSpecificLogic(type);
    }

    private void OnBoosterCancelRequest(object param)
    {
        StopCurrentBooster();
    }

    private void HandleBoosterSpecificLogic(BoosterType type)
    {
        switch (type)
        {
            case BoosterType.Booster0:
                Debug.Log("Booster 0: Dùng luôn! (Xáo trộn...)");
                StopCurrentBooster();
                break;

            case BoosterType.Booster1:
                Debug.Log("Booster 1: Chờ người chơi thao tác đập búa...");
                break;

            case BoosterType.Booster2:
                Debug.Log("Booster 2: Chờ người chơi chọn vị trí tên lửa...");
                ReleaseAndStartCooldown(60);
                break;
        }
    }
    public void ReleaseAndStartCooldown(float cooldownTime)
    {
        if (_currentActiveBooster != null)
        {
            _currentActiveBooster.StartCooldown(cooldownTime);
            _currentActiveBooster = null; // Giải phóng khóa ngay lập tức
        }
    }
    private void StopCurrentBooster()
    {
        if (_currentActiveBooster != null)
        {
            _currentActiveBooster.ChangeState(BoosterState.Available);
            _currentActiveBooster = null;
        }
    }

    private BoosterItem GetBoosterItem(BoosterType type)
    {
        for (int i = 0; i < boosterItems.Count; i++)
        {
            if (boosterItems[i].Type == type) return boosterItems[i];
        }
        return null;
    }
}