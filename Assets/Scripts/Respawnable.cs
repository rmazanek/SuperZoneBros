using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
  [SerializeField] Transform lastSpawn;
  [SerializeField] int deathZoneLayerNumber = 6;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.layer == deathZoneLayerNumber)
    {
      Respawn();
    }
  }
  public void SetSpawn(Transform transform)
  {
    lastSpawn = transform;
  }
  private void Respawn()
  {
    Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
      rb.velocity = new Vector2(0f, 0f);
      rb.rotation = 0f;
    }
    gameObject.transform.position = lastSpawn.position;
  }
}
