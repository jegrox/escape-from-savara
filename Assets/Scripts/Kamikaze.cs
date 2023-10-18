using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Kamikaze : Spaceship
{
    private GameObject player;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
    }

    protected override void Move()
    {
        if (transform.position.z > player.transform.position.z + 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
