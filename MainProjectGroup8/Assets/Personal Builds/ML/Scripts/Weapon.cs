using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    [SerializeField]  private float shootDelay = 1.0f;
    [SerializeField] private bool countAmmo = false;
    [SerializeField] private int ammoAmount = 0;
}
