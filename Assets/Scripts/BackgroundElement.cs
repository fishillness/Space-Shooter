using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundElement : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// The strength of the parallax effect.
        /// ���� �������� �������.
        /// </summary>
        [Range(0.0f, 4.0f)]
        [SerializeField] private float m_ParallaxPower;
        /// <summary>
        /// Texture Scale
        /// ������� ��������
        /// </summary>
        [SerializeField] private float m_TextureScale;
        /// <summary>
        /// Link to material
        /// ������ �� ��������
        /// </summary>
        private Material m_QuadMaterial;
        /// <summary>
        /// Initial offset point
        /// ����������� ����� ������
        /// </summary>
        private Vector2 m_InitialOffset;
        #endregion

        #region Unity Events

        private void Start()
        {
            m_QuadMaterial = GetComponent<MeshRenderer>().material;
            //�������� ��������� ����� � ��������� ��������� ����������
            m_InitialOffset = UnityEngine.Random.insideUnitCircle;
            m_QuadMaterial.mainTextureScale = Vector2.one * m_TextureScale;
        }

        private void Update()
        {
            Vector2 offset = m_InitialOffset;

            offset.x += transform.position.x / transform.localScale.x / m_ParallaxPower;
            offset.y += transform.position.y / transform.localScale.y / m_ParallaxPower;

            m_QuadMaterial.mainTextureOffset = offset;
        }

        #endregion
    }

}
