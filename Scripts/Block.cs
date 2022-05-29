using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    public event UnityAction<Block> BulletHit;
    private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _destroyEffect;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColour(Color color)
    {
        _meshRenderer.material.color = color;
    }

  public void Break()
  {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, Quaternion.identity).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
  }
}
