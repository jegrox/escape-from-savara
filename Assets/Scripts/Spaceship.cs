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
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Animate particle explosion
        Debug.Log("Collided!");
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
        
    }

    // POLYMORPHISM
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
