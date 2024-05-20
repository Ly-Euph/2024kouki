using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{

    [SerializeField] GameObject[] Enemy;


    GameObject duct;
    Vector3 ductPos;

    private int random;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        duct = GameObject.FindGameObjectWithTag("duct");
        ductPos = duct.transform.position;

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=1f)
        {
            random = Random.Range(1, 5);

            switch(random)
            {
                case 1:
                    Instantiate(Enemy[0], ductPos, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(Enemy[1], ductPos, Quaternion.identity);
                    break;

                case 3:
                    Instantiate(Enemy[2], ductPos, Quaternion.identity);
                    break;

                case 4:
                    Instantiate(Enemy[3], ductPos, Quaternion.identity);
                    break;

            }
                


            //Instantiate(Enemy1, ductPos, Quaternion.identity);
            timer = 0;
        }

    }
}
