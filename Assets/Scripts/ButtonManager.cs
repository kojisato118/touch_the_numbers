using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonManager : MonoBehaviour
{
	//プロパティ
	public event EventHandler<ButtonActionEventArgs> SelecetedButton;

	public Text ButtonText;

	public int Number;

	// Use this for initialization
	void Start ()
	{
		ButtonText.text = Number.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//Action
	public void ClickButton ()
	{
		RaiseSelectedButton (this.Number);
	}

	public void HideButton ()
	{
		GetComponentInParent<Animator> ().SetBool ("Visible", false);

	}

	//Event
	protected void RaiseSelectedButton (int selectedButtonNumber)
	{
		var e = new ButtonActionEventArgs (selectedButtonNumber);
		if (SelecetedButton != null)
			SelecetedButton (this, e);
	}
}


public class ButtonActionEventArgs : EventArgs
{

	/// <summary>
	/// Initializes a new instance of the <see cref="ButtonActionEventArgs"/> class.
	/// </summary>
	/// <param name="number">Number.</param>
	/// 
	public ButtonActionEventArgs (int number)
	{
		this.number = number;
	}

	/// <summary>
	/// Gets the number.
	/// </summary>
	/// <value>The number.</value>
	public int number { get; private set; }

}
