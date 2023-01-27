using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        #region Properties
        public static string IgnoreTag = "WorldBoundary";

        [SerializeField] private float m_VelocityDamageModifier;
        [SerializeField] private float m_DamageConstant;
        #endregion

        #region Unity Events
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == IgnoreTag) return;

            var destructable = transform.root.GetComponent<Destructible>();

            if (destructable != null)
            {
                destructable.ApplyDamage((int)m_DamageConstant + 
                                        (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }
        #endregion
    }
}

