
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    public NavController navController;
    public Transform canvasHolderNav;
    public void Init()
    {
        navController.Init();
        
        LobbyBox.Setup(canvasHolderNav,box =>
        {
            box.Show();
        });
    }
}
