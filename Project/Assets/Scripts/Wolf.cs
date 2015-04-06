using UnityEngine;
using System.Collections;

public class Wolf : MonoBehaviour {

	public LocationEnum.Location location;
	public Boat boat;
	public GameObject wolfSprite;

	public Vector3 nearside, neardock, farside, fardock;

	// Use this for initialization
	void Start () {
		location = LocationEnum.Location.NearDock;
		nearside = new Vector3 (-0.18f, -0.83f);
		farside = new Vector3 (-0.18f, 0.91f);
		neardock = new Vector3 (-3.43f, -2.85f);
		fardock = new Vector3 (-3.42f, 3.04f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("w")) {
			if(location == LocationEnum.Location.NearDock && boat.location == LocationEnum.Location.Nearside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Nearside;
				boat.cargo = Boat.Cargo.Wolf;
				wolfSprite.transform.position = nearside;
			}
			else if(location == LocationEnum.Location.FarDock && boat.location == LocationEnum.Location.Farside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Farside;
				boat.cargo = Boat.Cargo.Wolf;
				wolfSprite.transform.position = farside;
			}
			else if(location == LocationEnum.Location.Nearside) // Must be on boat
			{
				location = LocationEnum.Location.NearDock;
				boat.cargo = Boat.Cargo.Empty;
				wolfSprite.transform.position = neardock;
			}
			else if(location == LocationEnum.Location.Farside) // Must be on boat
			{
				location = LocationEnum.Location.FarDock;
				boat.cargo = Boat.Cargo.Empty;
				wolfSprite.transform.position = fardock;
			}
			else {} // Not able to move, so do nothing
		}
	}
}
