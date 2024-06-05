using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invicibilityDuration;
    private InvincibilityController _invincibilityController;
    private void Awake()
    {
        _invincibilityController = GetComponent<InvincibilityController>();
    }
    public void StartInvicibility()
    {
        _invincibilityController.StartInvincibility(_invicibilityDuration);
    }
}
