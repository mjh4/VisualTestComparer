using System;
using System.Reflection;
using System.Security.Cryptography;
using MonoMac.AddressBook;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace VisualTestComparer
{
	public class ImageTest
	{
	
		// PropertyInfo object of ImageTest
		public PropertyInfo snippet {
			get; set;
		}

	


		//The ID of the xml element
		public String name{
			get; set;
		}

		//
		public String pathName{
			get; set;
		}

		// Holds the paths to the Master image directories
		public IEnumerable masterVersions {
			get;
			set;
		}

		// Number of iOS versions we are testing
		public int masterCount {
			get;
			set;
		}


		// Holds the paths to the visual failure directories
		public IEnumerable failVersions {
			get;
			set;
		}

		//False if missing a master
		public bool mastersValid {
			get;
			set;
		}

		// False if there is a visual failure
		public bool noVisualFail {
			get;
			set;
		}
			
		// Key of (master/fail) and version number
		// returns right image path
		public Dictionary<string, string> imageDictionary {
			get;
			set;
		}

		//Hasher to generate the image path 
		static readonly SHA1 Hasher = SHA1.Create();

		public ImageTest (PropertyInfo newSnippet, IEnumerable masterDirectories, IEnumerable failDirectories)
		{
			// Assign values
			snippet = newSnippet;
			name = snippet.Name;
			mastersValid = true;
			noVisualFail = true;
			pathName = GeneratePathName ();
	//		Console.WriteLine (name);
	//		Console.WriteLine (pathName);
			masterVersions = masterDirectories;

			failVersions = failDirectories;
			// Run validation method
			Validate ();
			// Generate image paths once
			// Validate has been run
			GenerateImageDictionary ();



		}

	
		public void GenerateImageDictionary(){

			// Initialize Dictionary
			imageDictionary = new Dictionary<string,string>();

			// Generate Master Image Paths 
			foreach (string directory in masterVersions) {
				//Remove everything but iOS version
				var version = directory.Remove (0, 74);
			//	Console.WriteLine ("File path: " + directory + "/OriginalPhone/" + pathName + ".png");
			
				if (File.Exists (directory + "/OriginalPhone/" + pathName+ ".png")) {
					// If there is a master image, create an entry in the dictionary
					imageDictionary.Add("master"+version, (directory + "/OriginalPhone/" + pathName + ".png"));
					} else {
					// Otherwise, associate key with fail image
					imageDictionary.Add ("master"+ version, "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/Stock/failimage.png");
					}
					

			}

			// Generate Visual Failure paths 
			foreach (string directory in failVersions) {
				var version = directory.Remove (0, 81);
				//var master = imageDictionary ["master" + version];

				if (File.Exists (directory + "/OriginalPhone/" + pathName + ".png")) {
					// If there is a file in the Visual Failure file, create the entry in the dictionary
					imageDictionary.Add ("fail" + version, (directory + "/OriginalPhone/" + pathName + ".png"));


				} else {
					// Otherwise, associate key with green check 
					imageDictionary.Add ("fail" + version, "/Users/Administrator/Projects/VisualTestComparer/VisualValidation/Stock/Check.png");

				}

			}
				
		}

		// Generate the PathName from the xml element using the Hasher
		private String GeneratePathName()
		{
			var element = snippet.GetValue (null, null) as XElement;
			var elementBytes = System.Text.Encoding.UTF8.GetBytes (element.ToString ());
			var imageName = BitConverter.ToString (Hasher.ComputeHash (elementBytes)).Replace ("-", ""); //+ (sceneID != -1 ? sceneID.ToString () : string.Empty);
			return imageName;
		
		}


		private void Validate()
		{
			// Use variable to keep track of the number of 
			// iOS versions in master directory
			var i = 0;
			foreach (string path in masterVersions) {
			//	Console.WriteLine ("Master path: " + path + "/OriginalPhone/" + pathName + ".png");
				// Master is valid if the file exists, and mastersValid is true already
				mastersValid = File.Exists (path + "/OriginalPhone/" + pathName + ".png") && mastersValid;
		//		Console.WriteLine (mastersValid.ToString());


				i++;
				}

			masterCount = i;




			foreach (string path in failVersions) {
			//Console.WriteLine (path);

			// No visual fails if file doesn't exist, and noVisualFail is true
			noVisualFail = !(File.Exists (path + "/OriginalPhone/" + pathName + ".png")) && noVisualFail;


			}
				
		
				
		}








	}
	}

