using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemies;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;
    //xem chung ta dang o vi tri tham chieu nao` (= 0 se~ la vi tri' dau tien)
    int wayPointIndex = 0;

    private void Awake()
    {
        enemies = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemies.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        //len if nay` de~ huong' dan~ chung ta di den cac diem tham chieu ma` chung' ta da~ thiet' lap.
        if(wayPointIndex < wayPoints.Count)
        {
            //neu wayPointIndex chua o vi tri cuoi cung` thi` chung' ta se~ tiep tuc. sang tham chieu tiep theo
            //de lam` duoc. dieu` do' thi` dau` tien chung ta can` biet chung ta dang o vi. tri' nao`
            //di chuyen? voi toc do bao nhieu
            Vector3 targetPos = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,targetPos,delta);
            //khi den diem tham chieu tiep theo ta can tang so tham chieu len
            if(transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
