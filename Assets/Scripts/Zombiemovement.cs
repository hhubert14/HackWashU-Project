using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombiemovement : MonoBehaviour
{   
    public float speed = 2.0f; 
    public GameObject Player;
    private Vector2 direction; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        direction = Player.transform.position - transform.position;
       transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed*Time.deltaTime);
    }
}
