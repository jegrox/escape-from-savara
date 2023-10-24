using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

// INHERITANCE: This class will implement spaceship common behavior and will be extended by other classes 
public class Spaceship : MonoBehaviour
{
    public float speed = 5f;
    public float xRange = 150f;
    protected int hp;
    protected int score;

    private GameManager gameManager;

    private ParticleSystem explosionParticle;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        explosionParticle = gameManager.getExplosionParticle();
        hp = 1;
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfOutOfHP();

        //ABSTRACTION
        CheckBoundaries();
        Move();
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        hp--;
    }

    private void DestroyIfOutOfHP()
    {
        if (hp <= 0 ) {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(score);
        }
    }

    // POLYMORPHISM
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //POLYMORPHISM
    protected virtual void Shoot()
    {
        // Default is to do nothing
    }

    protected virtual void CheckBoundaries()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    // ENCAPSULATION
    public int getHP()
    {
        return this.hp;
    }
}
