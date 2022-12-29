using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private float speed;
    public GameObject cam;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollSpeed;

    private Rigidbody2D rig;
    private PlayerItens playerItens;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private Vector2 _direction;

    [HideInInspector] public int handlingObj;


    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItens>();
        initialSpeed = speed;
    }
    private void Update()
    {
            if (!isPaused)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    handlingObj = 0;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    handlingObj = 1;
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    handlingObj = 2;
                }

                OnInput();

                OnRun();

                OnRolling();

                OnCutting();

                OnDigging();

                OnWatering();
            } 
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }

    #region Movement

    void OnCutting()
    {
        if (handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDigging()
    {
        if(handlingObj == 1) { 
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (handlingObj == 2 )
        {
            if (Input.GetMouseButtonDown(0) && playerItens.CurrentWater > 0)
            {
                
                isWatering = true;
                speed = 0f;
            }
            if (Input.GetMouseButtonUp(0) ||  playerItens.CurrentWater <= 0)
            {
                isWatering = false;
                speed = initialSpeed;
            }

            if (isWatering)
            {
                playerItens.CurrentWater -= 0.02f;
            }
        }
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = rollSpeed;
            _isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }
    #endregion
}
