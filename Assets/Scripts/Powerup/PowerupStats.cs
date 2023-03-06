using UnityEngine;

namespace SpaceShooter
{
    public class PowerupStats : Powerup
    {
        public enum EffectType
        {
            AddAmmo,
            AddEnergy,
            AddScore,
            AddNumLives
        }

        [SerializeField] private EffectType m_EffectType;
        [SerializeField] private float m_Value;

        protected override void OnPickedUp(SpaceShip ship)
        {
            if (m_EffectType == EffectType.AddEnergy)
                ship.AddEnergy( (int) m_Value);

            if (m_EffectType == EffectType.AddAmmo)
                ship.AddAmmo( (int) m_Value);

            if (m_EffectType == EffectType.AddScore)
                Player.Instance.AddScore( (int) m_Value);

            if (m_EffectType == EffectType.AddNumLives)
                Player.Instance.AddNumLives( (int) m_Value);
        }
    }


}