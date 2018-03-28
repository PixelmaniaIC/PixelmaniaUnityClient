using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User {
    public string id;
    public string name;
    public int score;
    public bool online;
    
    public User(string id, string name, int score, bool online)
    {
        this.id = id;
        this.name = name;
        this.score = score;
    }

    public bool IsCurrent()
    {
        return (id == PlayerId.instance.id);
    }
}
