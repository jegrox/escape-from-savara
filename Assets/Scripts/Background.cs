using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float maxDistance = 350f;
    public float speed = 50f;
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        Debug.Log("Start position: " + startPos);
        Debug.Log("Repeat width: " + repeatWidth);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updates");
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < startPos.z - repeatWidth)
        {
            Debug.Log("Reset width");
            transform.position = startPos;
        }
    }
}
