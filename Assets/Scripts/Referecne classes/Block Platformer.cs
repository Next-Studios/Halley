using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlatformer : MonoBehaviour{

	#region Instance Variables

	// Public Variables


	// Private Variables
	private int blockCount = 2;
	private GameObject block;
	private float blockDistance;
	private float distancePlus;

    #endregion

    #region Constructor
    public BlockPlatformer(GameObject Block){
		this.block = Block;
	}
	public BlockPlatformer(GameObject Block, float Distance){
		this.block = Block;
		this.blockDistance = Distance;
	}
    #endregion

    #region Getters & Setters

    // Block
    public void setBlock(GameObject Block) {this.block = Block;}
	public GameObject getBlock() {return this.block;}

	// Distance
	public void setDistance(float Distance){this.blockDistance = Distance;}
	private float getDistance(){return this.blockDistance;}

	#endregion

	#region Functions

	// Create Block Function
	public GameObject BlockCreator(float MinRand, float MaxRand){
		float rand = Random.Range (MinRand, MaxRand);

		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);
		
		return this.block;
	}
	public GameObject BlockCreator(float Distance, float MinRand, float MaxRand){
		this.blockDistance = Distance;

		float rand = Random.Range (MinRand, MaxRand);

		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);

		return this.block;
	}
	public GameObject BlockCreator(float Distance, float MinRand, float MaxRand, float DistancePlus){
		if (blockCount < 3) {
			this.blockDistance = Distance;
			this.distancePlus = DistancePlus;
		}

		float rand = Random.Range (MinRand, MaxRand);

		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);

		this.blockDistance += this.distancePlus;

		blockCount++;

		return this.block;
	}
	public GameObject BlockCreator(float MinRand, float MaxRand, float DistancePlus, bool distance){
		this.distancePlus = DistancePlus;
	
		float rand = Random.Range (MinRand, MaxRand);

		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);

		this.blockDistance += this.distancePlus;

		return this.block;
	}

	//First Create
	public GameObject FirstBlockCreator(float MinRand, float MaxRand, float Touch_Y){
		float rand = Random.Range (MinRand, MaxRand);
			
		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);

		return this.block;
	}
	public GameObject FirstBlockCreator(float MinRand, float MaxRand, float Touch_Y, float Distance){
		this.blockDistance = Distance;

		float rand = Random.Range (MinRand, MaxRand);
			
		block = Instantiate (block,
			new Vector3(rand,
				block.transform.position.y+blockDistance,
				0),
			block.transform.rotation);
	
		return this.block;
	}


	// Destroy Block
	public static void BlockDestroyer(GameObject Block){
		Destroy (Block);
	}public static void BlockDestroyer(GameObject Block ,float Time){
		Destroy (Block, Time);
	}

	#endregion
}
