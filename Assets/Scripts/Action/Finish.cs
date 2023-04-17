using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : IntaractableObject
{
    [SerializeField] TMP_Text text;
    public override void DoAction()
    {
        if(State == 0)
        {
            audioFX.Play();
            EventManager.CallStopGame();
            text.text = "7.77$";
        }
        State = 1;
    }
}
