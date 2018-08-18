using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBCD : MonoBehaviour {
	public Text teaName;
	public Button done;


	private int name;
	private int adjective;
	private int teaType;
	string [] adj = new string[]{"Buttery", "Caramelized", "Bitter", "Milky", "Toasty", "Chocolatey", "Perfumed", "Floral", "Pungent", "Woody", "Rich", "Piney", "Sweet", "Dry", "Velvety", "Smooth", "Brassy", "Nutty", "Herbaceous", "Plain", "Sour", "Burnt", "Full bodied", "Bright", "Complex", "Creamy", "Crisp", "Dense", "Earthy", "Elegant", "Juicy", "Opulent", "Refined", "Silky", "Balanced", "Bold", "Citrusy", "Deep", "Delicate", "Fine", "Fresh", "Intense", "Lemony", "Medicinal", "Nutty", "Powerful", "Robust", "Roasted", "Salted", "Sharp", "Smooth", "Tart", "Warming", "Zesty"};
	string [] tea = new string[]{"Rose Hip", "Jasmine", "Dandelion", "Oolong", "Green", "Black", "Spiced", "Matcha", "White", "Herbal", "Dark", "Chai", "Puer", "Chamomile", "Yellow", "Fermented", "Lemongrass", "Ginger", "Peppermint", "Lavender", "Hibiscus", "Milk Thistle", "Blackberry", "Cinnamon", "Cardamom", "Rooibos", "Nettle", "Sage", "Elderberry", "Valerian", "Bergamot", "Turmeric"};
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	public void OnMouseDown () {
		SceneManager.LoadScene (1);
	}
}
