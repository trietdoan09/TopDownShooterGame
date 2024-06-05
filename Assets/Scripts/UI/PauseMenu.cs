using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Text _level;
    [SerializeField]
    private Text _health;
    [SerializeField]
    private Text _attack;
    [SerializeField]
    private Text _exp;
    [SerializeField]
    private HealthController _healthController;
    [SerializeField]
    private GameObject _showPlayerDied;
    public GameObject _showMenu;
    [SerializeField]
    private PlayerMoment player;
    private bool _active = false;

    private AudioManager audio;

    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void ShowText()
    {
        
        _health.text = $"Health: {_healthController._currentHealth}/{_healthController._maximumHealth}";
        _level.text = $"Level: {player._currentLevel}";
        _attack.text = $"Damage: {player._playerDamage}";
        _exp.text = $"Exp: {player._currentExp}/{player._maxExp}";
    }
    // Update is called once per frame
    void Update()
    {

        ShowText();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if(_healthController._currentHealth<=0)
        {
            StartCoroutine(PlayerDied());
        }
    }
    IEnumerator PlayerDied()
    {
        _showPlayerDied.SetActive(true);
        audio.PlayVFX(audio._playerDied);
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("LoadingScene");
    }
    void Pause()
    {
        _showMenu.SetActive(!_active);
        _active = !_active;
    }
    public void Resume()
    {
        _showMenu.SetActive(false);
    }
    public void Reset()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
