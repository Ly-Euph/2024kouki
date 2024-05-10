using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hide : MonoBehaviour
{

    Transform tr;


    SkinnedMeshRenderer skin;


    GameObject duct;
    Vector3 ductPos;


    private bool camScan;
    private float scanTime;

    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();

        skin = GetComponentInChildren<SkinnedMeshRenderer>();

        duct = GameObject.FindGameObjectWithTag("duct");
        ductPos = duct.transform.position;

        tr.position = ductPos;
        skin.enabled = false;


        camScan = false;
        scanTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            camScan = true;
        }

        EnemyMove();


        if (camScan == true)
        {
            CamScan();
            scanTime += 1 / 60f;
        }
    }

    void EnemyMove()
    {
        
    }




    void CamScan()
    {
        Debug.Log("スキャン中");

        skin.enabled = true;

        if(scanTime>=4)
        {
            scanTime = 0;
            skin.enabled = false;
            camScan = false;
        }
    }
}
