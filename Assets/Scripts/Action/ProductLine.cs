using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductLine : IntaractableObject
{
    public override void DoAction()
    {
        audioFX.Play();
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        target.AddForce(Vector3.right * 6,ForceMode.Acceleration);
    }
}
