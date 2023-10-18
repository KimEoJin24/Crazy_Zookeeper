using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private GameObject pointEffectprefab;
    private float ratateSpeed = 100.0f;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject clone = Instantiate(pointEffectprefab);
        clone.transform.position = transform.position;
        stageController.GetPoint();
        Destroy(gameObject);
    }
}
