using UnityEngine;
using DG.Tweening;



public class SliderGame : MonoBehaviour
{
    [SerializeField]
    private Transform emptyObj;
    [SerializeField]
    private TileScripts[,] tiles;
    [SerializeField]
    private TileScripts tileTemp;
    [SerializeField]
    private int size = 5;

    private TileScripts emptyTile;

    private readonly Vector2[] checkPoints = {Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private void Start()
    {
        tiles = new TileScripts[size, size];

        for(int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                tiles[x, y] = Instantiate(tileTemp, tileTemp.transform.parent);
                tiles[x, y].Init();
                tiles[x, y].OnTTT += (data) => data = Vector2.zero; // ���ٽ�, �Լ�
            }
        }

        emptyTile = tiles[size - 1, size - 1];
        tiles[size - 1, size - 1] = null;
    }

    private bool CheckNull(Vector2Int point)
    {
        return tiles[point.x, point.y] == null;
    }

    public void SetCoords()
    {
        Vector2 point = Vector2.zero;

        point.x += 194.5f;
        point.y += 187.5f;

        point += -95f * point.x;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction * 100);

            if(hit)
            {
                Debug.Log(hit.transform.name);
                if(Vector2.Distance(emptyObj.position, hit.transform.position) < 1.5)
                {
                    Vector2 lastEmptyObjPos = emptyObj.position;

                    
                    emptyObj.position = tileScripts.targetPos;
                    tileScripts.targetPos = lastEmptyObjPos;
                }
            }
        }
    }
}
