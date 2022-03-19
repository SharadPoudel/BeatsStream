using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GM : MonoBehaviour
{
    List<float> whichNote = new List<float>() { 1, 6, 3, 4, 2, 5, 2, 1, 2, 3, 5, 6, 4, 6, 5, 5, 1, 2, 4, 1, 1, 4, 5, 5 };
    public int noteMark = 0;
    public Transform noteObj;
    public string timerReset = "y";
    public float xPos;

    public static int winStreak = 0;
    public Transform fountainFW;
    public string fountainSpawnL = "n";
    public string fountainSpawnR = "n";

    public int choose2x = 0;

    public static float totalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((timerReset == "y")&& noteMark<22)
            {
            StartCoroutine(spawnNote());
            timerReset = "n";
            }

        else if ((winStreak == 5)&& (fountainSpawnL == "n"))
            {
                fountainSpawnL = "y";
                Instantiate(fountainFW, new Vector3(-4.40999985f, 0.170000002f, 0.629999995f), fountainFW.rotation);
                }
        else if ((winStreak == 10) && (fountainSpawnR == "n"))
            {
            fountainSpawnR = "y";
            Instantiate(fountainFW, new Vector3(4.40999985f, 0.170000002f, 0.629999995f), fountainFW.rotation);
            }
        }

    IEnumerator spawnNote()//corroutine
        {
        yield return new WaitForSeconds(1);
        if (whichNote[noteMark] == 1)
            {
            xPos = -1.5f;
            }
        else if (whichNote[noteMark] == 2)
            {
            xPos = -.75f;
            }
        else if (whichNote[noteMark] == 3)
            {
            xPos = 0f;
            }
        else if (whichNote[noteMark] == 4)
            {
            xPos = .75f;
            }
        
        else if (whichNote[noteMark] == 5)
            {
            xPos = 1.5f;
            }
        /* else if (whichNote[noteMark] == 6)
             {
             xPos = 1.45f;
             }*/
        noteMark += 1;
        timerReset = "y";
        Instantiate(noteObj, new Vector3(xPos, 0.99f, 2.57f), noteObj.rotation);

        }
    }
