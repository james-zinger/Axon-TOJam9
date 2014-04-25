﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 	A game singleton responsible for being a container for essential game objects and various
/// 	game functions.
/// </summary>
/// <remarks>	James, 2014-04-19. </remarks>
public class Game : MonoBehaviour
{

	#region Singleton Method and Instance

	private static Game instance = null;

	/// <summary>	Gets or sets the singleton instance. </summary>
	/// <value>	The instance. </value>
	public static Game Instance
	{
		get
		{
			if ( instance == null )
			{
				GameObject go = Instantiate( new GameObject(), Vector3.zero, Quaternion.identity ) as GameObject;
				instance = go.AddComponent<Game>();
			}

			return instance;
		}

		private set { instance = value; }
	}

	#endregion

	#region Unity Events

	void Awake()
	{
		if ( instance != null )
		{
			Debug.LogError( "[ERROR - Singleton] Tried to instantiate a second instance of the Game singleton" );
			Destroy( this );
			return;
		}

		Instance = this;

	}

	void OnDestory()
	{
		Instance = null;
	}

	#endregion

}