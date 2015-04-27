using System;

using Foundation;
using AppKit;
using CoreAnimation;
using CoreGraphics;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scattered
{
    public partial class MainWindowController : NSWindowController
    {
		#region - Member Variables / Properties
		CALayer textContainer;
		CATextLayer textLayer;
		Random random;
		
		public new MainWindow Window
		{
			get { return (MainWindow)base.Window; }
		}
		#endregion

		#region - Constructors
        public MainWindowController(IntPtr handle) : base(handle)
        {
			Initialize();
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
			Initialize();
        }

        public MainWindowController() : base("MainWindow")
        {
			Initialize();
        }

		void Initialize()
		{
			random = new Random((int)DateTime.Now.Ticks);
		}

		#endregion

		#region - Lifecycle
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

			View.Layer = new CALayer();
			View.WantsLayer = true;

			textContainer = new CALayer();
			textContainer.AnchorPoint = CGPoint.Empty;
			textContainer.Position = new CGPoint(10, 10);
			textContainer.ZPosition = 100;
			textContainer.BackgroundColor = NSColor.Black.CGColor;
			textContainer.BorderColor = NSColor.White.CGColor;
			textContainer.BorderWidth = 2;
			textContainer.CornerRadius = 15;
			textContainer.ShadowOpacity = 0.5f;
			View.Layer.AddSublayer(textContainer);

			textLayer = new CATextLayer();
			textLayer.AnchorPoint = CGPoint.Empty;
			textLayer.Position = new CGPoint(10, 6);
			textLayer.ZPosition = 100;
			textLayer.FontSize = 24;
			textLayer.ForegroundColor = NSColor.White.CGColor;
			textContainer.AddSublayer(textLayer);

			// Rely on setText: to set the above layers' bounds: [self setText:@"Loading..."];
			SetText("Loading...", textLayer);


			var dirs = NSSearchPath.GetDirectories(NSSearchPathDirectory.LibraryDirectory, NSSearchPathDomain.Local);
			foreach (string dir in dirs) {
				Console.WriteLine("Dir: {0}", dir);
			}
			string libDir = dirs[0];
			string desktopPicturesDir = Path.Combine(libDir, "Desktop Pictures");
			Console.WriteLine("DP Dir: {0}", desktopPicturesDir);
			AddImagesFromFolderUrl(desktopPicturesDir);

			repositionButton.Layer.ZPosition = 100;
			durationTextField.Layer.ZPosition = 100;
        }
		#endregion

		#region - Methods
		partial void repositionImages (NSObject sender)
		{
			foreach (CALayer layer in View.Layer.Sublayers) {
				if (layer == textContainer || layer == repositionButton.Layer || layer == durationTextField.Layer)
					continue;
				CGRect imageBounds = layer.Bounds;
				nfloat MaxX = (nfloat)random.Next((int)Math.Floor(imageBounds.Width/2), (int)Math.Floor(layer.SuperLayer.Bounds.GetMaxX() - imageBounds.Width/2));
				nfloat MaxY = (nfloat)random.Next((int)Math.Floor(imageBounds.Height/2), (int)Math.Floor(layer.SuperLayer.Bounds.GetMaxY() - imageBounds.Height/2));
				CGPoint randomPoint = new CGPoint(MaxX, MaxY);

				CAMediaTimingFunction tf = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
				nfloat duration = durationTextField.FloatValue;
				CABasicAnimation posAnim = CABasicAnimation.FromKeyPath("position");
				posAnim.From = NSValue.FromCGPoint(layer.Position);
				posAnim.Duration = duration;
				posAnim.TimingFunction = tf;

				layer.Actions = NSDictionary.FromObjectsAndKeys(new NSObject[]{posAnim}, new NSObject[]{new NSString("position")});

				CATransaction.Begin();
				layer.Position = randomPoint;
				CATransaction.Commit();
			}
		}

		//- (void)addImagesFromFolderURL:(NSURL *)url;
		void AddImagesFromFolderUrl(string folderUrl)
		{
			// need to change... this should not take a parameter. Should return a time interval (TimeSpan or NSTimeInterval (not bound)) since reference date.
			DateTime t0 = DateTime.Now; 
			IEnumerable<string> dir = Directory.EnumerateFiles(folderUrl);

			nint allowedFiles = 10;
			foreach (string file in dir) {
				if (!file.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
					continue;
				NSImage image = new NSImage(file);
				if (image == null)
					continue;

				allowedFiles--;
				if (allowedFiles <0)
					break;
				Console.WriteLine("File: {0}", file);

				NSImage thumbImage = ThumbImageFromImage(image);

				PresentImage(thumbImage, file.Substring(file.LastIndexOf("/")+1));
				SetText(String.Format("{0}", DateTime.Now - t0), textLayer);
			}
		}

		//- (NSImage *)thumbImageFromImage:(NSImage *)image;
		NSImage ThumbImageFromImage(NSImage image)
		{
			nfloat targetHeight = 200.0f;
			CGSize imageSize = image.Size;
			CGSize smallerSize = new CGSize(targetHeight * imageSize.Width / imageSize.Height, targetHeight);

			NSImage smallerImage = new NSImage(smallerSize);

			smallerImage.LockFocus();
			image.DrawInRect(new CGRect(0,0,smallerSize.Width, smallerSize.Height), CGRect.Empty, NSCompositingOperation.Copy, 1.0f);
			smallerImage.UnlockFocus();

			return smallerImage;
		}

		//- (void)presentImage:(NSImage *)image;
		void PresentImage(NSImage image, string filename)
		{
			CGRect superLayerBounds = View.Layer.Bounds;
			CGPoint center = new CGPoint(superLayerBounds.GetMidX(), superLayerBounds.GetMidY());

			CGRect imageBounds = new CGRect(0, 0, image.Size.Width, image.Size.Height);

			nfloat MaxX = (nfloat)random.Next((int)Math.Floor(imageBounds.Width/2), (int)Math.Floor(superLayerBounds.GetMaxX() - imageBounds.Width/2));//(superLayerBounds.GetMaxX() - imageBounds.Width/2) * random.NextDouble();
			nfloat MaxY = (nfloat)random.Next((int)Math.Floor(imageBounds.Height/2), (int)Math.Floor(superLayerBounds.GetMaxY() - imageBounds.Height/2)); //(superLayerBounds.GetMaxY() - imageBounds.Height/2) * random.NextDouble();
			CGPoint randomPoint = new CGPoint(MaxX, MaxY);

			CAMediaTimingFunction tf = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);

			CABasicAnimation posAnim = CABasicAnimation.FromKeyPath("position");
			posAnim.From = NSValue.FromCGPoint(center);
			posAnim.Duration = 2;
			posAnim.TimingFunction = tf;

			CABasicAnimation bdsAnim = CABasicAnimation.FromKeyPath("bounds");
			bdsAnim.From = NSValue.FromCGRect(CGRect.Empty);
			bdsAnim.Duration = 2;
			bdsAnim.TimingFunction = tf;

			CALayer layer = new CALayer();
			layer.Contents = image.CGImage;
			layer.Position = center;
			layer.Actions = NSDictionary.FromObjectsAndKeys(new NSObject[]{posAnim, bdsAnim}, new NSObject[]{new NSString("position"), new NSString("bounds")});

			CATextLayer fileNameLayer = new CATextLayer();
			fileNameLayer.FontSize = 24;
			fileNameLayer.ForegroundColor = NSColor.White.CGColor;
			layer.AddSublayer(fileNameLayer);
			SetText(" " + filename + " ", fileNameLayer);
			fileNameLayer.Position = CGPoint.Empty;
			fileNameLayer.AnchorPoint = CGPoint.Empty;
			fileNameLayer.ShadowColor = NSColor.Black.CGColor;
			fileNameLayer.ShadowOffset = new CGSize(5, 5);
			fileNameLayer.ShadowOpacity = 1.0f;
			fileNameLayer.ShadowRadius = 0.0f;
			fileNameLayer.BorderColor = NSColor.White.CGColor;
			fileNameLayer.BorderWidth = 1.0f;

			CATransaction.Begin();
			View.Layer.AddSublayer(layer);
			layer.Position = randomPoint;
			layer.Bounds = imageBounds;
			CATransaction.Commit();
		}

		//- (void)setText:(NSString *)text;
		void SetText(string text, CATextLayer tl)
		{
			NSFont font = NSFont.SystemFontOfSize(tl.FontSize);
			NSDictionary attrs = NSDictionary.FromObjectsAndKeys(new NSObject[]{font}, new NSObject[]{NSStringAttributeKey.Font});
			CGSize size = text.StringSize(attrs);
			// Ensure that the sixze is in whole numbers:
			size.Width = (nfloat)Math.Ceiling(size.Width);
			size.Height = (nfloat)Math.Ceiling(size.Height);
			tl.Bounds = new CGRect(0, 0, size.Width, size.Height);
			if (tl.SuperLayer !=null)
				tl.SuperLayer.Bounds = new CGRect(0, 0, size.Width + 16, size.Height + 20);

			tl.String = text;
		}
		#endregion
    }
}
