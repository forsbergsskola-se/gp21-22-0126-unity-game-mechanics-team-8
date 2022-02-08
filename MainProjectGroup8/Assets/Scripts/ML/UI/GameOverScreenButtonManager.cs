using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenButtonManager : MonoBehaviour
{
    private List<Button> _buttons;
    void Start()
    {
       _buttons = GetComponentsInChildren<Button>().ToList();
       SetupButtons();
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
        _buttons[0].onClick.AddListener(Restart);
        
        _buttons[1].onClick.AddListener(Quit);
    }
}
