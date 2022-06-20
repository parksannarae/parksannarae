using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    // Start is called before the first frame update
 
 
    public float moveSpeed = 30.0f;
    public float turnSpeed = 10.0f;

    private float h;
    private float v;

    private void Update()
    {
        h = Input.GetAxis("Horizontal");  // -1.0f ~ 1.0f
        v = Input.GetAxis("Vertical");     // -1.0f ~ 1.0f

        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * v);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * h);
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("BOX"))
        {
            Destroy(gameObject);
        }
    }
}
    

