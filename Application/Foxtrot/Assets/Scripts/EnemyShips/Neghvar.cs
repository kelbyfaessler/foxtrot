/*****************************************************************************************************************************************************************************************************************************
 * File: Neghvar.cs
 * Author: Austin Welborn
 * Date: 11/27/2016
 * Date Modified: 12/1/2016 
 * Description:  Child Class of EnemyBase for the Negh'var boss enemy ship
 *
 */

using UnityEngine;
using System.Collections;

public class Neghvar : EnemyBase {
  // Use this for initialization
	float Ship_position;
  void Awake () {
		m_BaseMaxHealth = 4000f;
		m_MoveSpeed = 4.5f;
		m_Name = "Negh'var";
		m_points = 2000f;
		position = 1f;

		if (m_SpriteRenderer == null) {
			m_SpriteRenderer = GetComponent<SpriteRenderer> ();
			var temp = Resources.Load ("SpriteRenderers/neghvar_renderer", typeof(SpriteRenderer)) as SpriteRenderer;
			m_SpriteRenderer.sprite = temp.sprite;
			m_SpriteRenderer.enabled = true;
		}
	}
    
  void Update()
  {

		UpdateHealth();

		var bounds = Globals.GetCameraBounds (gameObject);
		float maxX = bounds.m_MaxX;;
		float maxY = bounds.m_MaxY;
		float minY = bounds.m_MinY

    // Get the enemy current position
    	Vector2 position = transform.position;
		if (position.x > (maxX - m_SpriteWidthFromCenter * 2))
    {
      //Compute the en+emy new position
      position = new Vector2(position.x - m_MoveSpeed * Time.deltaTime, position.y);

      //Update the ship with new position
      transform.position = position;
    }
    else
    {
			switch (Ship_position)
			{
			case 2:
				position = new Vector2(position.x + m_MoveSpeed * Time.deltaTime, position.y - m_MoveSpeed * Time.deltaTime);
			case 3:
				position = new Vector2(position.x - m_MoveSpeed * Time.deltaTime, position.y - m_MoveSpeed * Time.deltaTime);
			case 4:
				position = new Vector2(position.x + m_MoveSpeed * Time.deltaTime, position.y + m_MoveSpeed * Time.deltaTime);
			default:
				position = new Vector2(position.x - m_MoveSpeed * Time.deltaTime, position.y + m_MoveSpeed * Time.deltaTime);
			}
      transform.position = position;
    }

    // Determine whether to fire laser
    int rand = Random.Range(0, 60);
    if (rand == 2)
    {
      Vector3 laserPosition = transform.position;
      laserPosition.x = laserPosition.x - (m_SpriteWidthFromCenter * 2);
      Instantiate(Resources.Load("Prefabs\\Weapons\\LaserEnemy"), laserPosition, Quaternion.identity);
    }
  }
}
