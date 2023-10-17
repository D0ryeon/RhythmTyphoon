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
    public TextMeshPro eventText;
    public int eventIndex;
    public bool isEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {

        stagePanel.SetActive(false);
        eventPanel.SetActive(true);
        Talk(collision.GetComponent<EventData>().eventID);
    }



    void Talk(int id)
    {
        string talkData = eventManager.GetEvent(id, eventIndex);
        if(talkData == null)
        {
            isEvent = false;
            return;
        }
        eventText.text = talkData;
        //이벤트 애니메이션 추가할 곳

        eventIndex++;

    }
}
