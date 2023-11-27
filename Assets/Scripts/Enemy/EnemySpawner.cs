using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public float spawnInterval;
    public GameObject[] enemiesPrefabs;
    [SerializeField] private ShipData playerShip;

    private float timeElapsed;

    void Update()
    {
        if(GameInstance.Instance.GameModeProperty == GameModes.PLAY)
        {
            timeElapsed += Time.deltaTime;
            if(spawnInterval < timeElapsed)
            {
                SpawnEnemy();
                timeElapsed = 0f;
            }
        }
    }

    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemiesPrefabs.Length);
        GameObject enemy = Instantiate(enemiesPrefabs[randomIndex], transform.position, transform.rotation);
        EnemyBehaviour enemyClass = enemy.GetComponent<EnemyBehaviour>();
        enemyClass.playerShip = playerShip;
    }

    public void Reset()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length > 0)
        {
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}
