using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note2xControl : MonoBehaviour
{
    public Transform sucessBurst;
    public Transform failBurst;
    public int noteHP = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (noteHP <= 1)
        {
            Destroy(gameObject);
            Debug.Log(GM.winStreak);
            Instantiate(sucessBurst, transform.position, failBurst.rotation);
            GM.winStreak += 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FailCollider")
        {
            Destroy(gameObject);
            Debug.Log("Fail!!!");
            Instantiate(failBurst, transform.position, failBurst.rotation);
        }
        else if (other.gameObject.CompareTag("Button"))
        {
            if (other.gameObject.GetComponent<Button>().buttonDown)
                Destroy(gameObject);
            Debug.Log(GM.winStreak);
            Instantiate(sucessBurst, transform.position, failBurst.rotation);
            GM.winStreak += 1;
            GM.totalScore += 10;
        }
    }



    void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.name == "Success") && (String1.realeasedKey == "n")) ;
    }
}

