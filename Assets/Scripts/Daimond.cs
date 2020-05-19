using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daimond : MonoBehaviour
{
    public int gems=1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player!=null)
            {
                player.AddGems(gems);
                Destroy(this.gameObject);

            }
                
            //collected
            

        }
    }
}
