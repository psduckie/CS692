using UnityEngine;
using System.Collections;

public class Goat : MonoBehaviour {

	public LocationEnum.Location location;
	public Boat boat;
	public GameObject goatSprite;

	public Vector3 nearside, neardock, farside, fardock;

	// Use this for initialization
	void Start () {
		location = LocationEnum.Location.NearDock;
		nearside = new Vector3 (-0.17f, -0.74f);
		farside = new Vector3 (-0.17f, 1f);
		neardock = new Vector3 (-0.17f, -2.79f);
		fardock = new Vector3 (-0.17f, 3.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("g")) {
			if(location == LocationEnum.Location.NearDock && boat.location == LocationEnum.Location.Nearside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Nearside;
				boat.cargo = Boat.Cargo.Goat;
				goatSprite.transform.position = nearside;
			}
			else if(location == LocationEnum.Location.FarDock && boat.location == LocationEnum.Location.Farside && boat.cargo == Boat.Cargo.Empty)
			{
				location = LocationEnum.Location.Farside;
				boat.cargo = Boat.Cargo.Goat;
				goatSprite.transform.position = farside;
			}
			else if(location == LocationEnum.Location.Nearside) // Must be on boat
			{
				location = LocationEnum.Location.NearDock;
				boat.cargo = Boat.Cargo.Empty;
				goatSprite.transform.position = neardock;
			}
			else if(location == LocationEnum.Location.Farside) // Must be on boat
			{
				location = LocationEnum.Location.FarDock;
				boat.cargo = Boat.Cargo.Empty;
				goatSprite.transform.position = fardock;
			}
			else {} // Not able to move, so do nothing
		}
	}
}
