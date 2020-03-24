using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class patron : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Enemy")
        {
            col.GetComponent<enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
