using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int cursorForIndex;
    private int maxLength;

    public GameObject healthIcon;
    public GameObject[] healthIcons;

    public bool gameOver= false;

    [SerializeField] private Vector3 durationBetweenHearts;
    [SerializeField] private Transform firstHealthIconPosition;

    [SerializeField] private UIManager UIManager;

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
                    gameOver = true;
                }
                Heart heart = healthIcons[cursorForIndex].GetComponent<Heart>();
                heart.SetDieState();
                cursorForIndex--;
            }
        }
      
    }
    public void SetUIManager(UIManager UIManager) => this.UIManager = UIManager;
}
