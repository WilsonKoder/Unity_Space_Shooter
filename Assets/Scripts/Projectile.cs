using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float projectileSpeed = 15.0f;
	public GameObject projectile;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Make the laser shoot out and go upwards.

		//GameObject = Laser = Shoot up
		transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);

		if (transform.position.y > 7)
		{
			DestroyObject (this.gameObject);
		}
	}
}
