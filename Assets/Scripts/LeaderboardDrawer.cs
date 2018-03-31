using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Linq;
using System;

public class LeaderboardDrawer : MonoBehaviour {

    public GameObject leaderboardPanel;
    public GameObject cube;
    public GameObject colorPicker;
    public DefaultTrackableEventHandler trackableHandler;
    public List<Text> playerNames;
    public Leaderboard leaderboardController;

    void Start()
    {
        List<User> allUsers = leaderboardController.GetUsers().OrderByDescending(o => o.score).ToList();
        UpdateLeaderboard(allUsers);
    }

    public void HideOrShow() {
        if (leaderboardPanel.activeInHierarchy)
        {
            leaderboardPanel.SetActive(false);
            if (!trackableHandler.trackingFound) 
            {       
                colorPicker.SetActive(true);
            }            
        }
        else
        {
            leaderboardPanel.SetActive(true);           
            colorPicker.SetActive(false);
        }		 
	}   
    
    public void UpdateLeaderboard(List<User> allUsers)
    {
        int countOfUsers = Math.Min(playerNames.Count, allUsers.Count);

        List<User> leaders = allUsers.GetRange(0, countOfUsers);

        for (int i = 0; i < playerNames.Count; i++)
        {
            if (i < countOfUsers)
            {
                playerNames[i].text = leaders[i].name;
                playerNames[i].gameObject.SetActive(true);
            }
            else
            {
                playerNames[i].gameObject.SetActive(false);
            }
        }
    }
}
