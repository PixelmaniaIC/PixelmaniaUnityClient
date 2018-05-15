using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactsPanelUI : MonoBehaviour {

    public GameObject factsPanel;

    public Text refLink;
    private string _link;

    public string Link {
        get { return _link; }
        set
        {
            refLink.text = "READ MORE";
            _link = value;
        }
    }

    public string link;

    public void Close()
    {
        factsPanel.SetActive(false);
    }

    public void OpenURL()
    {
        if (_link != null)
        {
            Application.OpenURL(_link);
        }
    }
}
