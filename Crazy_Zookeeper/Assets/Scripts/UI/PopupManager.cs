using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject Popup_potion;
    public GameObject Popup_weapon;

    public void ShowPotionPopup()
    {
        Popup_potion.SetActive(true);
    }

    public void ShowWeaponPopup()
    {
        Popup_weapon.SetActive(true);
    }
}
