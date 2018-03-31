using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Linq;

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
        List<User> leaders = allUsers.GetRange(0, playerNames.Count);

        for (int i = 0; i < playerNames.Count; i++)
        {
            playerNames[i].text = leaders[i].name;
        }
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
        List<User> sortedUsers = allUsers.OrderByDescending(o => o.score).ToList();
        List<User> leaders = sortedUsers.GetRange(0, playerNames.Count);

         for (int i = 0; i < playerNames.Count; i++)
         {
             playerNames[i].text = leaders[i].name;
         }
    }
}
