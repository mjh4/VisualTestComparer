using System;
using System.Xml.Linq;
//using MonoTouch.Design;

namespace VisualTestComparer
{
	public static class ViewSnippets
	{
	 	/*
		internal static XElement AdBannerView {
			get { return Catalog.MainCatalog.GetXElementForClass ("ADBannerView"); }
		}

		internal static XElement Button {
			get { return Catalog.MainCatalog.GetXElementForClass ("UIButton"); }
		}

		internal static XElement Button_WithNoFontDesc {
			get { return Catalog.GetMainCatalogForIosVersion (new Version (7, 0)).GetXElementForClass ("UIButton"); }
		} */

		public static XElement Button_AttributedTitle {
			get {
				return XElement.Parse (@"
					<button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" id=""5"" hasAttributedTitle=""YES"">
						<rect key=""frame"" x=""93"" y=""137"" width=""72"" height=""52"" />
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
						<fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""15"" />
						<state key=""normal"">
							<attributedString key=""attributedTitle"">
								<fragment content=""Attributed Button Title"">
									<attributes>
										<color key=""NSColor"" cocoaTouchSystemColor=""darkTextColor"" />
										<font key=""NSFont"" name=""Helvetica"" family=""Helvetica"" pointSize=""17"" />
										<paragraphStyle key=""NSParagraphStyle"" alignment=""natural"" lineBreakMode=""wordWrapping"" baseWritingDirection=""natural"" />
									</attributes>
								</fragment>
							</attributedString>
						</state>
					</button>");
			}
		}

		public static XElement Button_NoColor {
			get {
				return XElement.Parse (@"
					<button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" id=""Jzp-IG-odg"">
						<rect key=""frame"" x=""0.0"" y=""0.0"" width=""72"" height=""37""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""15""/>
						<state key=""normal"" title=""Button""/>
					</button>");
			}
		}
//
//		internal static XElement BarButtonItem {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIBarButtonItem"); }
//		}
//
//		internal static XElement BarButtonItem_FixedSpace {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIBarButtonItemFixedSpace"); }
//		}
//
//		internal static XElement BarButtonItem_FlexibleSpace {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIBarButtonItemFlexibleSpace"); }
//		}
//
//		internal static XElement CollectionReusableView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UICollectionReusableView"); }
//		}
//
//		internal static XElement CollectionView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UICollectionView"); }
//		}
//
//		public static XElement CollectionView_CustomLayout_NoClass {
//			get {
//				var element = CollectionView;
//				var layout = XElement.Parse (@"<collectionViewLayout key=""collectionViewLayout"" id=""xkU-38-3nI""/>");
//				element.ElementByKey ("collectionViewLayout").ReplaceWith (layout);
//				return element;
//			}
//		}
//
//		public static XElement CollectionView_CustomLayout_WithClass {
//			get {
//				var element = CollectionView;
//				var layout = XElement.Parse (@"<collectionViewLayout key=""collectionViewLayout"" id=""xkU-38-3nI"" customClass=""CustomCollectionViewLayout""/>");
//				element.ElementByKey ("collectionViewLayout").ReplaceWith (layout);
//				return element;
//			}
//		}
//
//		public static XElement CollectionView_CustomLayout_WithUnknownClass {
//			get {
//				var element = CollectionView;
//				var layout = XElement.Parse (@"<collectionViewLayout key=""collectionViewLayout"" id=""xkU-38-3nI"" customClass=""UnknownCustomClass""/>");
//				element.ElementByKey ("collectionViewLayout").ReplaceWith (layout);
//				return element;
//			}
//		}
//
//		internal static XElement CollectionView_HorizontalScroll {
//			get {
//				var element = CollectionView;
//				element.ElementByKey ("collectionViewLayout").SetAttributeValue ("scrollDirection", "horizontal");
//				return element;
//			}
//		}
//
//		public static XElement CollectionViewCell {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UICollectionViewCell"); }
//		}
//
//		public static XElement CollectionViewCell_WithChildren {
//			get {
//				var cell = CollectionViewCell;
//				cell.ElementByKey ("contentView").Add (new XElement ("subviews", Button));
//				return cell;
//			}
//		}
//
//		internal static XElement DatePicker {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIDatePicker"); }
//		} 

		public static XElement DatePicker_Countdown {
			get {
				return XElement.Parse (@"
					<datePicker contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" datePickerMode=""countDownTimer"" countDownDuration=""240"" minuteInterval=""1"" id=""nf1-en-xYY"">
						<rect key=""frame"" x=""0.0"" y=""108"" width=""320"" height=""216""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxY=""YES""/>
						<date key=""date"" timeIntervalSinceReferenceDate=""385050167.02320302"">
							<!--2013-03-15 14:22:47 +0000-->
						</date>
					</datePicker>");
			}
		}

		public static XElement DatePicker_Time {
			get {
				return XElement.Parse (@"
					<datePicker contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" datePickerMode=""time"" minuteInterval=""1"" id=""nf1-en-xYY"">
						<rect key=""frame"" x=""0.0"" y=""108"" width=""320"" height=""216""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxY=""YES""/>
						<date key=""date"" timeIntervalSinceReferenceDate=""385050167.02320302"">
							<!--2013-03-15 14:22:47 +0000-->
						</date>
					</datePicker>");
			}
		}

		internal static XElement DatePicker_DontUseCurrentDate {
			get {
				return XElement.Parse (@"
					<datePicker contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" datePickerMode=""dateAndTime"" minuteInterval=""1"" useCurrentDate=""NO"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""YaB-yP-ytA"">
						<rect key=""frame"" x=""0.0"" y=""119"" width=""320"" height=""162""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxY=""YES""/>
						<date key=""date"" timeIntervalSinceReferenceDate=""332704801.65417802"">
							<!--2011-07-18 18:00:01 +0000-->
						</date>
					</datePicker>");
			}
		}

		public static XElement GLKView_WithMultisample {
			get {
				return XElement.Parse (@"
					<glkView key=""view"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"" drawableMultisample=""4X"" id=""ceG-ED-hC6"">
						<rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
						<connections>
							<outlet property=""delegate"" destination=""g1A-EE-LDM"" id=""HGz-lz-Ypp""/>
						</connections>
					</glkView>
				");
			}
		}

//		internal static XElement ImageView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIImageView"); }
//		}
//
//		internal static XElement Label
//		{
//			get { return Catalog.MainCatalog.GetXElementForClass ("UILabel"); }
//		}
		
		public static XElement Label_AttributedString {
			get {
				return XElement.Parse (@"
					<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" lineBreakMode=""tailTruncation"" numberOfLines=""2"" baselineAdjustment=""alignBaselines"" allowsEditingTextAttributes=""YES"" highlighted=""YES"" adjustsFontSizeToFit=""NO"" autoshrinkMode=""none"" id=""TP4-n9-FiG"">
						<rect key=""frame"" x=""110"" y=""155"" width=""101"" height=""61""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<nil key=""highlightedColor""/>
						<attributedString key=""attributedText"">
							<fragment content=""FooBarBaz"">
								<attributes>
									<font key=""NSFont"" size=""12"" name=""Helvetica""/>
									<paragraphStyle key=""NSParagraphStyle"" alignment=""justified"" lineBreakMode=""wordWrapping"" baseWritingDirection=""natural"" lineSpacing=""1"" paragraphSpacingBefore=""1"" firstLineHeadIndent=""2"" headIndent=""1"" tighteningFactorForTruncation=""0.070000000298023224"" headerLevel=""1""/>
								</attributes>
							</fragment>
						</attributedString>
					</label>");
			}
		}

		// Used in VisualValidationTests
		public static XElement Label_AttributedString_ContentElement {
			get {
				return XElement.Parse (@"
					<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" horizontalHuggingPriority=""251"" verticalHuggingPriority=""251"" fixedFrame=""YES"" usesAttributedText=""YES"" lineBreakMode=""tailTruncation"" numberOfLines=""3"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" preferredMaxLayoutWidth=""280"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""TG0-LC-H7i"">
						<rect key=""frame"" x=""20"" y=""11"" width=""280"" height=""64""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<attributedString key=""attributedText"">
							<fragment>
								<string key=""content"">This text is rendered</string>
								<attributes>
									<font key=""NSFont"" size=""12"" name=""Helvetica""/>
									<paragraphStyle key=""NSParagraphStyle"" alignment=""justified"" lineBreakMode=""wordWrapping"" baseWritingDirection=""natural"" lineSpacing=""1"" paragraphSpacingBefore=""1"" firstLineHeadIndent=""2"" headIndent=""1"" tighteningFactorForTruncation=""0.070000000298023224"" headerLevel=""1""/>
								</attributes>
							</fragment>
						</attributedString>
					</label>");
			}
		}

		// Used in VisualValidationTests
		public static XElement Label_AttributedString_ContentElementAndContentAttribute {
			get {
				return XElement.Parse (@"
					<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" horizontalHuggingPriority=""251"" verticalHuggingPriority=""251"" fixedFrame=""YES"" usesAttributedText=""YES"" lineBreakMode=""tailTruncation"" numberOfLines=""3"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" preferredMaxLayoutWidth=""280"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""TG0-LC-H7i"">
						<rect key=""frame"" x=""20"" y=""11"" width=""280"" height=""64""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<attributedString key=""attributedText"">
							<fragment content=""This text is rendered"">
								<string key=""content"">This text is not rendered</string>
								<attributes>
									<font key=""NSFont"" size=""12"" name=""Helvetica""/>
									<paragraphStyle key=""NSParagraphStyle"" alignment=""justified"" lineBreakMode=""wordWrapping"" baseWritingDirection=""natural"" lineSpacing=""1"" paragraphSpacingBefore=""1"" firstLineHeadIndent=""2"" headIndent=""1"" tighteningFactorForTruncation=""0.070000000298023224"" headerLevel=""1""/>
								</attributes>
							</fragment>
						</attributedString>
					</label>");
			}
		}

		public static XElement Label_StringElement {
			get {
				return XElement.Parse (@"
					<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" lineBreakMode=""wordWrap"" numberOfLines=""9"" minimumFontSize=""10"" id=""23"">
						<rect key=""frame"" x=""20"" y=""164"" width=""280"" height=""133""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<string key=""text"">Text set via XElement</string>
					</label>");
			}
		}

		public static XElement Label_TextStyleHeadline {
			get {
				return XElement.Parse (@"<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" text=""Label"" lineBreakMode=""tailTruncation"" baselineAdjustment=""alignBaselines"" id=""Pka-Xa-qws"">
                        <rect key=""frame"" x=""116"" y=""8"" width=""196"" height=""20""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <fontDescription key=""fontDescription"" style=""UICTFontTextStyleHeadline1""/>
                        <color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
                        <nil key=""highlightedColor""/>
                    </label>");
			}
		}

//		internal static XElement MapView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("MKMapView"); }
//		}
//
//		internal static XElement NavigationBar {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UINavigationBar"); }
//		}

//		public static XElement NavigationBar_Empty {
//			get {
//				var element = NavigationBar;
//				NavigationBar.Element ("items").Remove ();
//				return element;
//			}
//		}

		public static XElement NavigationBar_WithBarTint {
			get {
				return XElement.Parse (@"<navigationBar key=""navigationBar"" contentMode=""scaleToFill"" barStyle=""black"" id=""dRA-qp-l3q"">
                        <autoresizingMask key=""autoresizingMask""/>
                        <color key=""barTintColor"" red=""1"" green=""0.43529412150000002"" blue=""0.81176471709999998"" alpha=""1"" colorSpace=""calibratedRGB""/>
                    </navigationBar>");
			}
		}

		internal static XElement NavigationBar_WithTextAttributes {
			get {
				return XElement.Parse (@"<navigationBar key=""navigationBar"" contentMode=""scaleToFill"" id=""SsA-X1-C5b"">
                        <autoresizingMask key=""autoresizingMask""/>
                        <textAttributes key=""titleTextAttributes"">
                            <fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""23""/>
                            <color key=""textColor"" red=""0"" green=""1"" blue=""0"" alpha=""1"" colorSpace=""calibratedRGB""/>
                            <color key=""textShadowColor"" red=""1"" green=""0"" blue=""0"" alpha=""1"" colorSpace=""calibratedRGB""/>
                            <offsetWrapper key=""textShadowOffset"" horizontal=""2"" vertical=""3""/>
                        </textAttributes>
                    </navigationBar>");
			}
		}

//		internal static XElement NavigationItem {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UINavigationItem"); }
//		}
//
//		public static XElement NavigationItem_WithBarButtonItems {
//			get {
//				var item = NavigationItem;
//				var barItem = BarButtonItem;
//				barItem.SetAttributeValue ("key", "leftBarButtonItem");
//				item.Add (barItem);
//				return item;
//			}
//		}

//		public static XElement NavigationItem_WithPrompt {
//			get {
//				var item = NavigationItem;
//				item.Add (new XAttribute ("prompt", "Hey"));
//				return item;
//			}
//		}
//
//		internal static XElement SearchBar {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UISearchBar"); }
//		}

//		public static XElement SearchBarWithScopes {
//			get {
//				var bar = SearchBar;
//				bar.Add (new XElement ("scopeButtonTitles", new XElement ("string", "Title1"), new XElement ("string", "Title2")));
//				return bar;
//			}
//		}
//
//		internal static XElement PickerView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIPickerView"); }
//		}

		public static XElement Segment {
			get {
				return XElement.Parse (@"<segment title=""First""/>");
			}
		}

		public static XElement Segment_WithImage {
			get {
				return XElement.Parse (@"<segment title="""" image=""foo.png"" />");
			}
		}

//		internal static XElement SegmentedControl {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UISegmentedControl"); }
//		}
//
//		public static XElement SegmentedControl_NoChildren {
//			get {
//				var seg = SegmentedControl;
//				seg.Element ("segments").Remove ();
//				return seg;
//			}
//		}

//		internal static XElement Slider {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UISlider"); }
//		}

//		public static XElement TabBar_Empty {
//			get {
//				var element = TabBar;
//				element.Element ("items").Remove ();
//				return element;
//			}
//		}
//
//		internal static XElement TabBar {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UITabBar"); }
//		}
//
//		internal static XElement TabBarItem {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UITabBarItem"); }
//		}

		public static XElement TabBar_WithItemWithBadge {
			get {
				return XElement.Parse (@"
					<tabBar contentMode=""scaleToFill"" fixedFrame=""YES"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""gRx-7E-GmW"">
						<rect key=""frame"" x=""0.0"" y=""437"" width=""320"" height=""49""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMinY=""YES""/>
						<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
						<items>
							<tabBarItem title=""MyTitle"" badgeValue=""MyBadge"" id=""GXL-z3-6eE""/>
							<tabBarItem title=""Item"" id=""hfl-Bp-QOT""/>
							<tabBarItem badgeValue=""555"" systemItem=""more"" id=""ukb-rX-n4Q""/>
						</items>
					</tabBar>");
			}
		}

		public static XElement TabBarItem_WithOffset {
			get {
				return XElement.Parse (@"
					<tabBarItem key=""tabBarItem"" title=""Item 1"" id=""UCN-BI-RSP"">
						<offsetWrapper key=""titlePositionAdjustment"" horizontal=""11"" vertical=""-8""/>
					</tabBarItem>");
			}
		}

//		internal static XElement TableViewCell {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UITableViewCell"); }
//		}

		public static XElement TableViewCell_WithTextAndDetail {
			get {
				return XElement.Parse (@"
					<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" textLabel=""S4m-IK-pax"" detailTextLabel=""dzc-k6-X6y"" style=""IBUITableViewCellStyleValue1"" id=""z2V-W7-M1D"">
						<rect key=""frame"" x=""0.0"" y=""66"" width=""320"" height=""44""/>
						<autoresizingMask key=""autoresizingMask""/>
						<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""center"">
							<rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""43""/>
							<autoresizingMask key=""autoresizingMask""/>
							<subviews>
								<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""left"" text=""Title"" lineBreakMode=""tailTruncation"" adjustsFontSizeToFit=""NO"" id=""S4m-IK-pax"">
									<rect key=""frame"" x=""10"" y=""11"" width=""35"" height=""21""/>
									<autoresizingMask key=""autoresizingMask""/>
									<fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""17""/>
									<color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
									<color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
								</label>
								<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""left"" text=""Detail"" textAlignment=""right"" lineBreakMode=""tailTruncation"" adjustsFontSizeToFit=""NO"" id=""dzc-k6-X6y"">
									<rect key=""frame"" x=""266"" y=""11"" width=""44"" height=""21""/>
									<autoresizingMask key=""autoresizingMask""/>
									<fontDescription key=""fontDescription"" type=""system"" pointSize=""17""/>
									<color key=""textColor"" red=""0.2196078431372549"" green=""0.32941176470588235"" blue=""0.52941176470588236"" alpha=""1"" colorSpace=""calibratedRGB""/>
									<color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
								</label>
							</subviews>
							<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
						</view>
					</tableViewCell>");
			}
		}

		public static XElement TableViewCell_WithImageView {
			get {
				return XElement.Parse (@"
					<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" textLabel=""S4m-IK-pax"" detailTextLabel=""dzc-k6-X6y"" style=""IBUITableViewCellStyleValue1"" imageView=""h0c-4n-LDd"" id=""z2V-W7-M1D"">
						<rect key=""frame"" x=""0.0"" y=""66"" width=""320"" height=""44""/>
						<autoresizingMask key=""autoresizingMask""/>
						<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""center"">
							<rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""43""/>
							<autoresizingMask key=""autoresizingMask""/>
							<subviews>
								<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""left"" text=""Title"" lineBreakMode=""tailTruncation"" adjustsFontSizeToFit=""NO"" id=""S4m-IK-pax"">
									<rect key=""frame"" x=""10"" y=""11"" width=""35"" height=""21""/>
									<autoresizingMask key=""autoresizingMask""/>
									<fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""17""/>
									<color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
									<color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
								</label>
								<label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" multipleTouchEnabled=""YES"" contentMode=""left"" text=""Detail"" textAlignment=""right"" lineBreakMode=""tailTruncation"" adjustsFontSizeToFit=""NO"" id=""dzc-k6-X6y"">
									<rect key=""frame"" x=""266"" y=""11"" width=""44"" height=""21""/>
									<autoresizingMask key=""autoresizingMask""/>
									<fontDescription key=""fontDescription"" type=""system"" pointSize=""17""/>
									<color key=""textColor"" red=""0.2196078431372549"" green=""0.32941176470588235"" blue=""0.52941176470588236"" alpha=""1"" colorSpace=""calibratedRGB""/>
									<color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
								</label>
                                <imageView opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""scaleToFill"" image=""first.png"" id=""h0c-4n-LDd"">
                                    <rect key=""frame"" x=""6"" y=""6"" width=""30"" height=""30""/>
                                    <autoresizingMask key=""autoresizingMask""/>
                                </imageView>
							</subviews>
							<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
						</view>
					</tableViewCell>");
			}
		}

		public static XElement TableViewCell_InnerLabel {
			get {
				return XElement.Parse (@"
					<label opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""left"" text=""Title"" lineBreakMode=""tailTruncation"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" id=""Hpj-ER-rmW"">
                        <rect key=""frame"" x=""46"" y=""11"" width=""35"" height=""21""/>
                        <autoresizingMask key=""autoresizingMask""/>
                        <fontDescription key=""fontDescription"" name=""Helvetica-Bold"" family=""Helvetica"" pointSize=""17""/>
                        <color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
                        <color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
                    </label>");
			}
		}

//		internal static XElement TableViewSection {
//			get {
//				return Catalog.UtilityCatalog.GetXElementForClass ("UITableViewSection");
//			}
//		}
//
//		public static XElement TableView_NoChildren {
//			get {
//				var table = Catalog.MainCatalog.GetXElementForClass ("UITableView");
//				table.Element ("prototypes").Remove ();
//				return table;
//			}
//		}

		public static XElement TableViewCell_ProtoTypes_CustomCellContent {
			get {
				return XElement.Parse (@"
                    <tableView key=""view"" opaque=""NO"" clipsSubviews=""YES"" clearsContextBeforeDrawing=""NO"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""Htv-l3-aVx"">
                        <rect key=""frame"" x=""0.0"" y=""20"" width=""320"" height=""460""/>
                        <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
                        <prototypes>
                            <tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""cL7-KJ-DAy"">
                                <rect key=""frame"" x=""0.0"" y=""22"" width=""320"" height=""44""/>
                                <autoresizingMask key=""autoresizingMask""/>
                                <view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
                                    <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""43""/>
                                    <autoresizingMask key=""autoresizingMask""/>
                                    <subviews>
                                        <textField opaque=""NO"" clipsSubviews=""YES"" contentMode=""scaleToFill"" contentHorizontalAlignment=""left"" contentVerticalAlignment=""center"" borderStyle=""roundedRect"" minimumFontSize=""17"" id=""7uV-cQ-wO7"">
                                            <rect key=""frame"" x=""20"" y=""7"" width=""97"" height=""30""/>
                                            <fontDescription key=""fontDescription"" type=""system"" pointSize=""14""/>
                                            <textInputTraits key=""textInputTraits""/>
                                        </textField>
                                        <slider opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" value=""0.5"" minValue=""0.0"" maxValue=""1"" id=""kbX-pa-UwA"">
                                            <rect key=""frame"" x=""184"" y=""11"" width=""118"" height=""23""/>
                                        </slider>
                                    </subviews>
                                    <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
                                </view>
                            </tableViewCell>
                        </prototypes>
				    </tableView>");
			}
		}

		internal static XElement TableView_DefaultSeparator {
			get {
				return XElement.Parse (@"
					<tableView clipsSubviews=""YES"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" separatorStyle=""default"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""NKl-QJ-dtb"">
						<rect key=""frame"" x=""0.0"" y=""5"" width=""160"" height=""240""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
						<prototypes>
							<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""rMF-yg-dj1"">
								<rect key=""frame"" x=""0.0"" y=""22"" width=""160"" height=""44""/>
								<autoresizingMask key=""autoresizingMask""/>
								<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
									<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
									<autoresizingMask key=""autoresizingMask""/>
									<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
								</view>
							</tableViewCell>
							<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""zbx-7x-nzq"">
								<rect key=""frame"" x=""0.0"" y=""66"" width=""160"" height=""44""/>
								<autoresizingMask key=""autoresizingMask""/>
								<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
									<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
									<autoresizingMask key=""autoresizingMask""/>
									<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
								</view>
							</tableViewCell>
						</prototypes>
					</tableView>");
			}
		}

		internal static XElement TableView_Prototypes_EmptySections {
			get {
				return XElement.Parse (
					@"<tableView key=""view"" opaque=""NO"" clipsSubviews=""YES"" clearsContextBeforeDrawing=""NO"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""mLL-gJ-YKr"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
                        <prototypes>
                            <tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" accessoryType=""disclosureIndicator"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" reuseIdentifier=""Cell"" textLabel=""2pz-XF-uhl"" style=""IBUITableViewCellStyleDefault"" id=""m0d-ak-lc9"">
                                <rect key=""frame"" x=""0.0"" y=""86"" width=""320"" height=""44""/>
                                <autoresizingMask key=""autoresizingMask""/>
                                <view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
                                    <rect key=""frame"" x=""0.0"" y=""0.0"" width=""287"" height=""43""/>
                                    <autoresizingMask key=""autoresizingMask""/>
                                    <subviews>
                                        <label opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"" text=""Title"" lineBreakMode=""tailTruncation"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" id=""2pz-XF-uhl"">
                                            <rect key=""frame"" x=""15"" y=""0.0"" width=""270"" height=""43""/>
                                            <autoresizingMask key=""autoresizingMask""/>
                                            <fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""20""/>
                                            <color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
                                            <color key=""highlightedColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
                                        </label>
                                    </subviews>
                                    <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
                                </view>
                                <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                <connections>
                                    <segue destination=""Ah7-4n-0Wa"" kind=""push"" identifier=""showDetail"" id=""jUr-3t-vfg""/>
                                </connections>
                            </tableViewCell>
                        </prototypes>
                        <sections/>
                    </tableView>");
			}
		}

		public static XElement TableView_Prototypes {
			get {
				return XElement.Parse (@"
					<tableView clipsSubviews=""YES"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""NKl-QJ-dtb"">
						<rect key=""frame"" x=""0.0"" y=""5"" width=""160"" height=""240""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
						<prototypes>
							<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""rMF-yg-dj1"">
								<rect key=""frame"" x=""0.0"" y=""22"" width=""160"" height=""44""/>
								<autoresizingMask key=""autoresizingMask""/>
								<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
									<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
									<autoresizingMask key=""autoresizingMask""/>
									<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
								</view>
							</tableViewCell>
							<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""zbx-7x-nzq"">
								<rect key=""frame"" x=""0.0"" y=""66"" width=""160"" height=""44""/>
								<autoresizingMask key=""autoresizingMask""/>
								<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
									<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
									<autoresizingMask key=""autoresizingMask""/>
									<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
								</view>
							</tableViewCell>
						</prototypes>
					</tableView>");
			}
		}

		public static XElement TableView_Prototypes_HeaderFooter {
			get {
				return XElement.Parse (@"
					<tableView clipsSubviews=""YES"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" separatorStyle=""none"" rowHeight=""90"" sectionHeaderHeight=""15"" sectionFooterHeight=""15"" id=""5DK-NN-TzP"">
					  <rect key=""frame"" x=""20"" y=""44"" width=""323"" height=""585"" />
					  <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxX=""YES"" heightSizable=""YES"" />
					  <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite"" />
					  <label key=""tableHeaderView"" opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" text=""   Photos"" lineBreakMode=""tailTruncation"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" id=""x2A-Ym-9yQ"">
					    <rect key=""frame"" x=""0.0"" y=""0.0"" width=""323"" height=""44"" />
					    <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					    <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite"" />
					    <fontDescription key=""fontDescription"" name=""HelveticaNeue-Bold"" family=""Helvetica Neue"" pointSize=""17"" />
					    <color key=""textColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedRGB"" />
					    <nil key=""highlightedColor"" />
					  </label>
					  <view key=""tableFooterView"" contentMode=""scaleToFill"" id=""py8-Ds-ifD"">
					    <rect key=""frame"" x=""0.0"" y=""149"" width=""323"" height=""44"" />
					    <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					    <subviews>
					      <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" lineBreakMode=""middleTruncation"" id=""EgZ-xi-sfu"">
					        <rect key=""frame"" x=""104"" y=""5"" width=""115"" height=""35"" />
					        <autoresizingMask key=""autoresizingMask"" flexibleMinX=""YES"" flexibleMaxX=""YES"" flexibleMinY=""YES"" flexibleMaxY=""YES"" />
					        <fontDescription key=""fontDescription"" name=""HelveticaNeue-Bold"" family=""Helvetica Neue"" pointSize=""13"" />
					        <state key=""normal"" title=""Add Photo"">
					          <color key=""titleColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					          <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite"" />
					        </state>
					        <state key=""highlighted"">
					          <color key=""titleColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					        </state>
					      </button>
					    </subviews>
					    <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite"" />
					  </view>
					  <prototypes>
					    <tableViewCell contentMode=""scaleToFill"" selectionStyle=""none"" indentationWidth=""10"" reuseIdentifier=""PhotoCell"" id=""udi-4k-xNA"" customClass=""PhotoCell"">
					      <rect key=""frame"" x=""0.0"" y=""59"" width=""323"" height=""90"" />
					      <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					      <view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
					        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""323"" height=""89"" />
					        <autoresizingMask key=""autoresizingMask"" />
					        <subviews>
					          <imageView userInteractionEnabled=""NO"" contentMode=""scaleToFill"" id=""113-ol-hne"">
					            <rect key=""frame"" x=""9"" y=""7"" width=""75"" height=""75"" />
					            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					          </imageView>
					          <imageView clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""scaleAspectFill"" id=""fIK-nj-OU6"">
					            <rect key=""frame"" x=""21"" y=""17"" width=""50"" height=""49"" />
					            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					          </imageView>
					          <label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" text=""8:12 PM 9/24/12"" lineBreakMode=""tailTruncation"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" id=""IrT-Ep-Xhd"">
					            <rect key=""frame"" x=""92"" y=""16"" width=""242"" height=""21"" />
					            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					            <fontDescription key=""fontDescription"" name=""HelveticaNeue-Medium"" family=""Helvetica Neue"" pointSize=""17"" />
					            <color key=""textColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					            <color key=""highlightedColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					          </label>
					          <label opaque=""NO"" clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""left"" text=""Short caption for the photo, to make sure it looks right."" lineBreakMode=""tailTruncation"" numberOfLines=""0"" baselineAdjustment=""alignBaselines"" adjustsFontSizeToFit=""NO"" id=""V8F-cA-hr3"">
					            <rect key=""frame"" x=""92"" y=""45"" width=""242"" height=""29"" />
					            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					            <fontDescription key=""fontDescription"" name=""HelveticaNeue-Medium"" family=""Helvetica Neue"" pointSize=""12"" />
					            <color key=""textColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					            <color key=""highlightedColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
					          </label>
					        </subviews>
					        <color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite"" />
					      </view>
					    </tableViewCell>
					  </prototypes>
					</tableView>");
			}
		}

		public static XElement TableView_StaticCells {
			get {
				return XElement.Parse (@"
					<tableView clipsSubviews=""YES"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""static"" style=""plain"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""dKv-tI-Cuo"">
						<rect key=""frame"" x=""80"" y=""62"" width=""160"" height=""230""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
						<sections>
							<tableViewSection headerTitle=""Section-1"" id=""hLw-5H-jIa"">
								<cells>
									<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""uPV-dg-MHM"">
										<rect key=""frame"" x=""0.0"" y=""22"" width=""160"" height=""44""/>
										<autoresizingMask key=""autoresizingMask""/>
										<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
											<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
											<autoresizingMask key=""autoresizingMask""/>
											<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
										</view>
									</tableViewCell>
									<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""wjz-G0-lso"">
										<rect key=""frame"" x=""0.0"" y=""66"" width=""160"" height=""44""/>
										<autoresizingMask key=""autoresizingMask""/>
										<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
											<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
											<autoresizingMask key=""autoresizingMask""/>
											<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
										</view>
									</tableViewCell>
								</cells>
							</tableViewSection>
							<tableViewSection headerTitle=""Section-2"" id=""5UL-Zr-Vi7"">
								<cells>
									<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""b9l-dy-DBh"">
										<rect key=""frame"" x=""0.0"" y=""132"" width=""160"" height=""44""/>
										<autoresizingMask key=""autoresizingMask""/>
										<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
											<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
											<autoresizingMask key=""autoresizingMask""/>
											<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
										</view>
									</tableViewCell>
									<tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" id=""kYe-SM-IVu"">
										<rect key=""frame"" x=""0.0"" y=""176"" width=""160"" height=""44""/>
										<autoresizingMask key=""autoresizingMask""/>
										<view key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"">
											<rect key=""frame"" x=""0.0"" y=""0.0"" width=""160"" height=""43""/>
											<autoresizingMask key=""autoresizingMask""/>
											<color key=""backgroundColor"" white=""0.0"" alpha=""0.0"" colorSpace=""calibratedWhite""/>
										</view>
									</tableViewCell>
								</cells>
							</tableViewSection>
						</sections>
					</tableView>");
			}
		}

		public static XElement TableView_WithHeaderAndFooter {
			get { return XElement.Parse (@"
					<tableView clipsSubviews=""YES"" contentMode=""scaleToFill"" fixedFrame=""YES"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" separatorStyle=""default"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""Q56-jn-Zug"">
						<rect key=""frame"" x=""44"" y=""112"" width=""232"" height=""250""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
						<searchBar key=""tableHeaderView"" contentMode=""redraw"" barStyle=""black"" searchBarStyle=""prominent"" prompt=""Prompt Text"" placeholder=""Placeholder Text"" showsSearchResultsButton=""YES"" showsCancelButton=""YES"" id=""H8o-d8-hNl"">
							<rect key=""frame"" x=""0.0"" y=""0.0"" width=""232"" height=""75""/>
							<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxY=""YES""/>
							<textInputTraits key=""textInputTraits""/>
						</searchBar>
						<view key=""tableFooterView"" contentMode=""scaleToFill"" id=""gma-aB-WYC"">
							<rect key=""frame"" x=""0.0"" y=""365"" width=""232"" height=""44""/>
							<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
							<color key=""backgroundColor"" white=""0.0"" alpha=""1"" colorSpace=""calibratedWhite""/>
						</view>
					</tableView>");
			}
		}

		internal static XElement TableView_CustomRowHeight {
			get {
				return XElement.Parse (@"
					<tableView key=""view"" opaque=""NO"" clipsSubviews=""YES"" clearsContextBeforeDrawing=""NO"" contentMode=""scaleToFill"" alwaysBounceVertical=""YES"" dataMode=""prototypes"" style=""plain"" separatorStyle=""default"" rowHeight=""44"" sectionHeaderHeight=""22"" sectionFooterHeight=""22"" id=""fNy-EY-YBO"">
					    <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
					    <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
					    <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
					    <prototypes>
					        <tableViewCell contentMode=""scaleToFill"" selectionStyle=""blue"" hidesAccessoryWhenEditing=""NO"" indentationLevel=""1"" indentationWidth=""0.0"" rowHeight=""64"" id=""AZ7-IJ-cs0"">
					            <rect key=""frame"" x=""0.0"" y=""22"" width=""320"" height=""44""/>
					            <autoresizingMask key=""autoresizingMask""/>
					            <tableViewCellContentView key=""contentView"" opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""center"" tableViewCell=""AZ7-IJ-cs0"" id=""xKe-tj-olp"">
					                <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""43""/>
					                <autoresizingMask key=""autoresizingMask""/>
					            </tableViewCellContentView>
					        </tableViewCell>
					    </prototypes>
					    <connections>
					        <outlet property=""dataSource"" destination=""epz-9Y-hug"" id=""UgD-G4-ljc""/>
					        <outlet property=""delegate"" destination=""epz-9Y-hug"" id=""K8r-T0-3Z8""/>
					    </connections>
					</tableView>");
			}
		}

//		public static XElement TextField {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UITextField"); }
//		}
//
//		public static XElement TextView {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UITextView"); }
//		}
//
		public static XElement TextView_WithFont {
			get {
				return XElement.Parse (@"
					<textView opaque=""NO"" clipsSubviews=""YES"" multipleTouchEnabled=""YES"" userInteractionEnabled=""NO"" contentMode=""scaleToFill"" showsHorizontalScrollIndicator=""NO"" delaysContentTouches=""NO"" canCancelContentTouches=""NO"" minimumZoomScale=""0.0"" maximumZoomScale=""0.0"" bouncesZoom=""NO"" editable=""NO"" text=""Loaded by the first view controller — an instance of FirstViewController — specified in the app delegate."" textAlignment=""center"" id=""21"">
						<rect key=""frame"" x=""20"" y=""181"" width=""280"" height=""88""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMaxY=""YES""/>
						<fontDescription key=""fontDescription"" type=""system"" pointSize=""26""/>
						<textInputTraits key=""textInputTraits""/>
					</textView>");
			}
		}

//		public static XElement TextView_WithDetectorTypes {
//			get {
//				var textView = TextView;
//				textView.Add (XmlSnippets.DataDectorTypes);
//				return textView;
//			}
//		}

//		internal static XElement Toolbar {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIToolbar"); }
//		}

//		public static XElement Toolbar_NoChildren {
//			get {
//				var toolbar = Toolbar;
//				toolbar.Element ("items").Remove ();
//				return toolbar;
//			}
//		}

		public static XElement Toolbar_WithItems {
			get {
				return XElement.Parse (@"
					<toolbar opaque=""NO"" clearsContextBeforeDrawing=""NO"" contentMode=""scaleToFill"" id=""BGO-Ej-rEf"">
						<rect key=""frame"" x=""0.0"" y=""416"" width=""320"" height=""44""/>
						<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" flexibleMinY=""YES""/>
						<items>
							<barButtonItem title=""Item 1"" style=""plain"" id=""hUf-7Y-hkd""/>
							<barButtonItem title=""Item 2"" style=""done"" id=""lSZ-kF-cdT""/>
							<barButtonItem style=""plain"" id=""dfb-Jm-b5F"">
								<segmentedControl key=""customView"" opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""left"" contentVerticalAlignment=""top"" segmentControlStyle=""bar"" selectedSegmentIndex=""0"" id=""d39-Ed-Ac5"">
									<rect key=""frame"" x=""145"" y=""8"" width=""157"" height=""30""/>
									<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
									<segments>
										<segment title=""First""/>
										<segment title=""Second""/>
									</segments>
								</segmentedControl>
							</barButtonItem>
						</items>
					</toolbar>");
			}
		}

//		internal static XElement View {
//			get { return Catalog.MainCatalog.GetXElementForClass ("UIView"); }
//		}

		public static XElement ViewWithConstraints {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""as3"">
						<rect key=""frame"" x=""0.0"" y=""416"" width=""320"" height=""44""/>
						<subviews>
							<view id=""wxE-Te-ljI"" translatesAutoresizingMaskIntoConstraints=""NO"">
								<color key=""backgroundColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
							</view>
							<view id=""cGt-0A-EBT"" translatesAutoresizingMaskIntoConstraints=""NO"">
							</view>
						</subviews>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
						<constraints>
							<constraint firstItem=""cGt-0A-EBT"" firstAttribute=""leading"" secondItem=""as3"" secondAttribute=""leading"" type=""default"" multiplier=""2"" id=""1Vc-tl-co6""/>
							<constraint firstItem=""wxE-Te-ljI"" firstAttribute=""leading"" secondItem=""as3"" secondAttribute=""leading"" constant=""70"" type=""user"" id=""WEe-at-EIO""/>
							<constraint firstItem=""cGt-0A-EBT"" firstAttribute=""top"" secondItem=""as3"" secondAttribute=""top"" type=""user"" id=""e8F-kl-lYW""/>
							<constraint firstItem=""wxE-Te-ljI"" firstAttribute=""top"" secondItem=""cGt-0A-EBT"" secondAttribute=""bottom"" constant=""70"" type=""user"" id=""rHZ-17-V2O""/>
							<constraint firstItem=""cGt-0A-EBT"" firstAttribute=""trailing"" secondItem=""as3"" secondAttribute=""trailing"" type=""default"" id=""y9q-cE-JqH""/>
						</constraints>
					</view>");
			}
		}

		internal static XElement ViewWithConflictingConstraints_Layout {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""2"">
						<rect key=""frame"" x=""0.0"" y=""20"" width=""320"" height=""460"" />
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite"" />
						<subviews>
							<button opaque=""NO"" contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""5"">
								<state key=""normal"" title=""Button"">
									<color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite"" />
								</state>
								<constraints>
									<constraint firstAttribute=""width"" constant=""46"" type=""default"" id=""8"" />
								</constraints>
							</button>
							<button opaque=""NO"" contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""9"">
								<state key=""normal"" title=""Button"">
									<color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite"" />
								</state>
								<constraints>
									<constraint firstAttribute=""width"" constant=""46"" type=""default"" id=""12"" />
									<constraint firstAttribute=""height"" constant=""30"" type=""user"" id=""13"" />
								</constraints>
							</button>
						</subviews>
						<constraints>
							<constraint id=""6"" firstItem=""2"" firstAttribute=""trailing"" secondItem=""5"" secondAttribute=""trailing"" constant=""98"" type=""user"" />
							<constraint id=""7"" firstItem=""5"" firstAttribute=""top"" secondItem=""2"" secondAttribute=""top"" constant=""20"" type=""user"" />
							<constraint id=""10"" firstItem=""2"" firstAttribute=""trailing"" secondItem=""9"" secondAttribute=""trailing"" constant=""36"" type=""user"" />
							<constraint id=""11"" firstItem=""9"" firstAttribute=""top"" secondItem=""2"" secondAttribute=""top"" constant=""67"" type=""user"" />
							<constraint firstItem=""9"" firstAttribute=""leading"" secondItem=""5"" secondAttribute=""trailing"" type=""user"" constant=""17"" id=""14"" />
						</constraints>
					</view>
				");
			}
		}

		internal static XElement ViewWithConflictingConstraints_Autoresizing {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""2"">
					<rect key=""frame"" x=""0.0"" y=""20"" width=""320"" height=""460"" />
					<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
					<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite"" />
					<subviews>
					  <button opaque=""NO"" contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""YES"" id=""5"">
					    <state key=""normal"" title=""Button"">
					      <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite"" />
					    </state>
					    <constraints>
					      <constraint firstAttribute=""width"" constant=""46"" type=""default"" id=""8"" />
					    </constraints>
					  </button>
					</subviews>
					<constraints>
					  <constraint id=""6"" firstItem=""2"" firstAttribute=""trailing"" secondItem=""5"" secondAttribute=""trailing"" constant=""98"" type=""user"" />
					  <constraint id=""7"" firstItem=""5"" firstAttribute=""top"" secondItem=""2"" secondAttribute=""top"" constant=""20"" type=""user"" />
					</constraints>
					</view>
				");
			}
		}

		internal static XElement ViewWithConflictingConstraints_OverConstrainedButton {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""2"">
			            <rect key=""frame"" x=""0.0"" y=""20"" width=""320"" height=""460"" />
			            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES"" />
			            <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite"" />
			            <subviews>
			              <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" id=""5"" translatesAutoresizingMaskIntoConstraints=""NO"">
			                <fontDescription key=""fontDescription"" type=""boldSystem"" pointSize=""15"" />
			                <state key=""normal"" title=""Button"">
			                  <color key=""titleColor"" red=""0.196078"" green=""0.3098"" blue=""0.52157"" alpha=""1"" colorSpace=""calibratedRGB"" />
			                  <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite"" />
			                </state>
			                <state key=""highlighted"">
			                  <color key=""titleColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite"" />
			                </state>
			                <constraints>
			                  <constraint firstAttribute=""width"" constant=""73"" type=""user"" id=""8"" />
			                  <constraint firstAttribute=""height"" constant=""37"" type=""default"" id=""9"" />
			                </constraints>
			              </button>
			            </subviews>
			            <constraints>
			              <constraint id=""6"" firstItem=""5"" firstAttribute=""leading"" secondItem=""2"" secondAttribute=""leading"" constant=""41"" type=""user"" />
			              <constraint id=""7"" firstItem=""5"" firstAttribute=""top"" secondItem=""2"" secondAttribute=""top"" constant=""34"" type=""default"" />
			              <constraint firstItem=""5"" firstAttribute=""trailing"" secondItem=""2"" secondAttribute=""trailing"" type=""user"" constant=""-207"" id=""10"" />
			            </constraints>
			          </view>
				");
			}
		}

		public static XElement ViewWithSimulatedStatusBar {
			get {
				return XElement.Parse (@"
					<view contentMode=""scaleToFill"" id=""Zeh-5O-CPG"">
				        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""200"" height=""100""/>
				        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
				        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
				        <simulatedStatusBarMetrics key=""simulatedStatusBarMetrics""/>
				        <freeformSimulatedSizeMetrics key=""simulatedDestinationMetrics""/>
				    </view>");
			}
		}

		internal static XElement ViewWithSymbolicConstraints {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""3"">
						<rect key=""frame"" x=""0.0"" y=""20"" width=""320"" height=""460""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<subviews>
							<textField opaque=""NO"" clipsSubviews=""YES"" contentMode=""scaleToFill"" contentHorizontalAlignment=""left"" contentVerticalAlignment=""center"" text=""Text Field"" borderStyle=""roundedRect"" minimumFontSize=""17"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""Gmm-uJ-L0K"">
								<constraints>
									<constraint firstAttribute=""width"" constant=""175"" id=""46""/>
								</constraints>
								<fontDescription key=""fontDescription"" type=""system"" pointSize=""14""/>
								<textInputTraits key=""textInputTraits"" secureTextEntry=""YES""/>
							</textField>
                        </subviews>
						<constraints>
							<constraint firstItem=""Gmm-uJ-L0K"" firstAttribute=""top"" secondItem=""3"" secondAttribute=""top"" constant=""44"" symbolic=""YES"" type=""user"" id=""Grg-bO-AXU""/>
							<constraint firstItem=""Gmm-uJ-L0K"" firstAttribute=""leading"" secondItem=""Z8P-fN-htZ"" secondAttribute=""leading"" constant=""40"" symbolic=""YES"" type=""user"" id=""Qr9-hM-nRA""/>
						</constraints>
					</view>");
			}
		}

		public static XElement ViewInsideView {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""F2C-NU-vCn"">
						<rect key=""frame"" x=""0.0"" y=""0"" width=""200"" height=""250""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<subviews>
							<view contentMode=""scaleToFill"" id=""VVD-z3-rwl"">
								<rect key=""frame"" x=""10"" y=""15"" width=""20"" height=""25""/>
								<autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
								<color key=""backgroundColor"" white=""0.0"" alpha=""1"" colorSpace=""calibratedWhite""/>
							</view>
						</subviews>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
					</view>");
			}
		}

		// Taken from a real Xcode storyboard, apparently dangling constraints are just ignored by the system
		public static XElement ViewWithUnresolvableConstraint {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""jzd-2F-HUu"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""480""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <textView clipsSubviews=""YES"" multipleTouchEnabled=""YES"" contentMode=""scaleToFill"" editable=""NO"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""crp-C2-wYG"">
                                <rect key=""frame"" x=""8"" y=""8"" width=""304"" height=""459""/>
                                <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
                                <color key=""backgroundColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB""/>
                                <string key=""text"">Lorem ipsum dolor sit er elit lamet, consectetaur cillium adipisicing pecu, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Nam liber te conscient to factor tum poen legum odioque civiuda.</string>
                                <fontDescription key=""fontDescription"" type=""system"" pointSize=""26""/>
                                <textInputTraits key=""textInputTraits"" autocapitalizationType=""sentences""/>
                            </textView>
                            <imageView contentMode=""scaleToFill"" horizontalHuggingPriority=""251"" verticalHuggingPriority=""251"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""JC2-uD-aC6"">
                                <rect key=""frame"" x=""170"" y=""330"" width=""150"" height=""150""/>
                                <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
                                <constraints>
                                    <constraint firstAttribute=""height"" constant=""150"" id=""8dy-dd-iF8""/>
                                    <constraint firstAttribute=""width"" constant=""150"" id=""lq4-Xp-BnC""/>
                                </constraints>
                            </imageView>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                        <constraints>
                            <constraint firstAttribute=""trailing"" secondItem=""JC2-uD-aC6"" secondAttribute=""trailing"" id=""H1B-Ib-AIt""/>
                            <constraint firstItem=""crp-C2-wYG"" firstAttribute=""top"" secondItem=""jzd-2F-HUu"" secondAttribute=""top"" constant=""8"" id=""HKl-Og-gff""/>
                            <constraint firstItem=""crp-C2-wYG"" firstAttribute=""leading"" secondItem=""jzd-2F-HUu"" secondAttribute=""leading"" constant=""8"" id=""LHH-xc-40Y""/>
                            <constraint firstItem=""crp-C2-wYG"" firstAttribute=""centerX"" secondItem=""jzd-2F-HUu"" secondAttribute=""centerX"" id=""LT7-Re-W9W""/>
                            <constraint firstAttribute=""bottom"" secondItem=""JC2-uD-aC6"" secondAttribute=""bottom"" id=""TAQ-zn-GUd""/>
                            <constraint firstItem=""fpo-eO-2Y5"" firstAttribute=""top"" secondItem=""crp-C2-wYG"" secondAttribute=""bottom"" constant=""13"" id=""mMX-8V-CAw""/>
                        </constraints>
                    </view>");
			}
		}

		internal static XElement ViewWithFullyConstrainedButton {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""0F8-mW-sfe"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""egv-q7-5xT"">
                                <rect key=""frame"" x=""31"" y=""20"" width=""46"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <constraints>
                                    <constraint firstAttribute=""height"" constant=""30"" id=""3UR-ke-szl""/>
                                    <constraint firstAttribute=""width"" constant=""46"" id=""B2h-L8-QBf""/>
                                </constraints>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                        <constraints>
                            <constraint firstItem=""egv-q7-5xT"" firstAttribute=""leading"" secondItem=""0F8-mW-sfe"" secondAttribute=""leading"" constant=""31"" id=""LIg-N3-66R""/>
                            <constraint firstItem=""egv-q7-5xT"" firstAttribute=""top"" secondItem=""0F8-mW-sfe"" secondAttribute=""top"" constant=""20"" id=""PYV-c4-oXy""/>
                        </constraints>
                    </view>");
			}
		}

		internal static XElement ViewWithFullyConstrainedButton_OtherView {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""MMQ-IT-qOo"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" misplaced=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""3"">
                                <rect key=""frame"" x=""20"" y=""301"" width=""280"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <fontDescription key=""fontDescription"" type=""system"" pointSize=""17""/>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                            <label clipsSubviews=""YES"" userInteractionEnabled=""NO"" contentMode=""scaleToFill"" text=""Hello World!"" textAlignment=""center"" lineBreakMode=""tailTruncation"" minimumFontSize=""10"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""Lei-5M-9Gs"">
                                <rect key=""frame"" x=""20"" y=""276"" width=""280"" height=""17""/>
                                <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                <fontDescription key=""fontDescription"" type=""system"" size=""system""/>
                                <color key=""textColor"" cocoaTouchSystemColor=""darkTextColor""/>
                                <nil key=""highlightedColor""/>
                            </label>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                        <constraints>
                            <constraint firstItem=""3"" firstAttribute=""width"" secondItem=""Lei-5M-9Gs"" secondAttribute=""width"" id=""4""/>
                            <constraint firstItem=""3"" firstAttribute=""centerX"" secondItem=""MMQ-IT-qOo"" secondAttribute=""centerX"" id=""16""/>
                            <constraint firstItem=""3"" firstAttribute=""top"" secondItem=""Lei-5M-9Gs"" secondAttribute=""bottom"" constant=""8"" symbolic=""YES"" id=""17""/>
                            <constraint firstItem=""Lei-5M-9Gs"" firstAttribute=""leading"" secondItem=""MMQ-IT-qOo"" secondAttribute=""leading"" constant=""20"" symbolic=""YES"" id=""62x-JV-TTJ""/>
                            <constraint firstItem=""Lei-5M-9Gs"" firstAttribute=""centerY"" secondItem=""MMQ-IT-qOo"" secondAttribute=""centerY"" id=""JzS-HC-Rnl""/>
                            <constraint firstAttribute=""trailing"" secondItem=""Lei-5M-9Gs"" secondAttribute=""trailing"" constant=""20"" symbolic=""YES"" id=""pXB-RP-Zz6""/>
                        </constraints>
                    </view>");
			}
		}

		internal static XElement ViewWithFullyConstrainedButton_WithIntrinsic {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""0F8-mW-sfe"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""egv-q7-5xT"">
                                <rect key=""frame"" x=""31"" y=""20"" width=""46"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                        <constraints>
                            <constraint firstItem=""egv-q7-5xT"" firstAttribute=""leading"" secondItem=""0F8-mW-sfe"" secondAttribute=""leading"" constant=""31"" id=""LIg-N3-66R""/>
                            <constraint firstItem=""egv-q7-5xT"" firstAttribute=""top"" secondItem=""0F8-mW-sfe"" secondAttribute=""top"" constant=""20"" id=""PYV-c4-oXy""/>
                        </constraints>
                    </view>");
			}
		}

		internal static XElement ViewWithUnderConstrainedButton {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""0F8-mW-sfe"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""egv-q7-5xT"">
                                <rect key=""frame"" x=""31"" y=""20"" width=""46"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <constraints>
                                    <constraint firstAttribute=""height"" constant=""30"" id=""3UR-ke-szl""/>
                                    <constraint firstAttribute=""width"" constant=""46"" id=""B2h-L8-QBf""/>
                                </constraints>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                        <constraints>
                            <constraint firstItem=""egv-q7-5xT"" firstAttribute=""leading"" secondItem=""0F8-mW-sfe"" secondAttribute=""leading"" constant=""31"" id=""LIg-N3-66R""/>
                        </constraints>
                    </view>");
			}
		}

		internal static XElement ViewWithUnderConstrainedButton2 {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""0F8-mW-sfe"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""egv-q7-5xT"">
                                <rect key=""frame"" x=""31"" y=""20"" width=""46"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <constraints>
                                    <constraint firstAttribute=""height"" constant=""30"" id=""3UR-ke-szl""/>
                                    <constraint firstAttribute=""width"" constant=""46"" id=""B2h-L8-QBf""/>
                                </constraints>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                    </view>");
			}
		}

		internal static XElement ViewWithUnconstrainedButton {
			get {
				return XElement.Parse (@"<view key=""view"" contentMode=""scaleToFill"" id=""0F8-mW-sfe"">
                        <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
                        <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                        <subviews>
                            <button opaque=""NO"" contentMode=""scaleToFill"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""egv-q7-5xT"">
                                <rect key=""frame"" x=""31"" y=""20"" width=""46"" height=""30""/>
                                <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
                                <state key=""normal"" title=""Button"">
                                    <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
                                </state>
                            </button>
                        </subviews>
                        <color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
                    </view>");
			}
		}

		internal static XElement ViewWithConstrainedViewWithButton {
			get {
				return XElement.Parse (@"
					<view key=""view"" contentMode=""scaleToFill"" id=""cxq-f7-zT7"">
						<rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
						<autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
						<subviews>
							<view contentMode=""scaleToFill"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""fMD-Uq-zph"">
							    <rect key=""frame"" x=""51"" y=""84"" width=""205"" height=""339""/>
							    <autoresizingMask key=""autoresizingMask"" widthSizable=""YES"" heightSizable=""YES""/>
							    <subviews>
							        <button opaque=""NO"" contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""center"" contentVerticalAlignment=""center"" buttonType=""roundedRect"" lineBreakMode=""middleTruncation"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""rIn-Ja-dnX"">
							            <rect key=""frame"" x=""66"" y=""54"" width=""46"" height=""30""/>
							            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
							            <state key=""normal"" title=""Button"">
							                <color key=""titleShadowColor"" white=""0.5"" alpha=""1"" colorSpace=""calibratedWhite""/>
							            </state>
							        </button>
							    </subviews>
							    <color key=""backgroundColor"" red=""1"" green=""0.072409503939999995"" blue=""0.12470865239999999"" alpha=""1"" colorSpace=""calibratedRGB""/>
							    <constraints>
							        <constraint firstAttribute=""width"" constant=""205"" id=""1tA-aq-lNL""/>
							        <constraint firstAttribute=""height"" constant=""339"" id=""4gY-Bv-gsg""/>
							    </constraints>
							</view>
						</subviews>
						<color key=""backgroundColor"" white=""1"" alpha=""1"" colorSpace=""custom"" customColorSpace=""calibratedWhite""/>
						<constraints>
						    <constraint firstItem=""fMD-Uq-zph"" firstAttribute=""leading"" secondItem=""cxq-f7-zT7"" secondAttribute=""leading"" constant=""51"" id=""jpS-zo-wtS""/>
						    <constraint firstItem=""fMD-Uq-zph"" firstAttribute=""top"" secondItem=""qvb-fV-4eC"" secondAttribute=""bottom"" constant=""64"" id=""oKV-qs-uiu""/>
						</constraints>
					</view>
				");
			}
		}

		public static XElement WebviewWithConstraints {
			get {
				return XElement.Parse (@"
				<webView contentMode=""scaleToFill"" id=""abc"" translatesAutoresizingMaskIntoConstraints=""NO"">
					  <rect key=""frame"" x=""0.0"" y=""0.0"" width=""100"" height=""200""/>
					  <color key=""backgroundColor"" red=""1"" green=""1"" blue=""1"" alpha=""1"" colorSpace=""calibratedRGB"" />
					  <constraints>
						<constraint firstAttribute=""width"" constant=""100"" type=""default"" id=""def"" />
						<constraint firstAttribute=""height"" constant=""200"" type=""default"" id=""hij"" />
					  </constraints>
					</webView>");
			}
		}

//		internal static XElement Window {
//			get { return Catalog.XibCatalog.GetXElementForClass ("UIWindow"); }
//		}
//
		public static XElement WindowWithSegmentedControl {
			get {
				return XElement.Parse (@"
			        <window opaque=""NO"" clearsContextBeforeDrawing=""NO"" contentMode=""scaleToFill"" id=""ss0-8c-fbr"">
			            <rect key=""frame"" x=""0.0"" y=""0.0"" width=""320"" height=""568""/>
			            <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
			            <subviews>
			                <segmentedControl opaque=""NO"" contentMode=""scaleToFill"" fixedFrame=""YES"" contentHorizontalAlignment=""left"" contentVerticalAlignment=""top"" segmentControlStyle=""plain"" selectedSegmentIndex=""0"" translatesAutoresizingMaskIntoConstraints=""NO"" id=""WE9-hQ-0qZ"">
			                    <rect key=""frame"" x=""99"" y=""270"" width=""123"" height=""29""/>
			                    <autoresizingMask key=""autoresizingMask"" flexibleMaxX=""YES"" flexibleMaxY=""YES""/>
			                    <segments>
			                        <segment title=""First""/>
			                        <segment title=""Second""/>
			                    </segments>
			                </segmentedControl>
			            </subviews>
			            <color key=""backgroundColor"" red=""0.0"" green=""1"" blue=""0.0"" alpha=""1"" colorSpace=""calibratedRGB""/>
			            <simulatedStatusBarMetrics key=""simulatedStatusBarMetrics""/>
			            <simulatedScreenMetrics key=""simulatedDestinationMetrics"" type=""retina4""/>
			        </window>");
			}
		}
	}
}