using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    NoteSpawnManager noteSpawnManager;
    UIManager uiManager;


    private void Awake()
    {
        noteSpawnManager = NoteSpawnManager.instance;
        uiManager = UIManager.instance;

    }
   
}
