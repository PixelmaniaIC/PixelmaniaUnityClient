using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    public static PlayerId instance = null;

    private string _id = null;
    public string id
    {
        get { return _id; }
        set
        {
            if (_id == null)
            {
                _id = value;
            } else
            {
                // TODO: We need to delete it!
                throw new System.Exception(value.ToString());
            }
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
