using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Input;

// INHERITANCE
public class Player : Spaceship
{

    public GameObject beamPrefab;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(HorizontalInput * speed * Time.deltaTime, 0, VerticalInput * speed * Time.deltaTime);
    }

    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 beamPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 20);
            Instantiate(beamPrefab, beamPosition, beamPrefab.transform.rotation);
        }
    }
}
