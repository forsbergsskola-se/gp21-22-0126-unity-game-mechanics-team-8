using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
  public void QuitGame()
  {
    Debug.Log("Quitting game...");
    Application.Quit();
  }
}
