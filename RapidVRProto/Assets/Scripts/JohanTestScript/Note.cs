using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [HideInInspector] public float speed;
    
    [SerializeField] private int forceLimit, value;
    [SerializeField] private GameObject passText, perfectText;



    void Start()
    {

    }


    void Update()
    {

        transform.Translate(0, 0, -speed * Time.deltaTime);

    }

    public int Hit(float forceValue)
    {
        if (forceValue >= forceLimit)
        {
            GameObject gb = Instantiate(passText, gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 180));
            Destroy(gb.gameObject, 0.5f);
            Destroy(gameObject);
            return value;
        }
        else
            return 0;
       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            if(other.GetComponent<Button>().buttonDown && other.GetComponent<Button>().pressForce >= forceLimit)
            Destroy(gameObject);
        }
        else if (other.CompareTag("Fail"))
        {
            Destroy(gameObject);
        }
    }
}
