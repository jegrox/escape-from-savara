using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem explosionParticle;

    public float spawnInterval = 5f;
    private float elapsedTime;

    public GameObject titleScreen;
    public GameObject hud;
    public GameObject[] prefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hpText;

    private Button button;

    private Player player;
    private int playerHP;

    private int minSpawn = 1;
    private int maxSpawn = 2;
    private int wave = 0;
    private int maxEnemyIdx = 1;
    private int score = 0;

    private bool isActive = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        button  = GameObject.Find("Start").GetComponent<Button>();
        button.onClick.AddListener(StartGame);

        UpdateHP();
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        UpdateHP();
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            int numberOfEnemies = Random.Range(minSpawn, maxSpawn);
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float randomX = Random.Range(-180, 180);
                int enemyIdx = Random.Range(0, maxEnemyIdx);
                Vector3 spawnPosition = new Vector3(randomX, 0f, 150);
                Spawn(prefabs[enemyIdx], spawnPosition);
            }
            elapsedTime = 0f;
            wave++;

            if (wave % 5 == 0)
            {
                maxSpawn++;
            }

            if (wave == 10)
            {
                maxEnemyIdx = 2;
            }
        }
    }

    void StartGame()
    {
        if (!isActive)
        {
            isActive = true;
            titleScreen.SetActive(false);
            hud.SetActive(true);
        }
    }

    void Spawn(GameObject prefab, Vector3 initialPosition)
    {
        Instantiate(prefab, initialPosition, prefab.transform.rotation);
    }

    public bool IsGameActive()
    {
        return isActive;
    }

    // ENCAPSULATION
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    void UpdateHP()
    {
        int hpToUpdate = player.getHP();
        if (hpToUpdate != playerHP)
        {
            playerHP = hpToUpdate;
            hpText.text = "HP: " + playerHP;
        }
    }

    public ParticleSystem getExplosionParticle()
    {
        return explosionParticle;
    }
}
