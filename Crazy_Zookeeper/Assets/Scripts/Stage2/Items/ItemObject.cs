using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData_Stage2 item;

    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void OnInteract()
    {
        Destroy(gameObject);
    }
}
