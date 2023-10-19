using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerTreeInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        TreeInteractable interactableAxe = playerInteract.GetInteractableObjectTree();
        
        if (playerInteract.GetInteractableObjectTree() != null)
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
