using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���߿� ��ũ ������ ����ϴ� ��ũ��Ʈ (�̿ϼ�)
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
