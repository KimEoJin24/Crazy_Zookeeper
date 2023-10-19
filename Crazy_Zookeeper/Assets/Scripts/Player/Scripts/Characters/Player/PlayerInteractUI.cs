using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        
        NPCInteractable interactableNPC = playerInteract.GetInteractableObject();
        
        if (playerInteract.GetInteractableObject() != null)
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
