using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimEvent : MonoBehaviour
{
    Spider _spider;
    void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        Debug.Log("SpiderFire");
        _spider.Attack();
    }
}
