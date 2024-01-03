using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool hasOpenedChest = false;

    public void SetChestOpened(bool opened)
    {
        hasOpenedChest = opened;
    }
}
