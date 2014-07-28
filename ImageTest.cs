using System;
using System.Reflection;
using System.Security.Cryptography;
using MonoMac.AddressBook;
using System.Xml.Linq;

//using Tests;
using System.IO;
//using Xwt.Drawing;
using System.Xml;
using System.Collections;

namespace VisualTestComparer
{
	public class ImageTest
	{



		public PropertyInfo snippet {
			get; set;
		}

		public Boolean isValid{
			get; set;
		}


		public String name{
			get; set;
		}

		public String pathName{
			get; set;
		}

		public IEnumerable masterVersions {
			get;
			set;
		}

		public IEnumerable failVersions {
			get;
			set;
		}

		public bool mastersValid {
			get;
			set;
		}

		public bool noVisualFail {
			get;
			set;
		}


		static readonly SHA1 Hasher = SHA1.Create();

		public ImageTest (PropertyInfo newSnippet, IEnumerable masterDirectories, IEnumerable failDirectories)
		{
			snippet = newSnippet;

			name = snippet.Name;
			mastersValid = true;
			noVisualFail = true;

			pathName = GeneratePathName ();
			Console.WriteLine (name);
			Console.WriteLine (pathName);
			masterVersions = masterDirectories;

			failVersions = failDirectories;
			Validate ();




		}

	

		private String GeneratePathName()
		{
			var element = snippet.GetValue (null, null) as XElement;
			var elementBytes = System.Text.Encoding.UTF8.GetBytes (element.ToString ());
			var imageName = BitConverter.ToString (Hasher.ComputeHash (elementBytes)).Replace ("-", ""); //+ (sceneID != -1 ? sceneID.ToString () : string.Empty);
			return imageName;
		
		}
			
		private void Validate()
		{

			foreach (string path in masterVersions) {
				Console.WriteLine ("Master path: " + path + "/OriginalPhone/" + pathName + ".png");
				mastersValid = File.Exists (path + "/OriginalPhone/" + pathName + ".png");
				Console.WriteLine (mastersValid.ToString());

				if (mastersValid)
					Console.WriteLine ("Master Valid");

				if (!mastersValid)
					Console.WriteLine ("Master Failed");
			}







			foreach (string path in failVersions) {
				Console.WriteLine (path);
				noVisualFail = !(File.Exists (path + "/OriginalPhone/" + pathName + ".png"));

			}

			if (noVisualFail) {
				Console.WriteLine ("We did not have a visual fail");
			}
		
				
		}








	}
	}

