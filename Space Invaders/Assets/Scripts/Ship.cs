using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public Transform bulletPrefab;

	private GUIText livesLabel;

	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			shoot ();
			Debug.Log("pew pew you're dead !");
		}
	}

	private void shoot()
	{
		Transform Bullet = Instantiate(bulletPrefab) as Transform;
		Bullet.rigidbody2D.velocity = new Vector2 (0, 30);
		Bullet.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
		}
	}
}
