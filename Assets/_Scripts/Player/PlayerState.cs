using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // This boolean will keep track of whether the chest has been opened
    public bool hasOpenedChest = false;

    // You can add more state variables as needed

    public void SetChestOpened(bool opened)
    {
        hasOpenedChest = opened;
    }

    // Additional methods to update and check the player's state can be added here
}
