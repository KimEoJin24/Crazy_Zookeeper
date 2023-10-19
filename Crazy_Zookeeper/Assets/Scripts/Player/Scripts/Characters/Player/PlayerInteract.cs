using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}

public class PlayerInteract : MonoBehaviour
{
    private float interactRange = 3f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }
        }
    }
    public NPCInteractable GetInteractableObject()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }

        }
        return null;
    }

}
