using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{

    #region Variables
    private GameObject _ProgressBar;
    private GameObject _Gift;
    private Vector3[] _Points;
    #endregion

    #region Constructor
    public Gift(GameObject Gift, Vector3[] Points)
    {
        this._Gift = Gift;
        this._Points = Points;
    }
    public Gift(GameObject Gift, Vector3[] Points, GameObject ProgressBar)
    {
        this._Gift = Gift;
        this._ProgressBar = ProgressBar;
        this._Points = Points;
    }
    #endregion

    #region Getters & Setters
    public GameObject getGift
    {
        get { return this._Gift; }
    }

    public GameObject Time
    {
        get { return this._ProgressBar; }
        set { this._ProgressBar = value; }
    }

    public Vector3[] Points
    {
        get { return this._Points; }
        set { this._Points = value; }
    }
    #endregion

    #region Methods
    public GameObject CreateGift()
    {
        Vector3 pos = new Vector3();
        Vector3[] worldPos = new Vector3[2];

        worldPos[0].x = this._Points[0].x;
        worldPos[0].y = this._Points[0].y;
        worldPos[1].x = this._Points[1].x;
        worldPos[1].y = this._Points[1].y;
        pos.x = Random.Range(worldPos[0].x, worldPos[1].x);
        pos.y = Random.Range(worldPos[1].y, worldPos[0].y);

        GameObject g;
        g = Instantiate(this._Gift, pos, this._Gift.transform.rotation);

        return g;
    }
    #endregion
}
