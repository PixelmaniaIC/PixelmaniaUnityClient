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
        List<User> allUsers = leaderboardController.GetUsers();
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
        int leadersCount = Math.Min(playerNames.Count, allUsers.Count);

        List<User> leaders = allUsers.OrderByDescending(user => user.score).ToList().GetRange(0, leadersCount);

        User currentUser = allUsers.Find(user => user.IsCurrent());
        int currentUserPosition = allUsers.FindIndex(user => user.IsCurrent()) + 1;

        for (int i = 0; i < playerNames.Count; i++)
        {
            if (i < leadersCount)
            {
                if (currentUserPosition > playerNames.Count)
                {
                    if (i == 3)
                    {
                        playerNames[i].text = "...";
                    }
                    else if (i == 5)
                    {
                        playerNames[i].color = Color.cyan; // new Color(253, 87, 178, 255);
                        playerNames[i].text = currentUserPosition.ToString() + ". " + currentUser.name + " (you) - " + currentUser.score;
                    }
                }

                else
                {
                    string position = (i + 1).ToString();
                    playerNames[i].text = position + ". " + leaders[i].name + " - " + leaders[i].score;

                    if (leaders[i].IsCurrent())
                    {
                        playerNames[i].color = Color.cyan; // new Color(253, 87, 178, 255);
                        playerNames[i].text += " (you)";
                    }
                    else
                    {
                        playerNames[i].color = Color.white;
                    }
                }

                playerNames[i].gameObject.SetActive(true);
            }

            else
            {
                playerNames[i].gameObject.SetActive(false);
            }
        }
    }
}
