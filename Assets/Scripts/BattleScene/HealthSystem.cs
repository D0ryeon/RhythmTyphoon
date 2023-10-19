using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int cursorForIndex;
    private int maxLength;

    public GameObject healthIcon;
    public GameObject[] healthIcons;


    [SerializeField] private Vector3 durationBetweenHearts;
    [SerializeField] private Transform firstHealthIconPosition;

    [SerializeField] private UIManager _uiManager;

    private IBaseData _playerData;

    public void InitalizeHeart(int startHealth, int maxHealth)
    {
        healthIcons = new GameObject[maxHealth];
        maxLength = maxHealth;
        cursorForIndex = startHealth-1;
        for (int i = 0; i < maxLength; i++)
        {
            Vector3 positionWeight = i * durationBetweenHearts;
            GameObject heathIcon = Instantiate(healthIcon, firstHealthIconPosition.position + positionWeight, Quaternion.identity);
            healthIcons[i] = heathIcon;
            if (i > cursorForIndex)
            {
                Heart heart = heathIcon.GetComponent<Heart>();
                heart.SetDieState();
            }
        }

        _playerData = DataBase.Instance.PlayerData;
    }

    public void UpdateIcon(int changeWeight)
    {
        //changeWeight >0 , heal
        if (changeWeight >= 0)
        {
            for (int i = 0; i < changeWeight; i++)
            {
                if (cursorForIndex >= maxLength)
                {
                    cursorForIndex = maxLength - 1;
                }
                Heart heart = healthIcons[cursorForIndex].GetComponent<Heart>();
                heart.SetDefaultState();
                cursorForIndex++;
            }
        }
        //changeWeight <0 , damage
        if (changeWeight < 0)
        {
            changeWeight *= -1;
  
            for (int i = 0; i < changeWeight; i++)
            {
                if(cursorForIndex <= 0)
                {
                    cursorForIndex = 0;
                    _uiManager.UpdateGameState(UIManager.GameState.GameOver);
                }
                Heart heart = healthIcons[cursorForIndex].GetComponent<Heart>();
                heart.SetDieState();
                cursorForIndex--;
            }
        }
      
    }
    public void SetUIManager(UIManager UIManager) => this._uiManager = UIManager;

    public void AddIcon(int change)
    {
        int updateHP = _playerData.HP;
        for (int i = cursorForIndex; i < updateHP; i++)
        {
            if (cursorForIndex >= maxLength)
            {
                cursorForIndex = maxLength - 1;
            }
            Heart heart = healthIcons[cursorForIndex].GetComponent<Heart>();
            heart.SetDefaultState();
            cursorForIndex++;
        }
    }


}
