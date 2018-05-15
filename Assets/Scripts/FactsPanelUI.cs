using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactsPanelUI : MonoBehaviour {

    public GameObject factsPanel;

    public void Close()
    {
        factsPanel.SetActive(false);
    }

    public void OpenURL()
    {        
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
