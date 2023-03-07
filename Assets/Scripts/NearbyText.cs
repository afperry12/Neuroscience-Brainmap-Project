using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearbyText : MonoBehaviour
{
    public GameObject nametext;
    public GameObject player;
    public GameObject answertext;
    public float Distance_;
    bool nameshown = true;
    void Start()
    {
        // nametext = GameObject.Find("New Text");
        player = GameObject.Find("First Person Player");
    }

    void Update()
    {
        if (nameshown == true)
        {
            Distance_ = Vector3.Distance(nametext.transform.position, player.transform.position);
            if (Distance_ <= 30)
            {
                nametext.GetComponent<Renderer>().enabled = true;
                nametext.transform.LookAt(2 * transform.position - player.transform.position);
                // nametext.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
            }
            else
            {
                nametext.GetComponent<Renderer>().enabled = false;
            }

            if (Distance_ <= 25 && Input.GetKey("e"))
            {
                answertext.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                answertext.GetComponent<Renderer>().enabled = false;
            }

            Debug.Log("Distance: " + Distance_);
        }
        
        if (nameshown == false)
        {
            Distance_ = Vector3.Distance(answertext.transform.position, player.transform.position);
            if (Distance_ <= 30)
            {
                answertext.GetComponent<Renderer>().enabled = true;
                answertext.transform.LookAt(2 * transform.position - player.transform.position);
                // nametext.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
            }
            else
            {
                answertext.GetComponent<Renderer>().enabled = false;
            }

            if (Distance_ <= 25 && Input.GetKey("e"))
            {
                nametext.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                nametext.GetComponent<Renderer>().enabled = false;
            }

            Debug.Log("Distance: " + Distance_);
        }

        if (Input.GetKey("o"))
        {
            nameshown = false;
        }
    }

    // void OnTriggerEnter (Collider other) {
    //     if (other.tag.Equals ("Player")) {
    //         hidey.gameObject.SetActive(true);
    //     }
    // }
    //
    // void OnTriggerExit (Collider other) {
    //     if (other.tag.Equals ("Player")) {
    //         hidey.gameObject.SetActive(false);
    //     }
    // }
    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.LogFormat("{0} trigger enter: {1}", this, other);
    //     Console.WriteLine("here!");
    // }
    // private void OnTriggerStay(Collider other)
    // {
    //     Debug.LogFormat("{0} trigger stay: {1}", this, other);
    //     Console.WriteLine("here!");
    // }
    // private void OnTriggerExit(Collider other)
    // {
    //     Debug.LogFormat("{0} trigger exit: {1}", this, other);
    //     Console.WriteLine("here!");
    // }
    

}
