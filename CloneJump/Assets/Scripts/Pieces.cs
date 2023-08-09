using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pieces : MonoBehaviour
{
    [Header("Pieces")]
    [SerializeField] private List<GameObject> PieceList = new List<GameObject>();
    [Header("Piece Material")]
    [SerializeField] private Material green;
    [SerializeField] private Material red;
    public void PieceRemove()
    {
        int removeIndex = Random.Range(0,PieceList.Count);
        PieceList[removeIndex].GetComponent<MeshRenderer>().enabled = false;
        PieceList[removeIndex].GetComponent<MeshCollider>().convex = true;
        PieceList[removeIndex].GetComponent<MeshCollider>().isTrigger = true;
        PieceList[removeIndex].name = "Buff";
        List<GameObject> Pieces = new List<GameObject>();
        Pieces = PieceList;
        Pieces.RemoveAt(removeIndex);
        PiecesColor(Pieces);
    }
    private void PiecesColor(List<GameObject> pieces)
    {
        int redMaterialIndex = Random.Range(0,pieces.Count);
        foreach (var item in pieces)
        {
            item.GetComponent<Renderer>().material = green;
        }
        pieces[redMaterialIndex].GetComponent<Renderer>().material = red;
        pieces[redMaterialIndex].tag = "finish";
    }
    public void remove()
    {
        Destroy(this.gameObject);
    }
}