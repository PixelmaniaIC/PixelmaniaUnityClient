using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public InputField mainInputField;
    private bool _nameSetted = false;

    public void PlayGame()
    {
        if (_nameSetted)
        {
            SceneManager.LoadScene("main");
        }
    }

    public void SetName(InputField input)
    {
        _nameSetted = input.text.Length > 2;
        if (_nameSetted)
        {
            PlayerId.instance.UserName = input.text;
        }
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
