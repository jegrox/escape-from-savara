using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Beam : MonoBehaviour
{

    public float speed = 20f;
    public float zMax = 100;
    public float zMin = -100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (this.gameObject.transform.position.z > zMax || this.gameObject.transform.position.z < zMin)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
