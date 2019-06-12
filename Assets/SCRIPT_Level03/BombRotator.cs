using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRotator : MonoBehaviour
{
    public GameObject explosionParticlesPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = UnityEngine.Random.Range(10f, 100f);
        float randomY = UnityEngine.Random.Range(10f, 100f);
        float randomZ = UnityEngine.Random.Range(10f, 100f);

        Rigidbody bomb = GetComponent<Rigidbody>();
        bomb.AddTorque(randomX, randomY, randomZ);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject explosion = (GameObject)Instantiate(explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation);
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
        }

        Destroy(gameObject);
    }
}
