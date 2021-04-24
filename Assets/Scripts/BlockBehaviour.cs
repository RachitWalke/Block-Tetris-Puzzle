using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public Vector2 initPos;
    private Vector2 MousePos;
    private float X;
    private float Y;
    public bool inMid = false;
    public bool Mouseup = false;
    Rigidbody2D rb;
    public MidArea midArea;

    //audio
    public AudioSource audsrc;
    public AudioClip clip1;
    public AudioClip clip2;
    
    // Start is called before the first frame update
    void Start()
    {
        initPos.x = transform.position.x;
        initPos.y = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Mouseup = true;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Mouseup = false;
        }

        if(midArea.reset)
        {
            transform.position = new Vector2(initPos.x, initPos.y);
            inMid = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    //mouse functions
    private void OnMouseDown()
    {
        X = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        Y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        audsrc.PlayOneShot(clip1);
    }
    private void OnMouseDrag()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(MousePos.x - X, MousePos.y - Y);
    }
    private void OnMouseUp()
    {
        if (!inMid)
        {
            transform.position = new Vector2(initPos.x, initPos.y);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if(inMid)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        audsrc.PlayOneShot(clip2);
    }

    //collision detection
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bound" && gameObject.GetComponent<PolygonCollider2D>().isTrigger == false)
        {
            transform.position = new Vector2(initPos.x, initPos.y);
            inMid = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Reset")
        {
            transform.position = new Vector2(initPos.x, initPos.y);
            inMid = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
