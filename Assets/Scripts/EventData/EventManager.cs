using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    private CharactersController _controller;
    public GameObject eventPanel;
    public GameObject stagePanel;
    public GameObject iconPanel;
    public Animator anim;
    public TextMeshProUGUI eventText;
    public GameObject eventName;
    private int eventIndex;
    private bool isEvent;
    public int eventID;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        _controller = GetComponent<CharactersController>();
        GenerateData();
    }

    private void Start()
    {
        _controller.OnInteractionEvent += Action;
    }

    private void GenerateData()
    {
        talkData.Add(1, new string[] { "맞다 심부름", "완전 까먹고 있었네","곧 있으면 태풍 온다니까<br>두부만 사서 얼른 집에 가야겠다","날씨가 바뀌는 애니메이션","이렇게 갑자기?","바람이 강하게 분다","으아악 !!!! " ,"무슨일이야","날아오는 쓰레기통","으애ㅐㅐㅐㅐㅐㅐㅐㅐ"});
        talkData.Add(2, new string[] { "스테이지2","스테이지2테스트다","진짜다" });
        talkData.Add(3, new string[] { "스테이지3","스테이지3 된장국","마렵다" });
  
    }

    public string GetEvent(int id, int eventIndex)
    {
        if (eventIndex == talkData[id].Length)
        {
            return null;
        }
        return talkData[id][eventIndex];
    }

    void Update()
    {
            
    }

    public void Action()
    {
        Debug.Log("다음텍스트");
        string talkData = GetEvent(eventID, eventIndex);
        if (talkData == null)
        {
            Debug.Log("텍스트 끝");
            isEvent = false;
            return;
        }
        eventText.text = talkData;
        //이벤트 애니메이션 추가할 곳
        if(eventID == 1)
        {
            switch (eventIndex)
            {
                case 2:
                    Debug.Log("애니메이션 테스트");
                    anim.SetBool("cut2",true);
                    break;
                case 3:
                    eventName.SetActive(false);
                    break;
                case 4:
                    eventName.SetActive(true);
                    anim.SetTrigger("cut3");
                    break;
                case 5:
                    anim.SetTrigger("cut4");
                    break;
                default:
                    break;
            }
        } 
        else if(eventID == 2)
        {
            switch (eventIndex)
            {
                case 2:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        } 
        else if(eventID == 3)
        {
            switch (eventIndex)
            {
                case 2:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

            eventIndex++;
    }

}
