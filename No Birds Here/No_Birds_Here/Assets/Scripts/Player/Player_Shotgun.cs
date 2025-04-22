using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shotgun : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {  
        anim = GetComponent<Animator>();
        AudioControll.current.PlayMusic(AudioControll.current.shotgunTransition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            AudioControll.current.PlayMusic(AudioControll.current.shotgunFire);
            MainCamera.instance.ShakeCamAttack();
        }    
        
    }


}
