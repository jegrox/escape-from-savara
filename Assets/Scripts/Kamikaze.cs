using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    private GameObject player;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (transform.position.z > player.transform.position.z + 2f)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
