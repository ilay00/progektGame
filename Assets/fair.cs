using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fair : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "heroidle1")
        {
            col.GetComponent<hero>().AddPatron(1);
            Destroy(gameObject);
        }
    }
}
