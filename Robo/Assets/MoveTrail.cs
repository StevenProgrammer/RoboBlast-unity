using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour
{




    public Vector2 mousePosition;
    public float bulletSpeed;
    private float step;
    public float moveSpeed;
    // Use this for initialization
    void Start()
    {
        mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);//Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    // Update is called once per frame
    void Update()
    {
        step = bulletSpeed * Time.deltaTime;
        transform.Translate (mousePosition * Time.deltaTime * moveSpeed); //(Vector2.MoveTowards(transform.position, mousePosition, step);
        Destroy (this.gameObject, 1);
    }

}
//transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
