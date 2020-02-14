using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private static float CountClones = 1;

    void Start()
    {
        
    }

    
    void Update()
    {

        if (CountClones > 0)
        {
            var randomPosition = new Vector3(Random.Range(-125, 125), 4, Random.Range(-125, 125));
            var clone = Instantiate(gameObject, randomPosition, Quaternion.identity) as GameObject;
            CountClones--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            CountClones++;
        }
    }
}
