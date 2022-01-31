using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AmmoUIElements
{
    public PickupType pickupType;
    public Image displayImage;
    public bool countAmmo;
    public int totalAmmo;
}

public class WeaponUIHandler : MonoBehaviour
{
    [SerializeField] private List<AmmoUIElements> UIElements;
    private PickupType _currentType;

    public delegate void OutOfAmmoDelegate(PickupType pickupType);
    public static event OutOfAmmoDelegate OnOutOfAmmo;
    
    
    void Start()
    {
        WeaponPickup.OnPickupPicked += PickupPicked;
    }
    
    private void PickupPicked(PickupType pickupType)
    {
        _currentType = pickupType;
    }
}
