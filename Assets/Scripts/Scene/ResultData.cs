using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultData : MonoBehaviour
{
    public GameObject PlayData;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;

    // Start is called before the first frame update
    void Start()
    {
        int Score = PlayData.GetComponent<UIManager>().currentScore;
        int Combo = PlayData.GetComponent<UIManager>().combo;

        ScoreText.text = Score.ToString();
        ComboText.text = Combo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
