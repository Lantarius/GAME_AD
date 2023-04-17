using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : IntaractableObject
{
    [SerializeField] Animation anim;
    override public void DoAction()
    {
        if(State == 0)
        {
            anim.Play();
            audioFX.Play();
            State = 1;
        }

    }
}
