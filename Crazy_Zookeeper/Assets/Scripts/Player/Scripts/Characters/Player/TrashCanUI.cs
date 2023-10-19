using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashCanUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerTrashCanInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        TrashInteractable interactableAxe = playerInteract.GetInteractableObjectTrashCan();
        
        if (playerInteract.GetInteractableObjectTrashCan() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }      
    }

    private void Show()
    {
        containerGameObject.SetActive(true);
    }
    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
