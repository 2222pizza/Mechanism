using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotate : MonoBehaviour
{
    public float turnSpeed;
    public bool clockwise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise){
            this.gameObject.transform.Rotate(Vector3.up, turnSpeed);
        }else{
            this.gameObject.transform.Rotate(Vector3.down, turnSpeed);
        }
    }
}
