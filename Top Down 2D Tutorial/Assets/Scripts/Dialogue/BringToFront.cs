using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will bring the dialogue to the front of the screen.
// Because of its width, it will prevent us changing anything underneeth by mistake.
// Because of its colour (light grey), it will dim the screen underneeth.

public class BringToFront : MonoBehaviour {

	void OnEnable(){
		// This will make the dialouge the last child in the hirarchy for its layer and therefore, 
		// it will draw last and on top.
		transform.SetAsLastSibling();
	}
}
