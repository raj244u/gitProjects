using UnityEngine;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour {

    private Transform m_currentAxeList;
    private float m_distance = 2f;
    private float m_height = 1;
    private float m_lookAtAroundAngle = 180;

    [SerializeField] private List<Transform> m_AxeLists;
    private int m_currentIndex;

	private void Start () {
        if(m_AxeLists.Count > 0)
        {
            m_currentIndex = 0;
            m_currentAxeList = m_AxeLists[m_currentIndex];
        }
	}

    private void SwitchAxeList(int step)
    {
        if(m_AxeLists.Count == 0) { return; }
        m_currentIndex+=step;
        if (m_currentIndex > m_AxeLists.Count-1) { m_currentIndex = 0; }
        if (m_currentIndex < 0) { m_currentIndex = m_AxeLists.Count - 1; }
        m_currentAxeList = m_AxeLists[m_currentIndex];
    }

    public void NextAxeList() { SwitchAxeList(1); }
    public void PreviousAxeList() { SwitchAxeList(-1); }

    private void Update () {
        if (m_AxeLists.Count == 0) { return; }
    }

    private void LateUpdate()
    {
        if(m_currentAxeList == null) { return; }

        float AxeListHeight = m_currentAxeList.position.y + m_height;
        float currentRotationAngle = m_lookAtAroundAngle;

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        Vector3 position = m_currentAxeList.position;
        position -= currentRotation * Vector3.forward * m_distance;
        position.y = AxeListHeight;

        transform.position = position;
        transform.LookAt(m_currentAxeList.position + new Vector3(0, m_height, 0));
    }
}
