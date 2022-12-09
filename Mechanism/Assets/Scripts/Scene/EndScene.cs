using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.victory) {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
        }
        else {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
