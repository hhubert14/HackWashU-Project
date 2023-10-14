using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombControls : MonoBehaviour
{   
    public float speed = 2.0f; 
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime; 
        transform.LookAt(target);
    }
}
