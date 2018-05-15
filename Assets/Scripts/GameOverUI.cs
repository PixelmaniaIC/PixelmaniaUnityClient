using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public GameObject factsPanel;
   

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }
    
    public void SeeMore()
    {
        factsPanel.SetActive(true);
    }
}
