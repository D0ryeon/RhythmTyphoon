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

    //����---
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

        //����
        _gameManager.CallOnEvenetIDchange(collision.GetComponent<EventData>().eventID);
        //�Ǵ� ���ӸŴ����� �ƴ� EventManager���� �̷��� ���·� ó���ϼŵ� ��������ϴ�.
        
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
