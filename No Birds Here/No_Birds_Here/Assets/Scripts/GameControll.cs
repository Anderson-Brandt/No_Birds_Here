using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Animations;
public class GameControll : MonoBehaviour
{
    public static GameControll instance;

    public GameObject PlayerPunch;
    public GameObject PlayerPistol;
    public GameObject PlayerShotgun;

    public GameObject BombHit_1;
    public GameObject BombHit_2;
    public GameObject BombHit_3;

    public GameObject GameOver;

    public int _birdPoints;
    [SerializeField] int _birdRecordPoints;

    public int _bombHit;

    [SerializeField] TextMeshProUGUI points;
    [SerializeField] TextMeshProUGUI recordPoints;

    private int pointsToPistol = 25;
    private int pointsToShotgun = 50;

    [SerializeField] private Button ReloadButton;

    // Start is called before the first frame update

    private void Awake()
    {
        ReloadButton.onClick.AddListener(OnButtonReloadClick);
    }
    void Start()
    {
        instance = this; 
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("Points", _birdRecordPoints) >= 0)
        {
            _birdRecordPoints = PlayerPrefs.GetInt("Points", _birdRecordPoints);
            recordPoints.text = _birdRecordPoints.ToString();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = _birdPoints.ToString();

        if (_birdPoints >= pointsToPistol)
        {
            PistolTransition();
        }

        if(_birdPoints >= pointsToShotgun)
        {  
            ShotgunTransition();
        }

        if (_bombHit == 1)
        {
            BombHit_1.SetActive(true);
        }
        if(_bombHit == 2)
        {
            BombHit_2.SetActive(true);
        }
        if(_bombHit == 3)
        {
            BombHit_3.SetActive(true);
            StartCoroutine(GameOverPopUp());
        }

        if (_birdPoints >= PlayerPrefs.GetInt("Points", _birdRecordPoints))
        {
            _birdRecordPoints = _birdPoints;
            recordPoints.text = _birdRecordPoints.ToString();
            PlayerPrefs.SetInt("Points", _birdRecordPoints);
        }
    }

        void PistolTransition()
    {
        PlayerPunch.SetActive(false);
        PlayerPistol.SetActive(true);
        
    }

        void ShotgunTransition()
    {
        PlayerPistol.SetActive(false);
        PlayerShotgun.SetActive(true);
        
    }

    IEnumerator GameOverPopUp() {

        GameOver.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0;

    }

    private void OnButtonReloadClick()
    {
        SceneManager.LoadScene(0);
    }
}
