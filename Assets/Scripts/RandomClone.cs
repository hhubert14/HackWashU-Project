using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    public int numberOfObjectsToClone;
    // Start is called before the first frame update
    void Start()
    {
         numberOfObjectsToClone = UnityEngine.Random.Range(0,10);
        for (int i = 0; i < numberOfObjectsToClone; i++)
        {
            // Generate random positions within the clone area.
            int randomX = UnityEngine.Random.Range(-5,5);
            int randomY = UnityEngine.Random.Range(-5,5);

            // Create a new object at the random position.
            Vector3 clonePosition = new Vector3(randomX, randomY, 0);
            Instantiate(Player, transform.position + clonePosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
