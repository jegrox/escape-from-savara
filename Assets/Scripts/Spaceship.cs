using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

// INHERITANCE: This class will implement spaceship common behavior and will be extended by other classes 
public class Spaceship : MonoBehaviour
{
    public float speed = 5f;

    private ParticleSystem explosionParticle;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        explosionParticle = gameManager.getExplosionParticle();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided!");
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
    }

    // POLYMORPHISM
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void Shoot()
    {
        // Default is to do nothing
    }
}
