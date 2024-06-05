using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAmmo : MonoBehaviour
{
    public Shooting ammo;
    public Text show;
    private void Start()
    {
        UpdateAmmoText();
    }
    private void Update()
    {
        UpdateAmmoText();
    }
    void UpdateAmmoText()
    {
        show.text = $"{ammo._currentAmmo} / {ammo._totalAmmo}";
    }

}
