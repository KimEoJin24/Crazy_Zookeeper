using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject player;
    public float interactionDistance = 2f;
    void Start()
    {
        interactionUI.SetActive(false);
    }
    public void Interact()
    {
        interactionUI.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && interactionUI.activeSelf)
        {
            interactionUI.SetActive(false);
        }
        if (interactionUI.activeSelf)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            
            if (distanceToPlayer > interactionDistance)
            {
                interactionUI.SetActive(false);
            }
        }
    }
}
