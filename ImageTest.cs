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
using System.Collections.Generic;

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

		public int masterCount {
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
			

		public Dictionary<string, string> imageDictionary {
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
			GenerateImageDictionary ();



		}

	
		public void GenerateImageDictionary(){

			// masterfail
		//	string[][] imageArray = new string[masterCount] [2];
			imageDictionary = new Dictionary<string,string>();

			foreach (string directory in masterVersions) {
				var version = directory.Remove (0, 74);
				Console.WriteLine ("File path: " + directory + "/OriginalPhone/" + pathName + ".png");
				var question = File.Exists (directory + "/OriginalPhone/" + pathName + ".png");
				if (File.Exists (directory + "/OriginalPhone/" + pathName+ ".png")) {
					imageDictionary.Add("master"+version, (directory + "/OriginalPhone/" + pathName + ".png"));
					} else {

					imageDictionary.Add ("master"+ version, "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/Stock/failimage.png");
					}
					

			}
						// visualvalidation fail

			foreach (string directory in failVersions) {
				var version = directory.Remove (0, 81);
				var master = imageDictionary ["master" + version];

				if (File.Exists (directory + "/OriginalPhone/" + pathName + ".png")) {
					imageDictionary.Add ("fail" + version, (directory + "/OriginalPhone/" + pathName + ".png"));

				} else {

					imageDictionary.Add ("fail" + version, master);

				}

			}
				
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
			var i = 0;
			foreach (string path in masterVersions) {
				Console.WriteLine ("Master path: " + path + "/OriginalPhone/" + pathName + ".png");
				mastersValid = File.Exists (path + "/OriginalPhone/" + pathName + ".png");
				Console.WriteLine (mastersValid.ToString());

				if (mastersValid)
					Console.WriteLine ("Master Valid");

				if (!mastersValid)
					Console.WriteLine ("Master Failed");

				i++;
				}

			masterCount = i;








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

