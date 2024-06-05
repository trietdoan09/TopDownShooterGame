using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public UnityEvent OnLoadingChange;
    private float _currentPercent = 10;
    private void Update()
    {
        _currentPercent += Random.Range(0.01f, 0.2f) + Time.deltaTime;
        OnLoadingChange.Invoke();
        LoadText();
    }
    public float Loading()
    {
        return _currentPercent / 100;
    }
    public void LoadText()
    {
        text.text = $"{Mathf.Round(_currentPercent)}% ...";
    }
}
