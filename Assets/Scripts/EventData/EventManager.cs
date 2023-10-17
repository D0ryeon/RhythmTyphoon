using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData()
    {
        talkData.Add(1, new string[] { "안녕", "헬로우 월드","테스트중" });
        talkData.Add(2, new string[] { "스테이지2","스테이지2테스트다","진짜다" });
        talkData.Add(3, new string[] { "스테이지3","스테이지3 된장국","마렵다" });
  
    }

    public string GetEvent(int id, int eventIndex)
    {
        if(eventIndex == talkData[id].Length)
        {
            return null;
        }
        return talkData[id][eventIndex];
    }

    void Update()
    {
            
    }
}
