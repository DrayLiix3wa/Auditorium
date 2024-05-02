using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    [SerializeField] private float spawnRadius = 5f;
    private float _chrono = 0f;
    private bool canSpawn = true;
    public GameObject _particlePrefab;
    public float spawnSpeed = 10f;
    
    void Update()
    {
        
        if (canSpawn)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject particle = ObjectPool.Get();
            particle.SetActive(true);
            particle.transform.position = spawnPosition;
            particle.GetComponent<Rigidbody2D>().velocity = transform.right * spawnSpeed;
            canSpawn = false;
        }
        
        _chrono += Time.deltaTime;

        if (_chrono >= spawnInterval)
        {
            canSpawn = true;
            _chrono = 0f;
        }
    }
}
