using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AxeUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerAxeInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        AxeInteract interactableAxe = playerInteract.GetInteractableObjectAxe();
        
        if (playerInteract.GetInteractableObjectAxe() != null)
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
