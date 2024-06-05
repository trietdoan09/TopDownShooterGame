using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzeleFlash;
    [SerializeField]
    private GameObject _meleeAttack;
    public float bulletForce = 20f;
    
    public int _totalAmmo=13;
    public int _maximumAmmo = 12;
    public int _currentAmmo=4;

    public bool RangerAtk = false;
    public bool MeleeAtk = false;

    [SerializeField]
    private Animator animator;
    // Update is called once per frame
    [SerializeField]
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("RangerAtk", RangerAtk);
        if(Input.GetMouseButtonDown(0))
        {
            RangerAtk = true;
            if (_currentAmmo > 0)
            {
                Shoot();
                audioManager.PlayVFX(audioManager._gunShoot);
                _currentAmmo -= 1;
            }
            if (_currentAmmo <= 0)
            {
                ReloadAmount();
            }
        }
        RangerAtk = false;
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadAmount();
        }
    }
    IEnumerator MeleeATK()
    {
        
        MeleeAtk = true;
        yield return new WaitForSeconds(1f);
        MeleeAtk = false;
        
    }

    void ReloadAmount()
    {
        int reload = _maximumAmmo - _currentAmmo; // tinh duoc so luong dan muon reload
        if(_totalAmmo-reload>=0)
        {
            _currentAmmo += reload;
            _totalAmmo -= reload;
        }
        else
        {
            _currentAmmo += _totalAmmo;
            _totalAmmo -= _totalAmmo;
        }
    }

    public void AddAmmou(int _ammo)
    {
        _totalAmmo += _ammo;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject muzzle = Instantiate(muzzeleFlash, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(muzzle, 0.2f);
    }
}
