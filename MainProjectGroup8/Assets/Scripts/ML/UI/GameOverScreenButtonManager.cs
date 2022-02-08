using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenButtonManager : MonoBehaviour
{
    void Start()
    {
        SetupButtons();
    }

    private void OnDisable()
    {
        var buttons = GetComponentsInChildren<Button>().ToList();
        buttons[0].onClick.RemoveAllListeners();
        buttons[1].onClick.RemoveAllListeners();
    }


    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void SetupButtons()
    {
        var buttons = GetComponentsInChildren<Button>().ToList();
        buttons[0].onClick.AddListener(Restart);
        buttons[1].onClick.AddListener(Quit);
    }
}
