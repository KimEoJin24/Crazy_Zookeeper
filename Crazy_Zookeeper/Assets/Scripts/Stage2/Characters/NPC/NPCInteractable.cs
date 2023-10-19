using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public GameObject interactionUI;
    public float interactionDistance = 3f;
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
            // �÷��̾���� �Ÿ��� ���
           // float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

            // ���� �Ÿ� �̻� �־����� �� UI�� ��Ȱ��ȭ
            //if (distanceToPlayer > interactionDistance)
            //{
            //    interactionUI.SetActive(false);
            //}
        }
    }
}
