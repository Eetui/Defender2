using UnityEngine;

public interface IShootable
{
    void Shoot(Vector3 shootingPoint, Quaternion quaternion, Vector3 shellParticleEffectPos);
}