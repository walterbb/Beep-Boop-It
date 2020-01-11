using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed;
	public float jump;

	public bool grounded;
	public float direction;

	List<Collision2D> collisions = new List<Collision2D>();

	public Rigidbody2D rb;

	BopItActions bopItActions;
	public int bopIndex;

	public float timeSinceLastBop;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		bopItActions = GetComponent<BopItActions>();

		direction = 1;
		bopIndex = 0;
		timeSinceLastBop = 0f;
    }

	void Move()
	{
		float movement = Input.GetAxis("Horizontal") * speed;
		rb.velocity = new Vector2(movement, rb.velocity.y);

		// Check if movement is a different direction than before
		if (Sign(movement) != 0f && Mathf.Sign(movement) != direction)
		{
			// Turn around and update direction
			Vector3 scale = transform.localScale;
			transform.localScale = new Vector3(scale.x * -1, scale.y, 1f);
			direction *= -1;
		}
	}

	void Update()
	{
		timeSinceLastBop += Time.deltaTime;

		Move();

		BopIt();
	}

	void BopIt()
	{
		if(Input.GetButtonDown("Bop"))
		{
			Debug.Log("Bopped");
			bopItActions.actions[bopIndex]();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		collisions.Add(collision);
		if(collision.gameObject.CompareTag("Ground"))
		{
			grounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		collisions.Remove(collision);
		if (collision.gameObject.CompareTag("Ground"))
		{
			grounded = false;
		}
	}

	float Sign(float a)
	{
		return a == 0f ? 0 : (a > 0 ? 1 : -1);
	}
}
