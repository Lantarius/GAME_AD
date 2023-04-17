using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : IntaractableObject
{
    [SerializeField] ParticleSystem coinPS;
    public override void DoAction()
    {
        StartCoroutine(DeleteCoin());
    }
    IEnumerator DeleteCoin()
    {
        GetComponent<MeshRenderer> ().enabled = false;
        GetComponent<Collider>().enabled = false;   
        coinPS.Play();
        audioFX.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
