using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
	public Transform invader1Prefab;
	public Transform invader2Prefab;
	public Transform invader3Prefab;

	public Transform activeInvader;

	private bool goingRight;

	public Transform[] invaders;
	// Use this for initialization
	void Start ()
	{
		invaders = new Transform[55];
		int index = 0;

		for (int x = 0; x < 11; x++) {
			for (int y = 1 ; y < 6; y++) {

				if ( y < 2 ) {
					activeInvader = invader3Prefab;
				}
				else if ((y > 1) && (y < 4)) {
					activeInvader = invader2Prefab;
				}
				else {
					activeInvader = invader1Prefab;
				}

				invaders[index] = Instantiate(activeInvader) as Transform;
				invaders[index].transform.position = new Vector3(((x * 4f) - 20), ((y * 4f) - 10), 1);

				invaders[index].transform.parent = transform;

				index++;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < invaders.Length; i++) {

			int x = 1;

			if(goingRight == true) {
				x = 1;
			}

			if(goingRight == false) {
				x = -1;
			}

			if (invaders[i] != null) {
				invaders[i].transform.Translate(4 * x * Time.deltaTime,0 ,0);
			}
		}
	}

	public void moveInvadersCloser (bool right)
	{
		goingRight = !right;
		Debug.Log (goingRight);

		for (int i = 0; i < invaders.Length; i++) {
			if (invaders[i] != null) {
				invaders[i].transform.Translate(0, -1, 0);
			}		
		}

	}

	public void destroyInvader (Transform invader)
	{
		for (int i = 0; i < invaders.Length; i++)
		{
			if (invaders[i] == invader)
			{
				Destroy(invader.gameObject);
				invaders[i] = null;
			}
		}
	}
}
