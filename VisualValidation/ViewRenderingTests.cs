using System;
using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tests;

namespace MonoTouch.Design.Client
{
	[TestFixture]
	public class ViewRenderingTests : VisualValidationTestBase
	{
		[Test]
		public async Task NavigationController_TabController_ViewController_Segue ()
		{
			InconclusiveOnIos8 ();
			var storyboard = (Storyboard) await Render (StoryboardSnippets.Empty);
			var navigationControllerScene = (Scene) Catalog.MainCatalog.CreateInstanceForClass ("UINavigationController", DesignerSession).First ();
			var tabControllerScene = (Scene) Catalog.MainCatalog.CreateInstanceForClass ("UITabBarController", DesignerSession).First ();
			var viewControllerScene = (Scene) Catalog.MainCatalog.CreateInstanceForClass ("UIViewController", DesignerSession).First ();
			var viewControllerScene2 = (Scene) Catalog.MainCatalog.CreateInstanceForClass ("UIViewController", DesignerSession).First ();

			storyboard.AddChild (navigationControllerScene);
			storyboard.AddChild (tabControllerScene);
			storyboard.AddChild (viewControllerScene);
			storyboard.AddChild (viewControllerScene2);

			// Add two ViewControllers so that we can test that both TabBarItems show up correctly in the TabBarController
			viewControllerScene.ViewController.AddChild (Parser.Instance.Parse (@"<navigationItem key=""navigationItem"" title=""Nav bar 1"" id=""FK1-9j-6Cj""/>"));
			viewControllerScene.ViewController.AddChild (Parser.Instance.Parse (@"<tabBarItem key=""tabBarItem"" title=""Tab Bar Item 1"" id=""tCp-qW-Kp9""/>"));

			viewControllerScene2.ViewController.AddChild (Parser.Instance.Parse (@"<navigationItem key=""navigationItem"" title=""Nav bar 2"" id=""FK1-9j-6Ca""/>"));
			viewControllerScene2.ViewController.AddChild (Parser.Instance.Parse (@"<tabBarItem key=""tabBarItem"" title=""Tab Bar Item 2"" id=""tCp-qW-Kpb""/>"));

			foreach (var segue in tabControllerScene.ViewController.Segues)
				segue.Remove ();

			new PossibleRootRelationship (navigationControllerScene.ViewController, tabControllerScene.ViewController).Create (DesignerSession);
			new PossibleTabRelationship (tabControllerScene.ViewController, viewControllerScene.ViewController).Create (DesignerSession);
			new PossibleTabRelationship (tabControllerScene.ViewController, viewControllerScene2.ViewController).Create (DesignerSession);

			bool successful = true;
			successful = (await Validate (storyboard.Element, "navigationController", 0)) && successful;
			successful = (await Validate (storyboard.Element, "tabController", 1)) && successful;
			successful = (await Validate (storyboard.Element, "viewController", 2)) && successful;
			successful = (await Validate (storyboard.Element, "viewController", 3)) && successful;
			Assert.IsTrue (successful);
		}

		[Test]
		public async Task ValidateAllViewSnippets ()
		{
			InconclusiveOnIos8 ();
			var snippets = typeof (ViewSnippets).GetProperties (System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
			var globalResult = true;
			// On iOS 7 the DatePicker element is using the current time so it's not possible to run test on them
			if (IsRunningOnIos7)
				snippets = snippets.Where (s => !s.Name.StartsWith ("DatePicker")).ToArray ();
			foreach (var snippet in snippets) {
				var element = snippet.GetValue (null, null) as XElement;
				if (element != null) {
					var result = await Validate (element, snippet.Name);
					if (!result)
						Console.WriteLine ("Rendered view image did not match master image: {0}", snippet.Name);
					globalResult &= result;
				}
			}
			if (!globalResult)
				Assert.Fail ("Some rendered images didn't match their master.");
		}

		[Test]
		public async Task ValidateDatePickerNotCurrentDate ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (ViewSnippets.DatePicker_DontUseCurrentDate, "DatePicker");
		}

