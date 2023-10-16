using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletone<GameManager>
{
    public bool isRhythmMode = false;

    private GameObject playerWalk;
    private GameObject playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerWalk = Resources.Load<GameObject>("Prefabs/PlayerWalk");
        playerAttack = Resources.Load<GameObject>("Prefabs/PlayerAttack");
        //InstantiateGameObject(playerWalk, new Vector2(5, 0));
        //InstantiateGameObject(playerAttack, new Vector2(-5, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateGameObject(GameObject gameObject, Vector2 vector2)
    {
        Instantiate(gameObject, vector2, Quaternion.identity);
    }
}
