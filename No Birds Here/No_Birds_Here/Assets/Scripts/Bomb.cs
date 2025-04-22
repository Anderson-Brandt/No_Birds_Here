using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float minforce = 10f;
    [SerializeField] private float maxForce = 40f;
    private Rigidbody2D rig;

    public GameObject BombExplosion;

    bool isExplosed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * Random.Range(minforce, maxForce), ForceMode2D.Impulse);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        MainCamera.instance.ShakeCamExplosion();
        GameObject _Explosion = Instantiate(BombExplosion, transform.position, Quaternion.identity);
        AudioControll.current.PlayMusic(AudioControll.current.explosionBomb);
        GameControll.instance._bombHit++;
        Destroy(_Explosion, 1f);
        Destroy(gameObject, 1.5f);
    }
   
}
