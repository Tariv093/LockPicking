using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
public class LockpickScript : MonoBehaviour
{

    PlayerInput pInput;
    Vector2 m_move;
    public int difficulty, skill, lockHit, lockDur;
    public List<Vector2> locks;
    public TMP_Text lockText, timerText;
    public Slider skillSlider;
    public Shake shaker;
    float timer;
    bool gameStart, inProgress;
    public List<Vector2> possibleLocks;
    // Start is called before the first frame update

    private void Awake()
    {

        //;
        //for (int i = 0; i < lock.)
    }

    void Start()
    {
        timer = 10;
        lockHit = lockDur;
    }
    public void AdjustSkillLevel()
    {
        skill = (int)skillSlider.value;
    }
    // Update is called once per frame
    void Update()
    {
        if (inProgress == true && locks.Count == 0) // check for game won;
        {
            Debug.Log("gameover");
            timerText.text = "Unlocked!";
            gameStart = false;
            inProgress = false;

        }
        if (gameStart == true)
        {
            BeginPlay();
        }
        if (timer <= 0)
        {
            timerText.text = "Time's up!";
            gameStart = false;
            inProgress = false;
        }
      
    }

    private void BeginPlay()
    {
        if (inProgress == false)
        {
            timer = 10;
            locks = new List<Vector2>(difficulty);
            for (int i = 0; i < difficulty; i++)
            {

                locks.Add(possibleLocks[Random.Range(0, possibleLocks.Count)]);
            }
            inProgress = true;
        }

        DisplayLockText();
        
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        transform.position = m_move;
    }

    private void DisplayLockText()
    {
        //long ifstatement fun
        if (locks[0] == new Vector2(0, 1)) lockText.text = "Up";
        if (locks[0] == new Vector2(0, -1)) lockText.text = "Down";
        if (locks[0] == new Vector2(1, 0)) lockText.text = "Right";
        if (locks[0] == new Vector2(-1, 0)) lockText.text = "Left";
        if (locks[0] == new Vector2(0.707107f, 0.707107f)) lockText.text = "Up-Right";
        if (locks[0] == new Vector2(0.707107f, -0.707107f)) lockText.text = "Down-Right";
        if (locks[0] == new Vector2(-0.707107f, 0.707107f)) lockText.text = "Up-Left";
        if (locks[0] == new Vector2(-0.707107f, -0.707107f)) lockText.text = "Down-Left";
    }

    public void OnMove(InputValue value)
    {
        m_move = value.Get<Vector2>();
    }
    public void OnHit(InputValue value)
    {
        if (gameStart == false) return;
        if (m_move == locks[0])
        {
            lockHit -= skill;
            
            Debug.Log("click!");
            if (lockHit <= 0)
            {
                shaker.CameraShake();
                Debug.Log("clank!!");
                locks.Remove(locks[0]);
                lockHit = lockDur;
            }
        }
    }

    public void OnClick(int button)
    {
        switch (button)
        {
            case 0:
                gameStart = true;
                break;

            case 1:
                difficulty = 6;
                break;

            case 2:
                difficulty = 8;
                break;

            case 3:
                difficulty = 12;
                break;
        }
    }
}
