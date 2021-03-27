using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    //public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public float zScenePos;

    public static float ZVelAdj = 1;

    public static string lvlCompStatus = "";

    public Transform bbNoPit;
    public Transform bbWPit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (zScenePos < 120)
        {
            Instantiate(bbNoPit, new Vector3(0, 0, zScenePos), bbNoPit.rotation);
            zScenePos += 4;
        }
        */

        timeTotal += Time.deltaTime;

        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }

        if (waittoload >2)
        {
            SceneManager.LoadScene("LevelComp");
        }
    }
}
