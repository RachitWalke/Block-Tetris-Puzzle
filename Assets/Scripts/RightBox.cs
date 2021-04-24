using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBox : MonoBehaviour
{
    public int RightCount = 0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            RightCount--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            RightCount++;
        }
    }
}
