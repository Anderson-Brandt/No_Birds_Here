using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovmentDown : MonoBehaviour
{
    public static BirdMovmentDown instance;

    private Rigidbody2D rig;

    public float speed;
    Vector3 target;

    float activeTime = 10;
    Animator anim;
    SpriteRenderer spriteRenderer;
    bool isDead;
    bool isStartFalling;

    GameObject Player;

    public int birdPoints;

    public Collider2D birdColl;

    public GameObject BirdFeather;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, 40f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            // transform.LookAt(Player.transform);

            if (Vector3.Distance(transform.position, target) > 0)
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            else
            {
                if (transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 15)
                {
                    Destroy(gameObject);
                }

                SetTarget();
            }

                if(activeTime > 0)
                    activeTime -= Time.deltaTime;

                UpdateSprite();
            
        }

        else
        {
            if (isStartFalling)
                speed = 0f;
                rig.gravityScale = 10;
                
                Destroy(gameObject, 2f);
                
        }
    }

    public void TimeUp()
    {
        speed *= 2;
        target = transform.position + new Vector3(0, 20, 0);
    }

    private void OnMouseDown()
    {
        if (!isDead)
            StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        isDead = true;
        birdColl.enabled = false;
        AudioControll.current.PlayMusic(AudioControll.current.birdHit);
        anim.SetTrigger("Die");
        GameObject _BirdDead = Instantiate(BirdFeather, transform.position, Quaternion.identity);
        GameControll.instance._birdPoints++;
        yield return new WaitForSeconds(0.2f);
        isStartFalling = true;
        yield return new WaitForSeconds(1f);
        Destroy(_BirdDead);
    }

    public void UpdateSprite()
    {
        if (transform.position.x - target.x < 0)
        {
            transform.localScale = new Vector3(-0.23f, 0.23f, 0.23f);
        }
        else
        {
            transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SetTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target);
    }

    public void SetTarget()
    {
        if (activeTime > 0)
        {
            target = target + new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
            if (target.x > 20)
                target.x = 20;
            if (target.x < -20)
                target.x = -20;
            if (target.y > 20)
                target.y = 20;
            if (target.y < -20)
                target.y = -20;
        }
    }
}
