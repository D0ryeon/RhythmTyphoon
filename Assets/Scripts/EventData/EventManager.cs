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
    private bool isEvent;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        _controller = GetComponent<CharactersController>();
        GenerateData();

    }

    private void Start()
    {
        _controller.OnAttackEvent += Action;
        
        //GameManager���� ���� ��� �� ���
        //StageSpawn(GameManager.Instance.eventID);
        //�Ʒ��� �ӽ�
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
            "�´� �ɺθ�",                                                   // 0
            "������ �ؾ�԰� �־���",                                        // 1
            "�� ������ ��ǳ �´ٴϱ�<br>�κθ� �缭 �� ���� ���߰ڴ�",     // 2 , cut2 �� �Ӵٹ��� �ִϸ��̼�
            "�Ա����� �����´�",                                      // 3 , cut3 ������ �������� �ִϸ��̼�
            "�̷��� ���ڱ�?",                                                // 4 , cut4 �ݴ� �ִϸ��̼�
            "�ٶ��� ���ϰ� �д�",                                            // 5 , cut5 �ٶ��� �δ� �ִϸ��̼�
            "������" ,                                                       // 6 , cut6 �ٶ� �δ� �ִϸ��̼� + �Ӹ����� �з���
            "���ڱ� �ٶ��� �̷��� �дٰ�?",                                  // 7 , �״�� 
            "�� ���� ����?",                                                 // 8 , �״��
            "���ƿ��� ��������",                                             // 9 , cut8 �������� ���ƿ�
            "���ƾƾƾ�"});                                                  // 10, cut9 ���ƾ� 
        talkData.Add(2, new string[] { "��������2","��������2�׽�Ʈ��","��¥��" });
        talkData.Add(3, new string[] { "��������3","��������3 ���屹","���ƴ�" });
  
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
        Debug.Log("�����ؽ�Ʈ");
        string talkData = GetEvent(eventID, eventIndex);
        if (talkData == null)
        {
            Debug.Log("�ؽ�Ʈ ��");
            isEvent = false;
            SceneManager.LoadScene("BattleScene");
            return;
        }
        eventText.text = talkData;
        //�̺�Ʈ �ִϸ��̼� �߰��� ��
        if(eventID == 1)
        {
            switch (eventIndex)
            {
                case 2:
                    Debug.Log("�ִϸ��̼� �׽�Ʈ");
                    anim.SetBool("cut2",true);
                    break;
                case 3:
                    
                    anim.SetBool("cut3", true);
                    break;
                case 4:
                   
                    anim.SetBool("cut4", true);
                    break;
                case 5:
                    anim.SetBool("cut5",true);
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
