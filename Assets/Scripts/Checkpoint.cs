using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  [SerializeField] Color collectedColor;
  SpriteRenderer spriteRenderer;
  private void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    Respawnable respawnable = other.gameObject.GetComponent<Respawnable>();
    if (respawnable != null)
    {
      respawnable.SetSpawn(gameObject.transform);
      ChangeToCollectedColor();
    }
  }
  void ChangeToCollectedColor()
  {
    spriteRenderer.color = collectedColor;
  }
}
