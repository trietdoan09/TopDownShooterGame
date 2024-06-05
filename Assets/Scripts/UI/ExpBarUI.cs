using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _expBarForegroundImage;
    public void UpdateExpBar(PlayerMoment player)
    {
        _expBarForegroundImage.fillAmount = (float)player.RemainingExpPercentage();
        if(_expBarForegroundImage.fillAmount==1)
        {
            _expBarForegroundImage.fillAmount = 0;
        }
    }
}
