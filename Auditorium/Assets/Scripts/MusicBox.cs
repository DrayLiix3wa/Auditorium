using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _offColor;
    public Color _onColor;
    public SpriteRenderer[] _bars;

    
    void Start()
    {
        
    }

    void Update()
    {
        for ( int i = 0; i < _bars.Length; i++ )
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
    }
}
