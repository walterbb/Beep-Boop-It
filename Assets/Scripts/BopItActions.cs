using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopItActions : MonoBehaviour
{
	public List<System.Action> actions = new List<System.Action>();

	Movement movement;

	public FloppyDisk floppyDisk;

	public Transform parent;
	public Transform projectilePoint;
	public float FloppyDiskCooldown = 1f;

    void Start()
    {
		movement = GetComponent<Movement>();

		actions.Add(Jump);
		actions.Add(FloppyDisk);
    }

	void Jump()
	{
		if (movement.grounded)
		{
			Vector2 jumpForce = new Vector2(0f, movement.jump);
			movement.rb.AddForce(jumpForce, ForceMode2D.Impulse);
		}
		movement.timeSinceLastBop = 0f;
	}

	void FloppyDisk()
	{
		if(movement.timeSinceLastBop >= FloppyDiskCooldown)
		{
			FloppyDisk spawn = Instantiate(floppyDisk, parent);
			spawn.transform.position = projectilePoint.position;
			spawn.direction = movement.direction;
			movement.timeSinceLastBop = 0f;
		}
	}
}
