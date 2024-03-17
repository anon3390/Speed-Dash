using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class CarControl : MonoBehaviour
{
	public CarController ascript;
	
    // Start is called before the first frame update
    void Start()
    {
    	ascript = GetComponent<CarController> ();
 	ascript.enabled = true;
	    
    }

}
