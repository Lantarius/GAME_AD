using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntaractableObject : MonoBehaviour
{
    protected AudioSource audioFX;
    protected int State; //0 - IDLE, 1 - used
    virtual protected void Start()
    {
        audioFX = GetComponent<AudioSource>();
    }
    virtual public void DoAction() { }
}
