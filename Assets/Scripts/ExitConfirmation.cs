using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmation : MonoBehaviour {

    public GameObject exitConfirmationPanel;
    public GameObject gamePanel;
    public GameObject cube;
    public GameObject target;
    public GameObject leaderboardPanel;

    public void ShowConfirmation()
    {
        exitConfirmationPanel.SetActive(true);
        gamePanel.SetActive(false);        
        cube.SetActive(false);
        target.SetActive(false);
        leaderboardPanel.SetActive(false);

    }

    public void Resume()
    {
        exitConfirmationPanel.SetActive(false);
        gamePanel.SetActive(true);
        cube.SetActive(true);
        target.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
