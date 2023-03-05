using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class LogDraw_PointToPoint : MonoBehaviour
    {
        public Transform [] m_points;
        public Color m_color= Color.red;

        public void Draw(float timeInSeconds) {
            if (m_points.Length < 2)
                return;
            for (int i = 0; i < m_points.Length-1; i++)
            {
                if(m_points[i]!=null &&  m_points[i + 1] != null)
                Debug.DrawLine(m_points[i].position, m_points[i + 1].position, m_color, timeInSeconds);
            }

        }
        public void Reset()
        {
            m_points = new Transform[] { this.transform, null };   
        }
        private void OnValidate()
        {
            Draw(1);
        }

        [ContextMenu("Display 120 seconds")]
        public void DisplayFor_120Seconds() => Draw(120);
        [ContextMenu("Display 30 seconds")]
        public void DisplayFor_30Seconds() => Draw(30);
        [ContextMenu("Display 5 seconds")]
        public void DisplayFor_5Seconds() => Draw(5);

    }
    
}
