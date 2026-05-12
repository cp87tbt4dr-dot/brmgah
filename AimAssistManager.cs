using UnityEngine;

public class AimAssistManager : MonoBehaviour
{
    public bool aimAssistEnabled = false;
    public float strength = 0.2f;

    public GameObject aimAssistUI; // القائمة

    void Update()
    {
        if (!aimAssistEnabled) return;

        // مثال بسيط: سحب خفيف للكروس نحو الهدف
        GameObject target = FindClosestEnemy();
        if (target == null) return;

        Vector3 dir = (target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(dir),
            strength * Time.deltaTime
        );
    }

    GameObject FindClosestEnemy()
    {
        // تبسيط (تقدر تطورها لاحقًا)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject closest = null;

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = e;
            }
        }
        return closest;
    }

    // 🎯 زر تفعيل Aim Assist
    public void EnableAimAssist()
    {
        aimAssistEnabled = true;
        Debug.Log("Aim Assist ON (Soft)");
    }

    // ❌ زر X
    public void CloseUI()
    {
        if (aimAssistUI != null)
            aimAssistUI.SetActive(false);
    }
}
