using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect  : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IDamagable hit = other.GetComponent<IDamagable>();
            if (hit != null )
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }


}
