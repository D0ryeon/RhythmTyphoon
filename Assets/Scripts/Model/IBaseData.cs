using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseData
{
    string Name { get; }
    int HP { get; }
    int MaxHP { get; }
    float Speed { get; }
}
