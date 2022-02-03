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
        PickupPicked(PickupType.Regular);
        SetImage(0);
        WeaponPickup.OnPickupPicked += PickupPicked;
        Ammo.OnShotFired += ShotFired;
    }

    private void ShotFired()
    {
        Debug.Log("shot fired");
        if (_currentAmmo > 0)
        {
            _currentAmmo--;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _currentAmmo.ToString();
        }

        if (_currentAmmo < 1)
        {
            SetImage(1);
            PickupPicked(PickupType.Regular);
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
        switch (imageIndex)
        {
            case 0:
                gameObject.GetComponentsInChildren<Image>()[0].sprite = _currentUIElement.displayImage;
                break;
            case 1:
                gameObject.GetComponentsInChildren<Image>()[1].sprite = infiniteAmmoImage;
                break;
            case 2:
                gameObject.GetComponentsInChildren<Image>()[1].sprite = null;
                break;
        }
    }

    private void SetAmmoCount()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = 
            _currentUIElement.countAmmo ? _currentUIElement.totalAmmo.ToString() : " ";
    }
    
    private void PickupPicked(PickupType pickupType)
    {
        GetUIElementOfType(pickupType);
        SetImage(0);
        SetImage(2);
        _currentAmmo = _currentUIElement.totalAmmo;
        
        SetAmmoCount();
    }
}
