using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEm : MonoBehaviour
{
    [SerializeField]Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("idle");
    }
}
