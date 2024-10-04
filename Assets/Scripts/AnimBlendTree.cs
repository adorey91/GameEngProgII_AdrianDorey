using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBlendTree : MonoBehaviour
{
    public GameObject character;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        character.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", PlayerLocomotionHandler.playerVelocity);
    }
}
