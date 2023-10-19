using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeInteractable : MonoBehaviour
{
    public GameObject cutTree;
    public GameObject originalTree;
    public GameObject player;
    public GameObject Axe;
    public float interactionDistance = 2f;
    private int capacity = 10;
    private bool isInteractable = true;
    public AudioSource audioSource;
    public AudioClip soundClip;

    void Start()
    {
        // AudioSource ������Ʈ�� ����
        audioSource = GetComponent<AudioSource>();

        // �Ҹ� ������ �ε�
        soundClip = Resources.Load<AudioClip>("hit3"); // Resources ���� ���� �Ҹ� ������ �־�� �մϴ�.
    }

    public void Interact()
    {
        if (Axe.activeSelf)
        {
            if(isInteractable)
            {
                isInteractable = false;
                player.GetComponent<Player>().InteractTree();
                PlayInteractionSound();
                StartCoroutine(InvokeInteractionWithDelay());
            }       
        }
    }
    IEnumerator InvokeInteractionWithDelay()
    {
        Interacting();        
        yield return new WaitForSeconds(1f);
        player.GetComponent<Player>().InteractTreeEnd();
        isInteractable = true;
    }
    public void TreeCut()
    {
        originalTree.SetActive(false);
        cutTree.SetActive(true);
        GameManager_Stage2.instance.GameClear();
    }
    public void Interacting()
    {
        capacity -= 1;
        if (capacity <= 0) { TreeCut(); }
    }
    void PlayInteractionSound()
    {
        // AudioSource ������Ʈ�� �����ϰ� ȿ������ �����Ǿ� �ִٸ� ����մϴ�.
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
