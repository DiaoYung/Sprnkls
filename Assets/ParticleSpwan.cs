using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpwan : MonoBehaviour {

	public ParticleSystem particleSystem;
	private ParticleSystem.Particle[] particlesArray;
	public int seaResolution = 25;

	public Color[] colors;

	void Start() {


		Invoke ("PlayEffect", 1.5f);

//		particlesArray = new ParticleSystem.Particle[seaResolution];
//		particleSystem.maxParticles = seaResolution * seaResolution;
//		particleSystem.Emit(seaResolution * seaResolution);
//		particleSystem.GetParticles(particlesArray);
//		changeColor ();

	}

	void PlayEffect(){
		
		gameObject.GetComponent<ParticleSystem> ().Play ();

	}

//	void changeColor () {
//		for (int i = 0; i < seaResolution; i++) {
//			for (int j = 0; j < seaResolution; j++) {
//				int randomIndex = Random.Range (0, 5);
//				particlesArray [i * seaResolution + j].startColor = colors[randomIndex];
//			}
//		}
//	}


	// Update is called once per frame
//	void Update () {
//		
//	}
}
