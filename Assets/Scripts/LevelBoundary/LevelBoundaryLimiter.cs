using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Position limiter. Works in conjunction with the LEvelBoundary script, if available. 
    /// Add to the object to be constrained.
    /// Ограничитель позиции. Работает в связке со скриптом LevelBoundary, если он есть. 
    /// Добавлять на объект, которйы надо ограничить.
    /// </summary>
    public class LevelBoundaryLimiter : MonoBehaviour
    {


        private void Update()
        {
            if (LevelBoundary.Instance == null)
                return;
            var levelBoundary = LevelBoundary.Instance;
            var radius = levelBoundary.Radius;

            if (transform.position.magnitude > radius)
            {
                if (levelBoundary.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * radius;
                }

                if (levelBoundary.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -transform.position.normalized * radius;
                }
            }

        }
    }
}