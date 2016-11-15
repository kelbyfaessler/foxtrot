/*****************************************************************************************************************************************************************************************************************************
 * File: DDeridex.cs
 * Author: Austin Welborn
 * Date: 10/23/2016
 * Date Modified: 10/24/2016
 * Description:  Child Class of EnemyBase for the D'Deridex boss enemy ship
 *
 */

using UnityEngine;
using System.Collections;

public class DDeridex : EnemyBase {
  // Use this for initialization
  void Awake () {
		m_BaseMaxHealth = 400f;
		m_MoveSpeed = 4.0f;
		m_Name = "D'Deridex";
		m_points = 1000f;

		if (m_SpriteRenderer == null) {
			m_SpriteRenderer = GetComponent<SpriteRenderer> ();
			var temp = Resources.Load ("SpriteRenderers/dderidex_renderer", typeof(SpriteRenderer)) as SpriteRenderer;
			m_SpriteRenderer.sprite = temp.sprite;
			m_SpriteRenderer.enabled = true;
		}
	}
    
  void Update()
  {
    // Get the enemy current position
    Vector2 position = transform.position;
    if (position.x > 8)
    {
      //Compute the enemy new position
      position = new Vector2(position.x - m_MoveSpeed * Time.deltaTime, position.y);

      //Update the ship with new position
      transform.position = position;
    }
    else
    {
	    position = new Vector2 (position.x, 1.5f*Mathf.Sin (Time.time) * Time.deltaTime * m_MoveSpeed + position.y);
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

    // Find the left-most edge of the screen. If the ship is to the left of it, destroy it.
    var bounds = Globals.GetCameraBounds(gameObject);
    float minX = bounds.m_MinX;

    var pos = transform.position;
    if (pos.x < minX)
    {
      Destroy(gameObject);
      return;
    }
  }
}
