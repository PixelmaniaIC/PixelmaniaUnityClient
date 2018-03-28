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
        Debug.Log(string.Format("Player Name is: {0}", PlayerId.instance.UserName));
    }

    //TODO: проверить, кажется, не работает
    public void QuitGame() 
    {
        Application.Quit();
    }
}
