using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Input = UnityEngine.Input;


public class Player : MonoBehaviour
{

    public float speed = 5f;
    public GameObject beamPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(HorizontalInput * speed * Time.deltaTime, 0, VerticalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 beamPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 20);
            Instantiate(beamPrefab, beamPosition, beamPrefab.transform.rotation);
        }
    }
}
