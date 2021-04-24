using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour
{
  
    Rigidbody2D rb;

    public GameObject canvasObj;

    public AudioSource audsrc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.up * 0.2f);
        audsrc.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Reset")
        {
            canvasObj.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
