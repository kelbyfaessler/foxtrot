/*****************************************************************************************************************************************************************************************************************************
 * File: Borg_Sphere.cs
 * Author: Austin Welborn
 * Date: 10/16/2016
 * Date Modified:
 * Description:  Child Class of EnemyBase for the Borg Sphere enemy ship
 *
 */

using UnityEngine;
using System.Collections;

public class Borg_Sphere : EnemyBase {

	// Use this for initialization
	void Awake () {
		m_BaseMaxHealth = 15f;
		m_MoveSpeed = 0.1f;
		m_Name = "Borg Sphere";
		m_points = 20f;

		if (m_SpriteRenderer == null) {
			m_SpriteRenderer = GetComponent<SpriteRenderer> ();
			var temp = Resources.Load ("SpriteRenderers/borg_sphere_renderer", typeof(SpriteRenderer)) as SpriteRenderer;
			m_SpriteRenderer.sprite = temp.sprite;
			m_SpriteRenderer.enabled = true;
		}
	}
}
