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
        _controller.OnAttackEvent += Action;
    }

    private void GenerateData()
    {
        talkData.Add(1, new string[] { "�´� �ɺθ�", "���� ��԰� �־���","�� ������ ��ǳ �´ٴϱ�<br>�κθ� �缭 �� ���� ���߰ڴ�","������ �ٲ�� �ִϸ��̼�","�̷��� ���ڱ�?","�ٶ��� ���ϰ� �д�","���ƾ� !!!! " ,"�������̾�","���ƿ��� ��������","���֤���������������"});
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