		[Test]
		public async Task ValidateAllSceneSnippets ()
		{
			InconclusiveOnIos8 ();
			var snippets = typeof (SceneSnippets).GetProperties (System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
			var globalResult = true;
			foreach (var snippet in snippets) {
				var element = snippet.GetValue (null, null) as XElement;
				if (element != null) {
					var result = await Validate (element, snippet.Name);
					if (!result)
						Console.WriteLine ("Rendered scene image did not match master image: {0}", snippet.Name);
					globalResult &= result;
				}
			}
			if (!globalResult)
				Assert.Fail ("Some rendered images didn't match their master.");
		}

		[Test]
		public async Task ValidateToolbox_Controls ()
		{
			InconclusiveOnIos8 ();
			var catalog = Catalog.GetMainCatalogForIosVersion (DesignerSession.IosVersion);
			var category = catalog.Categories[1];
			await ValidateToolboxCategory (category);
		}

		[Test]
		public async Task ValidateToolbox_Controllers ()
		{
			InconclusiveOnIos8 ();
			var catalog = Catalog.GetMainCatalogForIosVersion (DesignerSession.IosVersion);
			var category = catalog.Categories[0];
			await ValidateToolboxCategory (category);
		}

		[Test]
		public async Task ValidateToolbox_DataViews ()
		{
			InconclusiveOnIos8 ();
			var catalog = Catalog.GetMainCatalogForIosVersion (DesignerSession.IosVersion);
			var category = catalog.Categories[2];
			await ValidateToolboxCategory (category);
		}

		async Task ValidateToolboxCategory (Category category)
		{
			var globalResult = true;
			foreach (var item in category.Items) {
				// Based on current time, unreliable in test
				if (IsRunningOnIos7 && item.Class == "UIDatePicker")
					continue;
				var elements = item.Snippet.CreateFragmentElements ();
				foreach (var snippet in elements) {
					var result = await Validate (snippet, item.Name);
					if (!result)
						Console.WriteLine ("Rendered scene image did not match master image: {0}", item.Name);
					globalResult &= result;
				}
			}
			if (!globalResult)
				Assert.Fail ("Some rendered images didn't match their master.");
		}

		[Test]
		public async Task ValidateStoryboardTintColor ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (StoryboardSnippets.StoryboardWithTintColor, "#1");
		}

		[Test]
		public async Task ValidateStoryboardRussianDolls ()
		{
			InconclusiveOnIos8 ();
			await SendAssembly ();

			foreach (var scenario in new[] {
				"CustomViewThrowsInCtor",
				//"CustomViewThrowsInLayout",
				"CustomViewThrowsInDraw"
			})
			await ValidateAndAssert (StoryboardSnippets.GetStoryboardRussianDolls (scenario), scenario);
		}

		[Test]
		public async Task ValidateNavControllerDescendantNavigationBar_ViewCtrl ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (StoryboardSnippets.NavigationControllerWithBarItems, "#1", sceneID: 1);
		}

		[Test]
		public async Task ValidateNavControllerDescendantNavigationBar_NavCtrl ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (StoryboardSnippets.NavigationControllerWithBarItems, "#1", sceneID: 2);
		}

		[Test]
		public async Task ValidateNavControllerDescendantNavigationBar_TableCtrl ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (StoryboardSnippets.NavigationControllerWithBarItems, "#1", sceneID: 0);
		}

		[Test]
		public async Task ValidateSegueFromBarButtonItem ()
		{
			InconclusiveOnIos8 ();
			RequireiOS7 ();
			await ValidateAndAssert (StoryboardSnippets.SegueFromBarButtonItem, "#1", 0);
			await ValidateAndAssert (StoryboardSnippets.SegueFromBarButtonItem, "#2", 1);
			await ValidateAndAssert (StoryboardSnippets.SegueFromBarButtonItem, "#3", 2);
		}

		[Test]
		public async Task ValidateNavigationControllerScenario ()
		{
			InconclusiveOnIos8 ();
			var storyboard = XDocument.Load (IsRunningAtLeastIos7 ? "Storyboards/Navigation_Controller_Scenario.storyboard" : "Storyboards/Navigation_Controller_Scenario_iOS6.storyboard");
			int sceneNumber = storyboard.Root.Element ("scenes").Elements ("scene").Count ();
			for (int scene = 0; scene < sceneNumber; scene++)
				await ValidateAndAssert (storyboard.Root, "#" + scene, sceneID: scene);
		}
			
		[Test]
		public async Task Validate_TabbarController_AllViewControllers ()
		{
			InconclusiveOnIos8 ();
			var storyboard = await Render (StoryboardSnippets.Empty);
			foreach (var model in SceneSnippets.TabbarController)
				storyboard.AddChild (await Render<Scene> (model));

			storyboard = await Render (storyboard.Element.ToString ());
			await ValidateAndAssert (storyboard.Element, "#Scene0", 0);
			await ValidateAndAssert (storyboard.Element, "#Scene1", 1);
			await ValidateAndAssert (storyboard.Element, "#Scene2", 2);
		}

		[Test]
		public async Task ViewController_WithBarItems ()
		{
			InconclusiveOnIos8 ();
			var scene = await Render<Scene> (SceneSnippets.IPhoneStandard);
			var fixedSpace = await Render (ViewSnippets.BarButtonItem_FixedSpace);
			var flexibleSpace = await Render (ViewSnippets.BarButtonItem_FlexibleSpace);
			scene.ViewController.AddChild (fixedSpace);
			scene.ViewController.AddChild (flexibleSpace);

			await ValidateAndAssert (scene.Element);
		}

		[Test]
		public async Task Xib_ViewController ()
		{
			InconclusiveOnIos8 ();
			var viewController = Catalog.XibCatalog.GetXElementForClass ("UIViewController");
			await ValidateAndAssert (viewController, "#1");
		}

		[Test]
		public async Task Xib_ViewControllerWithNavigationBar ()
		{
			InconclusiveOnIos8 ();
			var viewController = SceneSnippets.ViewController_SimulatedNavigationBar
				.Element ("objects")
				.Element ("viewController");

			await ValidateAndAssert (viewController, "#1");
		}
	}
}

