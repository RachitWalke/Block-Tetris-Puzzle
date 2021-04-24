using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBox : MonoBehaviour
{
    public int LeftCount=0;
    public RightBox rightBox;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block" )
        {
            LeftCount--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            LeftCount++;
        }
    }
}