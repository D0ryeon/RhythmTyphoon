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
        talkData.Add(1, new string[] { "�ȳ�", "��ο� ����","�׽�Ʈ��" });
        talkData.Add(2, new string[] { "��������2","��������2�׽�Ʈ��","��¥��" });
        talkData.Add(3, new string[] { "��������3","��������3 ���屹","���ƴ�" });
  
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
