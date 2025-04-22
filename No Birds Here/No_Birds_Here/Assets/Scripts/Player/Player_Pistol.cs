using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pistol : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        AudioControll.current.PlayMusic(AudioControll.current.pistolTransition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            AudioControll.current.PlayMusic(AudioControll.current.pistolFire);
            MainCamera.instance.ShakeCamAttack();
        }   
    }


}
