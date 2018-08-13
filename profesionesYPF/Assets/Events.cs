using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<InputManager.states> OnInput = delegate { };
	public static System.Action<int> QuestionDone = delegate { };
	public static System.Action<bool> OnUserStatus = delegate { };
	public static System.Action<string> OnKeyboardDone = delegate { };
}

