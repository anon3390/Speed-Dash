using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityStandardAssets.Vehicles.Car;
public class waitControl : MonoBehaviour
{
	private CarController m_CarController;
    // Start is called before the first frame update
    void Start()
    {
			m_CarController = GetComponent<CarController>();
	m_CarController.enabled=false;
        StartCoroutine (wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator wait()
    {
	yield return new WaitForSeconds(4);

	m_CarController.enabled=true;
    }
}
