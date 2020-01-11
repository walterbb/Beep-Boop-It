using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyDisk : MonoBehaviour
{
	public float speed;
	public float direction;

	Rigidbody2D rb;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2(speed * direction, 0f), ForceMode2D.Impulse);

		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(scale.x * direction, scale.y, 1f);
	}

    void Update()
    {

	}
}
