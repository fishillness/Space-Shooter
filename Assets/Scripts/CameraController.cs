using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Properties
    /// <summary>
    /// Link to the camera.
    /// ������ �� ������.
    /// </summary>
    [SerializeReference] private Camera m_Camera;
    /// <summary>
    /// Reference to the transform that the camera will follow.
    /// ������ �� ���������, �� ������� ����� ��������� ������.
    /// </summary>
    [SerializeReference] private Transform m_Target;
    /// <summary>
    /// Speed of linear interpolation.
    /// �������� �������� ������������.
    /// </summary>
    [SerializeReference] private float m_InterpolationLinear;
    /// <summary>
    /// Speed of angular interpolation.
    /// �������� ������� ������������.
    /// </summary>
    [SerializeReference] private float m_InterpolationAngular;
    /// <summary>
    /// Offset along the Z axis.
    /// �������� �� ��� Z.
    /// </summary>
    [SerializeReference] private float m_CameraZOffset;
    /// <summary>
    /// Offset in the direction of movement.
    /// �������� �� ����������� ��������.
    /// </summary>
    [SerializeReference] private float m_ForwardOffset;
    #endregion

    #region Unity Events
    private void FixedUpdate()
    {
        if (m_Target == null || m_Camera == null) return;

        Vector2 camPos = m_Camera.transform.position;
        Vector2 targetPos = m_Target.position + m_Target.transform.up * m_ForwardOffset; /////

        Vector2 newCamPos = Vector2.Lerp(camPos, targetPos, m_InterpolationLinear * Time.deltaTime);

        m_Camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, m_CameraZOffset);    
        
        if (m_InterpolationAngular > 0)
        {
            m_Camera.transform.rotation = Quaternion.Slerp(m_Camera.transform.rotation, 
                                                            m_Target.rotation, 
                                                            m_InterpolationAngular * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        m_Target = newTarget;
    }
    #endregion
}
