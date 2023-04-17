using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject obj = GameObject.Find(this.name);
        if (obj != null && obj != gameObject)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
