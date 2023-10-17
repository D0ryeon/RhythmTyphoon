using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeMode : MonoBehaviour
{
    public Pattern[] Patterns;

   public Pattern currentPattern;

    public float InputTiming1;
    public float InputTiming2;
    public float InputTiming3;

    public List<float> InputTiming;

    public float currentTime;

    public List<float> TestTiming;

    [SerializeField] private TestNoteSpawn TestNoteSpawn;

    private void Start()
    {
        currentTime = 0;

        InputTiming1 = 0;
        InputTiming2 = 0;
        InputTiming3 = 0;
        if(TestNoteSpawn != null)
          TestNoteSpawn.StartGame();
      
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputTiming2 = currentTime;
        InputTiming3 = InputTiming2 - InputTiming1;

        float roundedValue = Mathf.Round(InputTiming3 * 100.0f) * 0.01f;

        InputTiming.Add(roundedValue);
        InputTiming1 = InputTiming2;
    }


    public void SetList()
    {
        Debug.Log("SetList");
        Patterns[0].noteTiming.Clear();
        Patterns[0].noteTiming = InputTiming;
    }
}
