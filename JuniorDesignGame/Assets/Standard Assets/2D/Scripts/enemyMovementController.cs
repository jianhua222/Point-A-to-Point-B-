using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {

	public float enemySpeed;
	Animator enemyAnimator;
    GameObject thisObject;

	//facing
	public GameObject enemyGraphic;
	bool canFlip = true;
	public bool goRight = true;
	float flipTime = 4f;
	float nextFlipChance = 0f;

	// attacking
	public float chargeTime;
	float startChargeTime;
	bool charging;
    public Vector2 velocity;
    float charge;

	Rigidbody2D ghostRB;


	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator> ();
		ghostRB = GetComponent<Rigidbody2D> ();
        thisObject = this.gameObject;
        charge = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (goRight)
        {
            ghostRB.MovePosition(ghostRB.position + velocity * Time.fixedDeltaTime * charge);
        }
        else
        {
            ghostRB.MovePosition((ghostRB.position - velocity * Time.fixedDeltaTime * charge));
        }
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), goRight ? new Vector2(1.5f, -1) : new Vector2(-1.5f, -1), Color.green);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y), goRight ? new Vector2(1, -1) : new Vector2(-1, -1),3);
        if (hit.collider == null)
        {
            Debug.Log("this worked");
            flipFacing();
        }

        if(transform.position.y < -15)
        {
            EnemySpawner.enemySpawner.enemyDied(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            flipFacing();
        }
        if(col.gameObject.tag == "Edge")
        {
            //Debug.Log("Hit an edge, gonna flip");
            flipFacing();
        }
    }

	public void flipFacing() {
		if (!canFlip)
			return;
		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;
		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
		goRight = !goRight;
        ChargeReset();
    }

    public bool GoRight()
    {
        return goRight;
    }

    public void setRight(bool a)
    {
        if((a == false && goRight == true) || (a == true && goRight == false))
        {
            flipFacing();
        }
    }

    public void Charge(float a)
    {
        charge *= a;
    }

    public void ChargeReset()
    {
        charge = 1;
    }
}

