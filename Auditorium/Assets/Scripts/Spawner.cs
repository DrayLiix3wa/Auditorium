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
    
    void Update()
    {
        
        if (canSpawn)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject particle = Instantiate(_particlePrefab, spawnPosition, Quaternion.identity);
            particle.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
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
