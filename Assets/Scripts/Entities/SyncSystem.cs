using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 나중에 싱크 조절시 사용하는 스크립트 (미완성)
public class SyncSystem : MonoBehaviour
{
    private float addSync;

    public Action<float> OnAddSyncEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CallAddSync()
    {
        OnAddSyncEvent?.Invoke(addSync);
    }
}
