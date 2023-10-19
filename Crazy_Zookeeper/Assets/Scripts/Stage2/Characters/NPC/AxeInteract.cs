using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInteract : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject player;
    public float interactionDistance = 2f;
    public float displayDuration = 2f;
    public bool isInteracting = false;
    void Start()
    {
        interactionUI.SetActive(false);
    }
    public void Interact()
    {
        StartCoroutine(InvokeInteractionWithDelay());
        
    }
    IEnumerator InvokeInteractionWithDelay()
    {
        InteractAction();
        yield return new WaitForSeconds(1f);
        GameManager_Stage2.instance.Axe.SetActive(true);
        interactionUI.SetActive(false);
        Destroy(gameObject);
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
    public void InteractAction()
    {
        interactionUI.SetActive(true);
        isInteracting = true;
        
    }
}
