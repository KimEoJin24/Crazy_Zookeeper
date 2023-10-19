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
            // 플레이어와의 거리를 계산
           // float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

            // 일정 거리 이상 멀어졌을 때 UI를 비활성화
            //if (distanceToPlayer > interactionDistance)
            //{
            //    interactionUI.SetActive(false);
            //}
        }
    }
}
