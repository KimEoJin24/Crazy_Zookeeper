using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractableTrashCan
{
    string GetInteractPrompt();
    void OnInteract();
}
public class PlayerTrashCanInteract : MonoBehaviour
{
    private float interactRange = 2f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out TrashInteractable trashCanInteractable))
                {
                    trashCanInteractable.Interact();
                }
            }
        }
    }

    public TrashInteractable GetInteractableObjectTrashCan()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out TrashInteractable trashCanInteractable))
            {
                return trashCanInteractable;
            }

        }
        return null;
    }

}
