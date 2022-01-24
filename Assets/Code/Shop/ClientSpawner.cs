using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public int tMinCliente;
    public int tMaxCliente;
    public Vector3 ClientSpawnPosition;

    public Task clientSpawningTask;
    public bool clientSpawning;

    Cliente activeClient;

    private void Start()
    {
        clientSpawning = true;
        clientSpawningTask = spawnClients();
    }

    private void Update()
    {
        if (TimeManager.Day && clientSpawningTask == null)
        {
            clientSpawningTask = spawnClients();
        }

        if (clientSpawningTask != null && clientSpawningTask.IsCompleted)
        {
            clientSpawningTask = null;
        }
    }

    public async Task spawnClients()
    {
        while (TimeManager.Day && clientSpawning)
        {
            if (!Application.isPlaying || !SceneManager.GetActiveScene().name.Equals("Shop") || !clientSpawning)
            {
                return;
            }

            await Task.Delay(Random.Range(tMinCliente * 1000, tMaxCliente * 1000));

            if (!Application.isPlaying || !SceneManager.GetActiveScene().name.Equals("Shop") || !clientSpawning)
            {
                return;
            }

            if (activeClient == null) instantiateNewClient();

            if (!Application.isPlaying || !SceneManager.GetActiveScene().name.Equals("Shop") || !clientSpawning)
            {
                return;
            }
        }
    }

    public void eliminateClient()
    {
        if (activeClient != null) Destroy(activeClient);
        activeClient = null;
    }

    private void instantiateNewClient()
    {
        if (!TimeManager.Day) return;

        if (activeClient != null) Destroy(activeClient);

        activeClient = Instantiate(clientPrefab, ClientSpawnPosition, Quaternion.identity).GetComponent<Cliente>();
    }
}
