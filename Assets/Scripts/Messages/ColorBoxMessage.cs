﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class ColorBoxMessage
    {
        [SerializeField]
        public List<SingleColor> cubes;

        public static ColorBoxMessage Build(string payload)
        {
            Debug.Log("Payload received " + payload);    
            return JsonUtility.FromJson<ColorBoxMessage>(payload);
        }
    }
}