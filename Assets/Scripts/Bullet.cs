using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    private SpawnManager spawnManager;
    private float bulletSpeed = 15.0f;
    private float timeToDestroy = 5f;
    
    private void Awake()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        //bulletRb.MovePosition(Vector2.up * bulletSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawnManager.enemyCount--;
        }
    }
}
