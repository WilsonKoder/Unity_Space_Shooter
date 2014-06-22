using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform mytransfrom;

	public float playerSpeed = 30f;

	//Variable to reference prefab. Prefab = Reusable game object.
	public GameObject Projectile;

	// Use this for initialization
	void Start () {
		mytransfrom = transform;
		//Spawn Point
		mytransfrom.position = new Vector3(-3f, -3f, -1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Make the player move when the horizontal axis is pressed. Keep it in real time using Time.deltaTime.
		transform.Translate (Vector3.right * playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
		//Make the player wrap
		//If the player is at x = 9, he should appear at -9, and vice versa.

		if(transform.position.x <= -11f) {
			transform.position = new Vector3(11f, transform.position.y, transform.position.z);
		}

		else if(transform.position.x >= 11f) {
			transform.position = new Vector3(-11f, transform.position.y, transform.position.z);
		}


		//If the player presses the spacebar, a laser will shoot out.

		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Fire projectile.
			//Instantiate the prefab object.
			Instantiate(Projectile,new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
		}
	}
}
