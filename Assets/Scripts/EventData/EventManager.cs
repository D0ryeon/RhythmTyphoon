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
        
        //GameManager拭辞 痕呪 去系 獣 紫遂
        //StageSpawn(GameManager.Instance.eventID);
        //焼掘澗 績獣
        StageSpawn(eventID);
       
    }

    private void StageSpawn(int eventID)
    {
        nowBackground.sprite = stageBackground[eventID-1];
        eventCollider.eventID = eventID;
    }

    private void GenerateData()
    {
        talkData.Add(1, new string[] { "限陥 宿採硯", "刃穿 猿股壱 赤醸革","稲 赤生檎 殿燃 紳陥艦猿<br>砧採幻 紫辞 杖献 増拭 亜醤畏陥","劾松亜 郊餓澗 蕉艦五戚芝","戚係惟 逢切奄?","郊寓戚 悪馬惟 歳陥","生焼焦 !!!! " ,"巷充析戚醤","劾焼神澗 床傾奄搭","生蕉だだだだだだだだ"});
        talkData.Add(2, new string[] { "什砺戚走2","什砺戚走2砺什闘陥","遭促陥" });
        talkData.Add(3, new string[] { "什砺戚走3","什砺戚走3 吉舌厩","原憩陥" });
  
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
        Debug.Log("陥製努什闘");
        string talkData = GetEvent(eventID, eventIndex);
        if (talkData == null)
        {
            Debug.Log("努什闘 魁");
            isEvent = false;
            SceneManager.LoadScene("BattleScene");
            return;
        }
        eventText.text = talkData;
        //戚坤闘 蕉艦五戚芝 蓄亜拝 員
        if(eventID == 1)
        {
            switch (eventIndex)
            {
                case 2:
                    Debug.Log("蕉艦五戚芝 砺什闘");
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
