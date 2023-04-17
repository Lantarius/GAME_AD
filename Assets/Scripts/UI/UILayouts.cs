using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILayouts : MonoBehaviour
{
    int State = 0;
    [SerializeField] GameObject StarterUI;
    [SerializeField] GameObject GamePlayUI;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && State == 0)
        {
            StarterUI.SetActive(false);
            GamePlayUI.SetActive(true);
            EventManager.CallStartGame();
            State = 1;
        }
    }
}
