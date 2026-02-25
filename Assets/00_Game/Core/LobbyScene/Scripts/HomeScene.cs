
using UnityEngine;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    public Button btnTest;
    public void Init()
    {
        btnTest.onClick.AddListener(delegate
        {
           GameManager.Instance.audioManager.PlaySfx(AudioKeyType.Click); 
        });
    }
}
