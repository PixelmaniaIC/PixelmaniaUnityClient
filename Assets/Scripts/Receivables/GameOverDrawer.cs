using UnityEngine;

public class GameOverDrawer : FinishGameListener
{
    public GameObject gameOverPanel;
    public DefaultTrackableEventHandler trackableHandler;
    public GameObject leaderboardPanel;

    public override void OnGameFinished()
    {
        gameOverPanel.SetActive(true); 

        if (!trackableHandler.trackingFound)
        {
            leaderboardPanel.SetActive(true);
        }
    
    }   
}
