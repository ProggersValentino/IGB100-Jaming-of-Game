using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lineOfSight : MonoBehaviour
{
    [SerializeField] private LineRenderer thyLine;
    [SerializeField] private int lineSegments;

    [SerializeField, Min(1)] float timeOfFlight;

    public void showLOS(Vector3 startPoint, Vector3 startVelocity)
    {
        float timeStep = timeOfFlight / lineSegments;

        Vector3[] lineRendererPoints = calculateLOS(startPoint, startVelocity, timeStep);

        thyLine.positionCount = lineSegments;
        thyLine.SetPositions(lineRendererPoints);
    }

    Vector3[] calculateLOS(Vector3 startPoint, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];

        lineRendererPoints[0] = startPoint;

        for (int i = 1; i < lineSegments; i++)
        {
            float timeOffSet = timeStep * i;

            Vector3 mainCal = startVelocity * timeOffSet;
            Vector3 newPos = startPoint + mainCal;
            lineRendererPoints[i] = newPos;
        }

        return lineRendererPoints;
    }
     
}
