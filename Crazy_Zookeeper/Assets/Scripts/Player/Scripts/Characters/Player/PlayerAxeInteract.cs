using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractableAxe
{
    string GetInteractPrompt();
    void OnInteract();
}
public class PlayerAxeInteract : MonoBehaviour
{
    private float interactRange = 2f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out AxeInteract axeInteractable))
                {
                    axeInteractable.Interact();
                }
            }
        }
    }

    public AxeInteract GetInteractableObjectAxe()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out AxeInteract axeInteractable))
            {
                return axeInteractable;
            }

        }
        return null;
    }

}
