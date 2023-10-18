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

    public override void Move()
    {
        base.Move();
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
