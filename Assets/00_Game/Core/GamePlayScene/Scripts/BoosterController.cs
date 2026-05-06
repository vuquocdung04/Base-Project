using System.Collections.Generic;
using UnityEngine;
public partial class BoosterController : MonoBehaviour
{
    [SerializeField] private List<BoosterItem> boosterItems;

    private Dictionary<BoosterType, IBoosterLogic> boosterLogics;

    public void Init()
    {
        boosterLogics = new()
        {
            {BoosterType.Booster0, new Booster0_InstantLogic()},
        };

        foreach(var item in boosterItems)
        {
            item.ChangeState(BoosterState.Available);
            item.OnBoosterUseRequest += HandleBoosterUsed;
        }
    }

    private void HandleBoosterUsed(BoosterType requestedType)
    {
        BoosterItem clickedItem = boosterItems.Find(x => x.Type == requestedType);

        clickedItem.ChangeState(BoosterState.InUse);


    }
}