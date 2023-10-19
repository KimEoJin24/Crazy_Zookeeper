using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stage2 : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;

    private void Start()
    {
        current = 0;
    }

    private void Update()
    {
        if(transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*Time.deltaTime);
        }
        else
            current = (current+1)%points.Length;
    }
}
