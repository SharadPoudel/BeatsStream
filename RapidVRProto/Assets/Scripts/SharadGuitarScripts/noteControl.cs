using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteControl : MonoBehaviour
{
    public Transform sucessBurst;
    public Transform failBurst;
    private bool pressable;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pressable && button != null && button.buttonDown)
        {
            Kill();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FailCollider")

        {
            Destroy(gameObject);
            Debug.Log("Fail!!!");
            Instantiate(failBurst, transform.position, failBurst.rotation);
            GM.totalScore -= 1;

        }
        else if (other.gameObject.CompareTag("Button"))
        {
            Debug.Log("hit");
            button = other.gameObject.GetComponent<Button>();
            pressable = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            pressable = false;
        }
    }

    private void Kill()
    {
        Destroy(gameObject);

        Instantiate(sucessBurst, transform.position, failBurst.rotation);
        GM.winStreak += 1;
        GM.totalScore += 10;
    }
}
