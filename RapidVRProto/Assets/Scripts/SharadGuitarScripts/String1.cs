using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String1 : MonoBehaviour
    {

    public KeyCode activateString;
    public string lockInput = "n";
    public static string realeasedKey = "n";
    // Start is called before the first frame update
    void Start()
        {

        }

    // Update is called once per frame
    void Update()
        {
        if ((Input.GetKeyDown(activateString)) && (lockInput == "n"))
            {
            lockInput = "y";
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1f);
            StartCoroutine(retractCollider());
            realeasedKey = "n";
            }
        else if (Input.GetKeyUp(activateString))
            {
            realeasedKey = "y";
            }
        }

    IEnumerator retractCollider()
        {
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);//moving back

        if (realeasedKey == "n")
            {
            yield return new WaitForSeconds(1);
            StartCoroutine(releaseNote());
            }

        if (realeasedKey == "y")
            {
            StartCoroutine(releaseNote());
            }

        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);//make it at rest
        
        }

    IEnumerator releaseNote() 
        {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1f);// reverse what's done before 
        yield return new WaitForSeconds(.75f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        lockInput = "n";

        }
    }



    
