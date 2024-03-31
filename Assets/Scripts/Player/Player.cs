using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Speed setup")]
    public Rigidbody2D myRigidBody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float SpeedRun;
    public float forceJump = 5;


    [Header("Animation setup")]
    public float JumpScaleY = 1.5f;
    public float JumpScaleX = 0.8f;
    public float playerSwipeDuration = .1f;



    [Header("Animation Player")]
    public string boolRun = "RunBool";
    public Animator animator;
    public float duration;
    public string triggerDeath = "Death";



    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMovement();

    }

     [SerializeField] private HealthBase _healthBase;

    private void Awake()
    {
        if(_healthBase != null)
        {
            _healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = SpeedRun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, playerSwipeDuration);
            }

            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);

        }


        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity += friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity -= friction;

        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        myRigidBody.velocity = Vector2.up * forceJump;
        myRigidBody.transform.localScale = Vector2.one;
        DOTween.Kill(myRigidBody.transform);
        HandleScaleJump();

        }



    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(JumpScaleY, duration).SetLoops(2, LoopType.Yoyo);
        myRigidBody.transform.DOScaleY(JumpScaleX, duration).SetLoops(2, LoopType.Yoyo);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

