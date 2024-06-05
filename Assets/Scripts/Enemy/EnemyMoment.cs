using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMoment : MonoBehaviour
{
    [SerializeField]
    public float _speed;
    [SerializeField]
    private float _rotationSpeed;

    public float _currentHP;
    public float _maxHP;
    public float _bonusEXPBoss = 0;

    private AudioManager audio;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    public GameObject _spawnHealthItem;
    public GameObject _spawnAmountItem;
    private GameObject player;

    public UnityEvent OnHealthChanged;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _currentHP = _maxHP;
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        UpdateHealthBar();
        StopWhenPlayerDied();
    }
    private void StopWhenPlayerDied()
    {
        if(player.GetComponent<HealthController>()._currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
    private void UpdateTargetDirection()
    {
        if(_playerAwarenessController.AwarenessOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }
    private void RotateTowardsTarget()
    {
        if(_targetDirection==Vector2.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        _rigidbody.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        if(_targetDirection==Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * _speed;
        }
    }
    public void TakeDameAndDie(float damage)
    {
        _currentHP -= damage;
        OnHealthChanged.Invoke();
        if (_currentHP <= 0)
        {
            player.GetComponent<PlayerMoment>().SetExp(60+_bonusEXPBoss);
            audio.PlayVFX(audio._killEnemy);
            Destroy(gameObject);
            StartCoroutine(VfxExplosion());
            StopCoroutine(VfxExplosion());
        }
    }
    public float RemainingHealthPercentage
    {
        get { return _currentHP / _maxHP; }
    }
    public void UpdateHealthBar()
    {
        _healthBarForegroundImage.fillAmount = RemainingHealthPercentage;
    }
    IEnumerator VfxExplosion()
    {
        GameObject vfx = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(vfx,0.5f);
        DropItem();
        yield return null;
    }
    private void DropItem()
    {
        int _spawnItem = Random.Range(1, 100);
        if (_spawnItem <= 15)
        {
            GameObject healthItem = Instantiate(_spawnHealthItem, transform.position,Quaternion.identity);
        }
        else if (_spawnItem >= 16 && _spawnItem <= 35)
        {
            GameObject amountItem = Instantiate(_spawnAmountItem, transform.position, Quaternion.identity);
        }
    }

}
