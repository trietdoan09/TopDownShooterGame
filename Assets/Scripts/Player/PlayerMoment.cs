using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMoment : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject _levelUpText;

    Vector2 movement;
    Vector2 mousePos;

    [SerializeField]
    private AudioManager audioManager;

    public double _currentExp = 0;
    public double _maxExp = 100;
    public int _currentLevel = 1;
    public float _playerDamage;

    public UnityEvent OnExpChanged;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angel = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angel + 90f;
    }

    public double RemainingExpPercentage()
    {
        return _currentExp / _maxExp; 
    }
    //public static int ExpNeedToLevelUp(int currenLevel)
    //{
    //    if (currenLevel == 0)
    //        return 0;
    //    return (currenLevel * currenLevel + currenLevel) * 5;
    //}
    public void SetExp(double exp)
    {
        _currentExp += exp;
        OnExpChanged.Invoke();
        // level up with exp
        if (_currentExp>=_maxExp)
        {
            LevelUp();
            StartCoroutine(LevelUpTextTurnOn());
        }
    }
    IEnumerator LevelUpTextTurnOn()
    {
        _levelUpText.SetActive(true);
        yield return new WaitForSeconds(1f);
        _levelUpText.SetActive(false);
    }
    private void LevelUp()
    {
        _currentExp = 0;
        _maxExp += _maxExp * 0.2;
        _currentLevel += 1;
        HealthController health = gameObject.GetComponent<HealthController>();
        if (health._currentHealth == health._maximumHealth)
        {
            health._maximumHealth += 10;
            health._currentHealth = health._maximumHealth;
        }
        else
        {
            health._maximumHealth += 10;
        }
        _playerDamage += 1;
    }
}
