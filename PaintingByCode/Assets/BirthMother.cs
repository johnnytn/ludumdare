using UnityEngine;
using System.Collections;

public class BirthMother : MonoBehaviour {

	[SerializeField] private float weaponCooldown = 10.5f ;
	private float lastShootTime = float.MaxValue;

	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (lastShootTime > weaponCooldown) {
			lastShootTime = 0.0f*Time.deltaTime;
			CmdCreate();
		}
		//StartCoroutine(CreateAfterDelay (5f));
		lastShootTime += (5.0f*Time.deltaTime);
	
	}

	protected IEnumerator CreateAfterDelay(float waitDelay){
		yield return new WaitForSeconds(waitDelay); // wait 1 seconds
		GameObject newObj = Instantiate (prefab);
		prefab.transform.position = transform.position;
	}

	private void CmdCreate(){
		GameObject newObj = Instantiate (prefab);
		prefab.transform.position = transform.position;
	}
}
