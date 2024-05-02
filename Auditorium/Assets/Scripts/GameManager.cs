using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public float winDuration = 2f;
    public AudioSource[] _musicBoxes;
    private float _chrono = 0f;

    private bool _allMaxVolume = true;

    public UnityEvent NextLevelPanel = new UnityEvent();

    void Start()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("MusicBox");

        _musicBoxes = new AudioSource[boxes.Length];

        for (int i = 0; i < boxes.Length; i++)
        {
            _musicBoxes[i] = boxes[i].GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        _allMaxVolume = true;

        foreach (AudioSource box in _musicBoxes)
        {
            if (box.volume < 1f)
            {
                _allMaxVolume = false;
                break;
            }
        }

        if (_allMaxVolume)
        {
            _chrono += Time.deltaTime;
        }
        else
        {
            _chrono = 0f;
        }

        if (_chrono >= winDuration)
        {
            NextLevelPanel.Invoke();
        }
    }
}