using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectStates
{
    void Move();
    void Turn();

    void AfterMap();
}


