using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyPatternData", menuName = "Pattern/ScriptableObject/Default", order = 0)]
public class Pattern : ScriptableObject
{
    [System.Serializable]
    public struct Note
    {
        public float time;
        public int type;
    }
    public List<Note> Notes;

    public string MusicName;
}
