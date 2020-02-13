using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float reset = 5;
    private float newtime;


    private Color basicColor = Color.green;
    private Color hoverColor = Color.red;
    private Renderer renderer;

    public float seeDistance = 10f;
    public float speed;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        newtime = Time.time;
        rb = GetComponent<Rigidbody>();

        renderer = GetComponent<Renderer>();
        renderer.material.color = basicColor;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Food").transform;
        reset -= Time.deltaTime;
        if (reset > 0)
        {     
            transform.GetComponent<Renderer>().material.color = Color.Lerp(basicColor, hoverColor, (Time.time-newtime)/5);
            if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
            {
                transform.LookAt(target.transform);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }

        if (reset < 0)
        {
            transform.GetComponent<Renderer>().material.SetColor ("_Color", Color.black);
            GetComponent<SphereCollider>().enabled = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            reset = 5;
            newtime = Time.time;
            print(newtime);
            Instantiate(gameObject);
        }
    }
}
