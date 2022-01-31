using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AmmoUIElements
{
    public PickupType pickupType;
    public Sprite displayImage;
    public bool countAmmo;
    public int totalAmmo;
}

public class WeaponUIHandler : MonoBehaviour
{
    [SerializeField] private List<AmmoUIElements> UIElements;
    [SerializeField] private Sprite infiniteAmmoImage;
    private AmmoUIElements _currentUIElement;
    private int _currentAmmo;
    private Sprite _origSprite;
    public delegate void OutOfAmmoDelegate(PickupType pickupType);
    public static event OutOfAmmoDelegate OnOutOfAmmo;
    
    
    void Start()
    {
        GetUIElementOfType(PickupType.Regular);
        SetImage(1);
        SetImage(0);
        PickupPicked(PickupType.Regular);
        WeaponPickup.OnPickupPicked += PickupPicked;
        Shoot.OnShotFired += ShotFired;
        
    }

    private void ShotFired()
    {
        _currentAmmo--;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text 
            = _currentAmmo.ToString();

        if (_currentAmmo < 1)
        {
            if (OnOutOfAmmo != null)
                OnOutOfAmmo(PickupType.Regular);
        }
    }

    private void GetUIElementOfType(PickupType pickupType)
    {
        _currentUIElement = UIElements.Single(x => x.pickupType == pickupType);
    }
    
    
    private void SetImage(int imageIndex)
    {
        if (imageIndex == 0)
        {
            gameObject.GetComponentsInChildren<Image>()[0].sprite = _currentUIElement.displayImage;
        }
        else if (imageIndex == 1)
        {
            gameObject.GetComponentsInChildren<Image>()[1].sprite = infiniteAmmoImage;
        }
    }
    
    private void PickupPicked(PickupType pickupType)
    {
        GetUIElementOfType(pickupType);
        _currentAmmo = _currentUIElement.totalAmmo;
        
        if(_currentUIElement.countAmmo)
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _currentUIElement.totalAmmo.ToString();

        else
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        }
    }
}
