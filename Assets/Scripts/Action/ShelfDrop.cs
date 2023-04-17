using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDrop : IntaractableObject
{
    [SerializeField] Rigidbody rbTarget;
    public override void DoAction()
    {
        if (State == 0)
        {
            rbTarget.isKinematic = false;
            audioFX.Play();
            State = 1;
        }

    }
}
