using System.Collections;
using MelonLoader;
using TabExtension.Config;
using TabExtension.UI;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace TabExtension;

public class TabExtensionMod : MelonMod
{
	public static readonly string Version = "1.3.0";

	public static TabExtensionMod Instance { get; private set; }

	public override void OnApplicationStart()
	{
		Instance = this;
		MelonLogger.Msg("Initializing TabExtension " + Version + "...");
		Configuration.Init();
		ClassInjector.RHelperRegisterTypeInIl2Cpp<LayoutListener>();
		ClassInjector.RHelperRegisterTypeInIl2Cpp<TabLayout>();
		MelonCoroutines.Start(Init());
	}

	private IEnumerator Init()
	{
		while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null)
		{
			yield return null;
		}
		while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent") == null)
		{
			yield return null;
		}
		GameObject quickMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject;
		GameObject layout = quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup").gameObject;
		layout.AddComponent<TabLayout>();
		MelonLogger.Msg("Running version " + Version + " of TabExtension.");
	}
}
