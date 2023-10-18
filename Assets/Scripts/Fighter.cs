using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fighter : Enemy
{
    public float speed = 3f;
    public float shootInterval = 2f;
    public float elapsedTime;

    public GameObject beamPrefab;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            shoot();
            elapsedTime = 0f;
        }
    }

    void shoot()
    {
        Debug.Log("Shoot!");
        Instantiate(beamPrefab, transform.position - Vector3.forward * 30, beamPrefab.transform.rotation);
    }
}
