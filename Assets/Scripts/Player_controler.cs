using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    public float playerMovementSpeed = 1.0f;
    public float arrowMinPosition = -0.25f;
    public float arrowMaxPosition = 0.25f;
    public Transform throwingArrow;
    public Transform ballSpawnPoint;
    public float throwforce = 5.0f;
    public Animator throwingArrowAnim;

    public Rigidbody[] balls;


    private float horizontalInput;
    private Vector3 ballOffset;
    private bool wasBallThrown;
    private Rigidbody selectedBall;
    
    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;
       
        StartThrow();
    }
    private void StartThrow()
    {
        throwingArrowAnim.SetBool("Aiming", true);
        wasBallThrown = false;

        int randomNumber = GetRandomNumber(0,balls.Length);
        selectedBall = Instantiate(balls[randomNumber],ballSpawnPoint.position,Quaternion.identity);

    }

    private int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    // Update is called once per frame
    void Update()
    { 
        moveArrowWithConstrants();
        TryThrowBall();
    }
    
    private void MoveArrowWithoutConstraints()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        throwingArrow.position += throwingArrow.transform.right * horizontalInput * playerMovementSpeed * Time.deltaTime;
    }

    private void moveArrowWithConstrants()
    {
        if (!wasBallThrown)
        {
            float moveposition = Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime;
            throwingArrow.position = new Vector3(
                Mathf.Clamp(throwingArrow.position.x + moveposition, arrowMinPosition, arrowMaxPosition),
                throwingArrow.position.y,
                throwingArrow.position.z
                );

            selectedBall.position = throwingArrow.position + ballOffset;

            
        }


 
        

   
    }

    private void TryThrowBall()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !wasBallThrown)
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwforce, ForceMode.Impulse);
            throwingArrowAnim.SetBool("Aiming", false);
        }


    }

}

