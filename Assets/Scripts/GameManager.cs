using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("GameManagererror");

            return _instance;

        }
    }
    void Awake()
    {
        _instance = this;
    }

    public bool hasKeyToCastel
    {
        get;
        set;
    }
}
