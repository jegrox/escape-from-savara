using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//INHERITANCE
public class Fighter : Spaceship
{
    public float shootInterval = 2f;
    public float elapsedTime;

    public GameObject beamPrefab;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        elapsedTime = 0f;
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void Shoot()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            Debug.Log("Shoot!");
            Instantiate(beamPrefab, transform.position - Vector3.forward * 30, beamPrefab.transform.rotation);
            elapsedTime = 0f;
        }
    }
}
