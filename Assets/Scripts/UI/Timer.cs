using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _currentHour;
    private float _currentMin;
    private float _currentSec;
    public Text _showTime;

    private void ShowTime()
    {
        _currentSec += Time.deltaTime;
        if (_currentSec >= 60f)
        {
            _currentSec = 0f;
            _currentMin += 1;
        }
        if(_currentMin>=60)
        {
            _currentMin = 0;
            _currentHour += 1;
        }

        _showTime.text = $" {Mathf.Round(_currentHour).ToString()}:{Mathf.Round(_currentMin).ToString()}:{ Mathf.Round(_currentSec).ToString()}";
    }
    // Update is called once per frame
    void Update()
    {
        ShowTime();
    }
}
