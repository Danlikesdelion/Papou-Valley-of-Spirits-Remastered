using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    public bool timeToUpdateAnimationAndMove;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public SignalSender playerHealthSignal;
    public VectorValue startingPosition;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if(Input.GetButtonDown("Second Weapon") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(SecondAttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            timeToUpdateAnimationAndMove = true; 
        }
    }

    void FixedUpdate()
    {
        if (timeToUpdateAnimationAndMove)
        {
            UpdateAnimationAndMove();
            timeToUpdateAnimationAndMove = false;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }

    private IEnumerator SecondAttackCo()
    { 
        animator.SetBool("projectiling", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        animator.SetBool("projectiling", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
        

    }

    private void MakeArrow()
    {
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(temp, Vector3.zero);
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }



     
    void MoveCharacter()
    {
        change.Normalize();
            myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
        if(change.x == 0 && change.y == 0) 
        {
            myRigidbody.velocity = Vector2.zero;
        }

    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCoroutine(knockTime));
        }
        else
        {
            animator.SetBool("Die", true);

            //Die();

            GameOverManager.instance.OnPlayerDeath();
            this.gameObject.SetActive(false);
       
        }
    }

    

    private IEnumerator KnockCoroutine(float knockTime)
    {

        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }


}
