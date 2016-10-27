/*****************************************************************************************************************************************************************************************************************************
 * File: Norexan.cs
 * Author: Austin Welborn
 * Date: 10/22/2016
 * Date Modified:
 * Description:  Child Class of EnemyBase for the Norexan enemy ship
 *
 */

using UnityEngine;
using System.Collections;

public class Norexan : EnemyBase {

	// Use this for initialization
	void Awake () {
		m_BaseMaxHealth = 15f;
		m_MoveSpeed = 2.0f;
		m_Name = "Norexan";
		m_points = 35f;

		if (m_SpriteRenderer == null) {
			m_SpriteRenderer = GetComponent<SpriteRenderer> ();
			var temp = Resources.Load ("SpriteRenderers/norexan_renderer", typeof(SpriteRenderer)) as SpriteRenderer;
			m_SpriteRenderer.sprite = temp.sprite;
			m_SpriteRenderer.enabled = true;
		}
	}

    void Update()
    {
        // Get the enemy current position
        Vector2 position = transform.position;

        //Compute the enemy new position
		position = new Vector2(position.x - m_MoveSpeed * Time.deltaTime, Mathf.Sin(Time.time)*Time.deltaTime*m_MoveSpeed + position.y);

        //Update the ship with new position
        transform.position = position;

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
