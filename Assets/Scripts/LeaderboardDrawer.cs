using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LeaderboardDrawer : MonoBehaviour {

    public GameObject leaderboardPanel;
    public GameObject cube;
    public GameObject colorPicker;
    public DefaultTrackableEventHandler trackableHandler;

    public void HideOrShow() {
        if (leaderboardPanel.activeInHierarchy)
        {
            leaderboardPanel.SetActive(false);
            if (!trackableHandler.trackingFound) 
            {
            //    cube.SetActive(true);
                colorPicker.SetActive(true);
            }            
        }
        else
        {
            leaderboardPanel.SetActive(true);
            // cube.SetActive(false);
            colorPicker.SetActive(false);
        }		 
	}
}
