using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	public enum Cargo {Wolf, Goat, Carrots, Empty};

	public LocationEnum.Location location;
	public Cargo cargo;
	public Wolf wolf;
	public Goat goat;
	public Carrots carrots;
	public GameObject boatSprite;
	private bool depart;
	public Vector3 nearside, farside;
	
	// Use this for initialization
	void Start () {
		location = LocationEnum.Location.Nearside;
		cargo = Cargo.Empty;
		nearside = new Vector3 (-0.88f, -0.97f);
		farside = new Vector3 (-0.88f, 0.77f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) {
			if(location == LocationEnum.Location.Nearside)
			{
				switch(cargo)
				{
				case Cargo.Wolf:
					if(goat.location == carrots.location)
						depart = false; // Don't depart, as the goat will eat the carrots
					else
					{
						wolf.location = LocationEnum.Location.Farside;
						wolf.wolfSprite.transform.position = wolf.farside;
						depart = true;
					}
					break;
				case Cargo.Goat:
					// Always depart
					goat.location = LocationEnum.Location.Farside;
					goat.goatSprite.transform.position = goat.farside;
					depart = true;
					break;
				case Cargo.Carrots:
					if(goat.location == wolf.location)
						depart = false; // Don't depart, as the wolf will eat the goat
					else
					{
						carrots.location = LocationEnum.Location.Farside;
						carrots.carrotsSprite.transform.position = carrots.farside;
						depart = true;
					}
					break;
				default: // It's empty
					if(wolf.location == goat.location)
						depart = false;
					else if(goat.location == carrots.location)
						depart = false;
					else
						depart = true;
					break;
				}

				if(depart)
				{
					location = LocationEnum.Location.Farside;
					boatSprite.transform.position = farside;
				}
			}
		}
		if (Input.GetKeyDown ("down")) {
			if(location == LocationEnum.Location.Farside)
			{
				switch(cargo)
				{
				case Cargo.Wolf:
					if(goat.location == carrots.location)
						depart = false; // Don't depart, as the goat will eat the carrots
					else
					{
						wolf.location = LocationEnum.Location.Nearside;
						wolf.wolfSprite.transform.position = wolf.nearside;
						depart = true;
					}
					break;
				case Cargo.Goat:
					// Always depart
					goat.location = LocationEnum.Location.Nearside;
					goat.goatSprite.transform.position = goat.nearside;
					depart = true;
					break;
				case Cargo.Carrots:
					if(goat.location == wolf.location)
						depart = false; // Don't depart, as the wolf will eat the goat
					else
					{
						carrots.location = LocationEnum.Location.Nearside;
						carrots.carrotsSprite.transform.position = carrots.nearside;
						depart = true;
					}
					break;
				default: // It's empty
					if(wolf.location == goat.location)
						depart = false;
					else if(goat.location == carrots.location)
						depart = false;
					else
						depart = true;
					break;
				}
				
				if(depart)
				{
					location = LocationEnum.Location.Nearside;
					boatSprite.transform.position = nearside;
				}
			}
		}
	}
}
