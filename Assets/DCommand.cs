using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCommand : MonoBehaviour
{
    public bool isPressing = false;
    public DController controller;

    public DCommand(DController controller)
    {
        this.controller = controller;
    }

    public virtual void PointerDown()
    {
        isPressing = true;
    }

    public virtual void PointerUp() 
    {
        isPressing = false;
    }
}
