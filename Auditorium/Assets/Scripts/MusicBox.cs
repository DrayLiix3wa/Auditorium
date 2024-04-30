using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _offColor;
    public Color _onColor;
    public SpriteRenderer[] _bars;
    public float _volumePlus = 0.01f;
    public float _volumeMinus = 1f;
    private float chrono = 0f;
    public float waitInterval = 1f;
    private bool particleEnter = false;
    
    void Start()
    {
        _audioSource.volume = 0f;
    }

    void Update()
    {
        for (int i = 0; i < _bars.Length; i++)
        {
            float seuil = (float)i / (float)_bars.Length;

            if (_audioSource.volume > seuil)
            {
                _bars[i].color = _onColor;
            }
            else
            {
                _bars[i].color = _offColor;
            }
        }

        if (particleEnter)
        {
            chrono += Time.deltaTime;
            if (chrono > waitInterval)
            {
                particleEnter = false;
                chrono = 0f;
            }
        }
        else
        {

            if (!particleEnter)
            {
                _audioSource.volume -= _volumeMinus * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Particule"))
            {
                particleEnter = true;
                chrono = 0f;

                _audioSource.volume += _volumePlus;
            }

        }
    }
