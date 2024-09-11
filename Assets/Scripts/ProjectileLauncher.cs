using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectPrefab;
    
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectPrefab, launchPoint.position, projectPrefab.transform.rotation);

        // flip projectile scale based on characters direction
        Vector3 origScale = projectile.transform.localScale;
        projectile.transform.localScale = new Vector3(origScale.x * transform.localScale.x > 0 ? 1 : -1,
            origScale.y, origScale.z);
    }
}
