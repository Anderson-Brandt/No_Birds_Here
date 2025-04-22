using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Animator anim;

    public static MainCamera instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    public void ShakeCamAttack()
    {
        anim.SetTrigger("AttackShake");
    }

    public void ShakeCamExplosion()
    {
        anim.SetTrigger("ExplosionShake");
    }
}
