using UnityEngine;
using System.Collections;

public class EnemySpawnerLevelTwo : MonoBehaviour 
{
	public GameObject[] LevelTwoEnemies;
	float maxSphereSpawnRateInSeconds = 5f;
	float maxCylinderSpawnRateInSeconds = 10f;
	float SphereCounter = 0f;
	float CylinderCounter = 0f;

	float maxSphereSpawns = 5f;
	float maxCylinderSpawns = 5f;
	float maxCubeSpawns = 0f;

	// Use this for initialization
	void Start () 
	{
		Invoke ("SpawnEnemySphere", maxSphereSpawnRateInSeconds);
		InvokeRepeating ("IncreaseSphereSpawnRate", 0f, 30f);

		Invoke ("SpawnEnemyCylinder", maxCylinderSpawnRateInSeconds);
		InvokeRepeating ("IncreaseCylinderSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (SphereCounter > maxSphereSpawns && CylinderCounter > maxCylinderSpawns) 
		{
			Invoke ("SpawnEnemyCube", 1f);
		}
	}

	void SpawnEnemySphere()
	{
		if (SphereCounter <= maxSphereSpawns) {
			var bounds = Globals.GetCameraBounds (gameObject);
			float minY = bounds.m_MinY;
			float maxY = bounds.m_MaxY;
			float maxX = bounds.m_MaxX;

			GameObject aSphere = (GameObject)Instantiate (LevelTwoEnemies [0]);
			aSphere.transform.position = new Vector2 (maxX, maxY - Random.Range(0, 3));


			ScheduleNextSphereSpawn ();
			SphereCounter++;
		} 
		else {
			return;
		}
	}

	void ScheduleNextSphereSpawn()
	{
		float spawnInNSeconds;
		if (maxSphereSpawnRateInSeconds > 1f) {
			// pick a number between 1 and maxVelesSpawnRatesInSeconds
			spawnInNSeconds = Random.Range (1f, maxSphereSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 1f;
		}

		Invoke ("SpawnEnemySphere", spawnInNSeconds);
	}

	//function to increase number of Veles Spawns
	void IncreaseSphereSpawnRate()
	{
		if (maxSphereSpawnRateInSeconds > 1f)
			maxSphereSpawnRateInSeconds-= 0.5f;

		if (maxSphereSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSphereSpawnRate");
	}


	// Spawns Enemy Norexan Ships
	void SpawnEnemyCylinder()
	{
		if (CylinderCounter <= maxCylinderSpawns) {
			var bounds = Globals.GetCameraBounds (gameObject);
			float minY = bounds.m_MinY;
			float maxY = bounds.m_MaxY;
			float maxX = bounds.m_MaxX;

			GameObject aCylinder = (GameObject)Instantiate (LevelTwoEnemies [1]);
			aCylinder.transform.position = new Vector2 (maxX, Random.Range(minY, maxY));

			ScheduleNextCylinderSpawn ();
			CylinderCounter++;
		} 
		else {
			return;
		}
	}

	void ScheduleNextCylinderSpawn()
	{
		float spawnInNSeconds;
		if (maxCylinderSpawnRateInSeconds > 1f) {
			// pick a number between 1 and maxVelesSpawnRatesInSeconds
			spawnInNSeconds = Random.Range (1f, maxCylinderSpawnRateInSeconds);
		} else {
			spawnInNSeconds = 1f;
		}

		Invoke ("SpawnEnemyCylinder", spawnInNSeconds);
	}

	//function to increase number of Veles Spawns
	void IncreaseCylinderSpawnRate()
	{
		if (maxCylinderSpawnRateInSeconds > 1f)
			maxCylinderSpawnRateInSeconds-= 0.5f;

		if (maxCylinderSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseCylinderSpawnRate");
	}

	void SpawnEnemyCube()
	{
		if (maxCubeSpawns < 1f)
		{
			var bounds = Globals.GetCameraBounds (gameObject);
			float maxY = bounds.m_MaxY;
			float minY = bounds.m_MinY;
			float maxX = bounds.m_MaxX;

			GameObject anCube = (GameObject)Instantiate (LevelTwoEnemies [2]);
			anCube.transform.position = new Vector2 (maxX, (maxY - minY)/3.0f);

			maxCubeSpawns++;
		}
		else
		{
			return;
		}
	}
}