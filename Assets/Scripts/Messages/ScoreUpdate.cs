using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class ScoreUpdate
    {
        public int index;
        public int score;

        public static ScoreUpdate Build(string payload)
        {
            return JsonUtility.FromJson<ScoreUpdate>(payload);
        }
    }
}