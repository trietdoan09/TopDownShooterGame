using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _img;
    public void UpdateLoading(SceneLoading load)
    {
        _img.fillAmount = load.Loading();
        if (_img.fillAmount == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
