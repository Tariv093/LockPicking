using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LocksClass
{
    public InputValue buttonInput;
    public Vector2 dInput;

    public Vector2 GetValues()
    {
        return dInput;
    }
    public void SetValues(Vector2 v2)
    {
        dInput = v2;
    }

}
