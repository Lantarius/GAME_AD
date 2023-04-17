using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogoScript : MonoBehaviour
{
    RectTransform rtTransforn;
    [SerializeField] Image Logo;
    [SerializeField] TMP_Text Text;
    private void Start()
    {
        rtTransforn = Logo.GetComponent<RectTransform>();
        EventManager.StopGame.AddListener(StartAnimattion);
    }
    void StartAnimattion()
    {
        rtTransforn.anchoredPosition= new Vector3(0.5f, 0.5f);
        Logo.GetComponent<Animation>().Play();
        Text.gameObject.SetActive(true);
        Text.GetComponent<Animation>().Play();
    }
}
