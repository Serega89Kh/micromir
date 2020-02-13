using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    public static int CountClones = 1;

    void Start()
    {
        
    }

    
    void Update()
    {

        if (CountClones > 0)
        {
            CountClones--;
            var randomPosition = new Vector3(Random.Range(-100, 100), 4, Random.Range(-100, 100));
            var clone = Instantiate(gameObject, randomPosition, Quaternion.identity) as GameObject;
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
