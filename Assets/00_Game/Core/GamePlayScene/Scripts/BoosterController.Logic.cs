
using System;

public partial class BoosterController
{
    public interface IBoosterLogic
    {
        void Execute(BoosterController context, Action onComplete);

        void Cancel();
    }

    private class Booster0_InstantLogic : IBoosterLogic
    {
        public void Execute(BoosterController context, Action onComplete)
        {
            onComplete?.Invoke();
        }

        public void Cancel()
        {
            // Template này chạy ngay lập tức nên không có trạng thái chờ -> không cần Cancel
        }
    }

    private class Booster1_ManualToggleLogic : IBoosterLogic
    {
        private Action _onComplete;

        public void Execute(BoosterController context, Action onComplete)
        {
            _onComplete = onComplete;
            // Có thể bật cờ báo hiệu ở đây: GameManager.Instance.IsWaitingForInput = true;
        }

        // Method này do hệ thống khác gọi (VD: khi click xong mục tiêu trên màn hình)
        private void OnActionFinished()
        {
            // Xong việc thì báo cáo để bắt đầu Cooldown
            _onComplete?.Invoke();
        }

        public void Cancel()
        {
            // Dọn dẹp trạng thái chờ ở đây
            // GameManager.Instance.IsWaitingForInput = false;
        }
    }
}