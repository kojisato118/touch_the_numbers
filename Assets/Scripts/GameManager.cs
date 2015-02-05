using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
		public GameObject ButtonPrefab;
		public GameObject Panel;

		private int[] NumbersList;

		private int AnsNumber;

		// Use this for initialization
		void Start ()
		{
				AnsNumber = 1;
				CreateNumbersList ();

				for (int i = 0; i < 25; i++) {
						GameObject buttonObj = Instantiate (ButtonPrefab) as GameObject;
						buttonObj.transform.SetParent (Panel.transform);
						ButtonManager buttonManager = buttonObj.GetComponent<ButtonManager> ();
						buttonManager.Number = NumbersList[i] + 1;
						buttonManager.SelecetedButton += SelectedButton;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void CreateNumbersList ()
		{
				int number = 25;
				NumbersList = new int[number];

				for (int i = 0; i < number; i++)
						NumbersList [i] = i;

				for (int i = number; i > 1; i--) {
						int p = Random.Range(0, i);
						int t = NumbersList [i - 1];
						NumbersList [i - 1] = NumbersList [p];
						NumbersList [p] = t;
				}

		}

		void SelectedButton (object sender, ButtonActionEventArgs e)
		{
				if (e.number == AnsNumber) {
						ButtonManager buttonManager = (ButtonManager)sender;
						buttonManager.transform.localScale = new Vector3 (0, 0, 0);

						AnsNumber++;
				}
		}
}
