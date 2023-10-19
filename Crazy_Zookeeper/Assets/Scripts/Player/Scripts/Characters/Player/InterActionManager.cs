using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}
public class InterActionManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }
        }
        
    }
    public NPCInteractable GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }
        }
        return null;
    }
    //public float checkRate = 0.05f;
    //private float lastCheckTime;
    //public float maxCheckDistance;
    //public LayerMask layerMask;

    //private GameObject curInteractGameobject;
    //private IInteractable curInteractable;

    //public TextMeshProUGUI promptText;
    //private Camera camera;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    camera = Camera.main;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Time.time - lastCheckTime > checkRate)
    //    {
    //        lastCheckTime = Time.time;
    //        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
    //        RaycastHit hit;

    //        if(Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
    //        {
    //            if(hit.collider.gameObject != curInteractGameobject)
    //            {
    //                curInteractGameobject = hit.collider.gameObject;
    //                curInteractable = hit.collider.GetComponent<IInteractable>();
    //                SetPromptText();
    //            }
    //        }
    //        else
    //        {
    //            curInteractGameobject = null;
    //            curInteractable = null;
    //            promptText.gameObject.SetActive(false);
    //        }
    //    }
    //}
    //private void SetPromptText()
    //{
    //    promptText.gameObject.SetActive(true);
    //    promptText.text = string.Format("<b>[Q]</b> {0}", curInteractable.GetInteractPrompt());
    //}

    //public void OnInteractInput(InputAction.CallbackContext callbackContext)
    //{
    //    if(callbackContext.phase == InputActionPhase.Started && curInteractable != null)
    //    {
    //        curInteractable.OnInteract();
    //        curInteractGameobject = null;
    //        curInteractable = null;
    //        promptText.gameObject.SetActive(false);
    //    }
    //}
}
