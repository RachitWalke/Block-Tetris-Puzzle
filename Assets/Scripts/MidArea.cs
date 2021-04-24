using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidArea : MonoBehaviour
{
    public RightBox rightBox;

    public LeftBox leftBox;

    public GameObject stonewall;
    public GameObject blackBack;

    public GameObject lightEffect1;
    public GameObject lightEffect2;

    public bool GameOver;
    public float startWaitTime;
    public float WaitTime;
    public bool reset = false;

    private void Start()
    {
        WaitTime = startWaitTime;
    }
    private void Update()
    {
      if(GameOver)
        {
            lightEffect1.SetActive(true);
            lightEffect2.SetActive(true);
            if(WaitTime <= 0.0f)
            {
                reset = true;
                lightEffect1.SetActive(false);
                lightEffect2.SetActive(false);
                stonewall.SetActive(true);
                blackBack.SetActive(true);
                WaitTime = 0.0f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            collision.GetComponent<BlockBehaviour>().inMid = true;
            if (rightBox.RightCount == 0 && leftBox.LeftCount == 0)
            {
                if (collision.GetComponent<BlockBehaviour>().inMid == true && collision.GetComponent<BlockBehaviour>().Mouseup == true)
                {
                    GameOver = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.GetComponent<BlockBehaviour>().inMid = false;
        }
    }
}
