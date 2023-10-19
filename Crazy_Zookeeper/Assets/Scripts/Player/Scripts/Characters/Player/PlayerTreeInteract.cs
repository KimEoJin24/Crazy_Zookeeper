using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractableTree
{
    string GetInteractPrompt();
    void OnInteract();
}
public class PlayerTreeInteract : MonoBehaviour
{
    private float interactRange = 2f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out TreeInteractable treeInteractable))
                {
                    treeInteractable.Interact();
                }
            }
        }
    }

    public TreeInteractable GetInteractableObjectTree()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out TreeInteractable treeInteractable))
            {
                return treeInteractable;
            }

        }
        return null;
    }

}
