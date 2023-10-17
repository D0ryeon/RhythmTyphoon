using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{ 
    public CreativeMode CreativeMode;
    void OnAttack()
    {
        Debug.Log("Attack");
        if(CreativeMode.recording)
         CreativeMode.OnMouseLeft();
    }

    private void OnAttack2()
    {
        if(CreativeMode.recording)
            CreativeMode.OnMouseRight();
    }
}
