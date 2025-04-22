using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Right : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] int speed;

    public GameObject BombExplosionBird;
    // Start is called before the first frame update

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.right * speed;
    }
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        MainCamera.instance.ShakeCamExplosion();
        GameObject _Explosion = Instantiate(BombExplosionBird, transform.position, Quaternion.identity);
        AudioControll.current.PlayMusic(AudioControll.current.explosionBomb);
        GameControll.instance._bombHit++;
        Destroy(_Explosion, 1f);
        Destroy(gameObject, 1.5f);
    }

}
