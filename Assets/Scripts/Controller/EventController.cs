using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventController : MonoBehaviour
{

    public EventManager eventManager;
    public GameObject eventPanel;
    public GameObject stagePanel;
    public GameObject iconPanel;
    public TextMeshProUGUI eventText;

    //수정---
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }
    //-----
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //eventManager.eventID = collision.GetComponent<EventData>().eventID;
        stagePanel.SetActive(false);
        eventPanel.SetActive(true);
        gameObject.SetActive(false);
        eventManager.Action();

        //수정
        _gameManager.CallOnEvenetIDchange(collision.GetComponent<EventData>().eventID);
        //또는 게임매니저가 아닌 EventManager에서 이러한 형태로 처리하셔도 상관없습니다.
        
    }

    private void Update()
    {
        Move();
    }

    

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))

        {
            iconPanel.SetActive(false);   
        }
    }
}
