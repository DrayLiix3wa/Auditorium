using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject[] _musicBoxes;
    private bool win;
    private float _chrono = 0f;
    public float timeForWin = 5f;
    public UnityEvent OnWin = new UnityEvent();

    void Start()
    {
        _musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
    }

    void Update()
    {
        win = true;
        
        foreach (var item in _musicBoxes)
        {
            if(item.GetComponent<AudioSource>().volume != 1f)
            {
                win = false;
                break;
            }
        }

        if (win)
        {
            _chrono += Time.deltaTime;

            if (_chrono < timeForWin)
            {
                OnWin.Invoke();
                Debug.Log("Gagné");
            }
        }
        else
        {
            _chrono = 0f;
        }
    }
}
