﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	#region Singleton
	private static InputManager m_instance;
	void Awake(){
		if(m_instance == null){
			//If I am the first instance, make me the Singleton
			m_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}else{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != m_instance)
				Destroy(this.gameObject);
		}
	}
	#endregion Singleton

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			UpdateSmartphone ();
		} else {
			UpdateKeyboard();
		}
	}

	void UpdateSmartphone(){
		if(PlayerManager.m_instance != null){
			PlayerManager.m_instance.MOVEDEVICE(Input.acceleration.x);
			
			if(Input.touchCount > 0){
				PlayerManager.m_instance.BeanUp();
			}else{
				Debug.Log ("Bean Down due to PORTABLE DEVICE ");
				PlayerManager.m_instance.BeanDown();
			}
		}
	}

	void UpdateKeyboard(){
		if(Input.GetKeyDown("p")){
			Debug.Log("PAUSE ! ");
			GameStateManager.setGameState(GameState.Pause);
		}
		
		if(Input.GetKeyDown(KeyCode.Space)){
			//Debug.Log ("SPACE DOWN -> BEAN UP");
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.BeanUp();
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			//Debug.Log ("SPACE UP - > BEAN DOWN");
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.BeanDown();
			}
		}
		
		if(Input.GetKey("q") || Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.LEFT();
			}
		}
		/*
		if(Input.GetKeyDown("s")){
			PlayerManager.DOWN ();
		}
		*/
		if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.RIGHT();
			}
		}
	}

	void UpdateMenuState(){
		if(Input.GetKeyDown(KeyCode.Return)){
			GameStateManager.setGameState (GameState.Playing);
			Application.LoadLevelAsync ("LevelScene");
		}
	}

	void UpdatePlayingState(){
		if(Input.GetKeyDown("p")){
			Debug.Log("PAUSE ! ");
			GameStateManager.setGameState(GameState.Pause);
		}

		/*if(Input.GetKeyDown("z") || Input.GetKeyDown("w")){
			PlayerManager.UP();
		}
		*/

		if(Input.GetKeyDown(KeyCode.Space)){
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.BeanUp();
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			Debug.Log ("SPACE UP -> BEAN DOWN FROM UPDATE PLAYING STATE");
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.BeanDown();
			}
		}
		if(Input.GetKey("q") || Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.LEFT();
			}
		}
		/*
		if(Input.GetKeyDown("s")){
			PlayerManager.DOWN ();
		}
		*/
		if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
			if(PlayerManager.m_instance){
				PlayerManager.m_instance.RIGHT();
			}
		}
	}

	void UpdatePauseState(){
		if(Input.GetKeyDown("p")){
			Debug.Log("DÉPAUSE ! ");
			GameStateManager.setGameState(GameState.Playing);
		}
	}

	void UpdateGameOverState(){

	}

}
