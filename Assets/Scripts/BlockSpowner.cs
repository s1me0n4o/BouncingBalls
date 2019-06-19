using System.Collections.Generic;
using UnityEngine;

public class BlockSpowner : MonoBehaviour
{
    private int playWidth = 8;
    private float distanceBetweenBlocks = 1f;
    private int rowsSpowned;

    [SerializeField]
    private Block blockPref;

    private List<Block> blocksSpowned = new List<Block>();

    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            SpownRowOfBlocks();
        }
    }

    public void SpownRowOfBlocks()
    {
        foreach (var block in blocksSpowned)
        {
            if (block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;
            }
        }

        for (int i = 0; i < playWidth; i++)
        {
            //around 30% chance to get random <= 30
            if (UnityEngine.Random.Range(0, 100) <= 30)
            {
                var block = Instantiate(blockPref, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 3) + rowsSpowned;

                block.SetHits(hits);

                blocksSpowned.Add(block);
            }
        }
        rowsSpowned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * i * distanceBetweenBlocks;
        return pos;
    }
}
