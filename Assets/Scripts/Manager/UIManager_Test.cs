using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager_Test : Singletone<UIManager_Test>
{
    protected UIManager_Test()
    {
    }

    private Dictionary<string, GameObject> _uiList = new Dictionary<string, GameObject>();
    private Canvas _canvas;
    private Transform _canvasTransform;

    public bool TestBtn;

    private void Awake()
    {
        CreateCavans();
        InitUIList();
    }

    private void InitUIList()
    {
        GameObject[] gameobjects = Resources.LoadAll<GameObject>("Prefabs/UI");
        foreach (GameObject obj in gameobjects)
        {
            GameObject uiobject = Instantiate(obj, _canvasTransform, false);
            _uiList.Add(uiobject.name, uiobject);
            uiobject.SetActive(false);
        }
    }

    public T OpenUI<T>()
    {
        var Obj = _uiList[typeof(T).Name];
        Obj.SetActive(true);
        return Obj.GetComponent<T>();
    }

    private void CreateCavans()
    {
        if (_canvas == null)
        {
            _canvas = (Canvas)FindObjectOfType(typeof(Canvas));

            if (_canvas == null)
            {
                _canvas = Resources.Load<Canvas>("Prefabs/Canvas");
                _canvasTransform = Instantiate(_canvas).transform;
            }
        }
    }
}
