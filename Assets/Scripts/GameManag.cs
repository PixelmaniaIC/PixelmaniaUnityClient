using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManag : MonoBehaviour {

    public string PlayerName { get; set; }

    public static GameManag instance;

    // Use this for initialization
    void Awake () {
        Application.runInBackground = true;
        
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
