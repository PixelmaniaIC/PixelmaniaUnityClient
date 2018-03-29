using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNotification : MonoBehaviour {

    public GameObject notificationPanel;
    public GameObject gamePanel;
    public GameObject cube;

    public void Close()
    {
        notificationPanel.SetActive(false);
        gamePanel.SetActive(true);
        cube.SetActive(true);

        cube.GetComponent<MeshRenderer>().enabled = false;
    }
}
