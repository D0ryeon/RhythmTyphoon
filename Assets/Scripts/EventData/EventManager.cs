using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public SpriteRenderer nowBackground;
    public EventData eventCollider;
    public Sprite[] stageBackground;
    public int eventID;

    private int eventIndex;
    public bool isEvent;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        _controller = GetComponent<CharactersController>();
        GenerateData();

    }

    private void Start()
    {
        _controller.OnAttackEvent += Action;
        
        //GameManager에서 변수 등록 시 사용
        //StageSpawn(GameManager.Instance.eventID);
        //아래는 임시
        StageSpawn(eventID);
       
    }

    private void StageSpawn(int eventID)
    {
        nowBackground.sprite = stageBackground[eventID-1];
        eventCollider.eventID = eventID;
    }

    private void GenerateData()
    {
        talkData.Add(1, new string[] { 
            "맞다 심부름",                                                   // 0
            "완전히 잊어먹고 있었네",                                        // 1
            "곧 있으면 태풍 온다니까<br>두부만 사서 얼른 집에 가야겠다",     // 2 , cut2 입 앙다무는 애니메이션
            "먹구름이 몰려온다",                                      // 3 , cut3 구름이 몰려오는 애니메이션
            "이렇게 갑자기?",                                                // 4 , cut4 반눈 애니메이션
            "바람이 강하게 분다",                                            // 5 , cut5 바람이 부는 애니메이션
            "으이익" ,                                                       // 6 , cut6 바람 부는 애니메이션 + 머리까짐 밀려남
            "갑자기 바람이 이렇게 분다고?",                                  // 7 , 그대로 
            "어 저게 뭐지?",                                                 // 8 , 그대로
            "날아오는 쓰레기통",                                             // 9 , cut8 쓰레기통 날아옴
            "끄아아아악"});                                                  // 10, cut9 끄아악 
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

    public void Action()
    {
        if (isEvent)
        {
            Debug.Log("다음텍스트");
            string talkData = GetEvent(eventID, eventIndex);
            if (talkData == null)
            {
                Debug.Log("텍스트 끝");
                isEvent = false;
                SceneManager.LoadScene("BattleScene");
                return;
            }
            eventText.text = talkData;
            //이벤트 애니메이션 추가할 곳
            if (eventID == 1)
            {
                switch (eventIndex)
                {
                    case 2:
                        Debug.Log("애니메이션 테스트");
                        anim.SetBool("cut2", true);
                        break;
                    case 3:

                        anim.SetBool("cut3", true);
                        break;
                    case 4:

                        anim.SetBool("cut4", true);
                        break;
                    case 5:
                        anim.SetBool("cut5", true);
                        break;
                    case 6:
                        anim.SetBool("cut6", true);
                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:
                        anim.SetBool("cut8", true);
                        break;
                    case 10:
                        anim.SetBool("cut9", true);
                        break;
                    default:
                        break;
                }
            }
            else if (eventID == 2)
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
            else if (eventID == 3)
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

}
