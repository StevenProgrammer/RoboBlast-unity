using UnityEngine;
using System.Collections;

public class PlatformMoving : MonoBehaviour {

	// Use this for initialization
 public GameObject platforms;
    public float Countdowntimer = 16f;
    bool TimerisReset = false;
    float moveSpeed = 100;
    public Vector2 up;

    // Use this for initialization
    void Start()
    {
     
        Countdowntimer -= Time.deltaTime;
       // MovePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        Countdowntimer -= Time.deltaTime;
        //MovePlatforms();
    }

    /*
    void MovePlatforms()
    {

        if (Countdowntimer < 0)
        {
            Countdowntimer = 16;
            TimerisReset = true;
        }

        if (TimerisReset == true)
        {

        }

        if (Countdowntimer > 1.1)
        {
            TimerisReset = false;
        }

        //
        if (Countdowntimer <=10)
        {
            //platforms.transform.Translate(2.0f, .0f, 0.0f);
            platforms.transform.Translate(up * Time.deltaTime * moveSpeed);

        }
        else
        {
            if (Countdowntimer >= 14 && Countdowntimer <= 14.1)
            {
                Debug.Log("7");



            }
            else
            {
                if (Countdowntimer >= 12 && Countdowntimer <= 12.1)
                {
                    Debug.Log("6");


                }
                else
                {
                    if (Countdowntimer >= 10 && Countdowntimer <= 10.1)
                    {
                        Debug.Log("5");

                    }
                    else
                    {
                        if (Countdowntimer >= 8 && Countdowntimer <= 8.1)
                        {
                            Debug.Log("4");

                        }
                        else
                        {
                            if (Countdowntimer >= 6 && Countdowntimer <= 6.1)
                            {
                                Debug.Log("3");

                            }
                            else
                            {
                                if (Countdowntimer >= 4 && Countdowntimer <= 4.1)
                                {
                                    Debug.Log("2");

                                }
                                else
                                {
                                    if (Countdowntimer >= 2 && Countdowntimer <= 2.1)
                                    {
                                        Debug.Log("1");

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    */
}
