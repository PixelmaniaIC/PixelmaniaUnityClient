using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour
{
    public static PlayerId instance = null;

    private string _val = null;
    public string val
    {
        get { return _val; }
        set
        {
            if (_val == null)
            {
                _val = value;
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
