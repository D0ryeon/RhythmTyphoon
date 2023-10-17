using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyPatternData", menuName = "Pattern/ScriptableObject/Default", order = 0)]
public class Pattern : ScriptableObject
{
    public enum EventPattern { Trap, Special1, Special2, Special3 }

    public List<float> noteTiming;
    [System.Serializable]
    public struct EventData{
        public int indexTiming;
        public EventPattern eventPattern;
    }

    public List<EventData> Events;
}
