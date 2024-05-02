using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    public TrailRenderer _tr;
    private Rigidbody2D _rb2d;

    private void OnEnable()
    {

    }

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_rb2d.velocity.magnitude > 1f && !_tr.emitting)
        {
            _tr.emitting = true;
        }

        if (_rb2d.velocity.magnitude <= 0.1f)
        {
            _rb2d.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _tr.emitting = false;
    }
}
