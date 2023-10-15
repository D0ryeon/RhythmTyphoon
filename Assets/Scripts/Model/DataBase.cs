using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] private IBaseData _baseData;
    public IBaseData BaseData { get { return _baseData; } }


}
