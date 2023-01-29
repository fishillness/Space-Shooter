using UnityEngine;

namespace SpaceShooter
{

    public class LevelBoundary : SingletonBase<LevelBoundary>
    {
        /*
        public static LevelBoundary Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("LevelBoundary already exists in the scene.");
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        */

        #region Properties
        /// <summary>
        /// Radius of the world.
        /// Радиус мира.
        /// </summary>
        [SerializeField] private float m_Radius;
        public float Radius => m_Radius;

        /// <summary>
        /// Restriction mode.
        /// Режим ограничения.
        /// </summary>
        public enum Mode
        {
            Limit,
            Teleport
        }

        /// <summary>
        /// Actual restriction mode.
        /// Актуальный режим ограничения.
        /// </summary>
        [SerializeField] private Mode m_LinitMode;
        public Mode LimitMode => m_LinitMode;
        #endregion

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, m_Radius);
        }
#endif

    }
}
