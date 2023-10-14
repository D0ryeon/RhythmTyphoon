using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int startHealth;

    public GameObject healthIcon;
    public GameObject[] heathIcons;

    [SerializeField] private Vector3 durationBetweenHearts;
    [SerializeField] private Transform firstHealthIconPosition;

    [SerializeField] private UIManager UIManager;
    void Start()
    {
        heathIcons = new GameObject[maxHealth];
        currentHealth = startHealth;
        for (int i = 0; i < heathIcons.Length; i++)
        {
            Vector3 positionWeight = i * durationBetweenHearts;
            GameObject heathIcon = Instantiate(healthIcon, firstHealthIconPosition.position + positionWeight, Quaternion.identity);
            heathIcons[i] = heathIcon;
            if (i > startHealth)
            {
                Heart heart = heathIcon.GetComponent<Heart>();
                heart.SetDieState();
            }
        }
        UIManager.OnUpdateHealth += UpdateIcon;
    }

    public void UpdateIcon(int num)
    {
        currentHealth -= num;
        for(int i=0; i< heathIcons.Length; i++)
        {
            Heart heart = heathIcons[i].GetComponent<Heart>();
            if(i< currentHealth)
               heart.SetDefaultState();
            else
                heart.SetDieState();
        }
    }
    public void SetUIManager(UIManager UIManager) => this.UIManager = UIManager;
}
