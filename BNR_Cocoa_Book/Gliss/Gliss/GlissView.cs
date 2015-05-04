using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using OpenGL;
using OpenTK;
using GLKit;
using OpenTK.Graphics.OpenGL;
using CoreGraphics;

namespace Gliss
{
	[Foundation.Register("GlissView")]
	public class GlissView : AppKit.NSOpenGLView
    {
		[Outlet]
		AppKit.NSMatrix sliderMatrix { get; set; }
		float lightX, theta, radius;
		int displayList = 0;
		NSOpenGLContext glContext;

        #region Constructors
        // Called when created from unmanaged code
        public GlissView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public GlissView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Prepare();
        }
        #endregion

		#region - Overrides
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			ChangeParameter(this);
		}

		public override void Reshape()
		{
			base.Reshape();
			Console.WriteLine("Reshaping");

			// Convert up to window space, which is in pixel units
			CGRect baseRect = this.ConvertRectToBase(this.Bounds);

			// Now the result is GL.VIewport()-compatible.
			GL.Viewport(0, 0, (int)baseRect.Size.Width, (int)baseRect.Size.Height);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();

			// Was gluPerspective(60.0, baseRect.Size.Width/baseRect.Size.Height, 0.2, 7)
			//GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);?
			Perspective (60.0, baseRect.Size.Width/baseRect.Size.Height, 0.2, 7);
		}

		public override void DrawRect(CGRect dirtyRect)
		{
			base.DrawRect(dirtyRect);

			// Clear the background
			GL.ClearColor(0.2f, 0.4f, 0.1f, 0.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			// Set the view point
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			// find gluLookAt(radius * Math.Sin(theta), 0, radius * cos(theta), 0, 0, 0, 0, 1, 0);

			// Put the light in place
			float[] lightPosition = {lightX, 1.0f, 3.0f, 0.0f};
			GL.Light(LightName.Light0, LightParameter.Position, lightPosition);

			if (displayList == 0) {
				displayList = GL.GenLists(1);
				GL.NewList(displayList, ListMode.CompileAndExecute);

				// Draw the stuff
				GL.Translate(0, 0, 0);
				// Find the shapes, SolidTorus and SolidCone 

				GL.EndList();
			}
			else {
				GL.CallList(displayList);
			}

			// Flush to screen
			GL.Finish();
		}
		#endregion

		void Prepare()
		{
			Console.WriteLine("Prepare");

			// The GL COntext must be active for these functions to have an effect
			glContext = this.OpenGLContext;
			glContext.MakeCurrentContext();

			// Configure the view
			GL.ShadeModel(ShadingModel.Smooth);
			GL.Enable(EnableCap.Lighting);
			GL.Enable(EnableCap.DepthTest);

			// Add some ambient lighting
			float[] ambient = {0.2f, 0.2f, 0.2f, 1.0f};
			GL.LightModel(LightModelParameter.LightModelAmbient, ambient);

			// Initialize the light
			float[] diffuse = {1.0f, 1.0f, 1.0f, 1.0f};
			GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
			// and switch it on
			GL.Enable((EnableCap)LightName.Light0);

			// Set the properties of the material under ambient light
			float[] mat = {0.1f, 0.1f, 0.7f, 1.0f};
			GL.Material(MaterialFace.Front, MaterialParameter.Ambient, mat);

			GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, mat);
		}

		public static void Perspective (double fovY, double aspectRatio, double front, double back)
		{
			const double DEG2RAD = Math.PI / 180 ; 

			// tangent of half fovY
			double tangent = Math.Tan (fovY / 2 * DEG2RAD);

			// half height of near plane
			double height = front * tangent;

			// half width of near plane
			double width = height * aspectRatio;

			// params: left, right, bottom, top, near, far
			GL.Frustum (-width, width, -height, height, front, back);
		}

		#region - Actions
		[Action ("changeParameter:")]
		void ChangeParameter (Foundation.NSObject sender)
		{
			lightX = sliderMatrix.CellWithTag(0).FloatValue;
			theta = sliderMatrix.CellWithTag(1).FloatValue;
			radius = sliderMatrix.CellWithTag(2).FloatValue;
			NeedsDisplay = true;
		}
		#endregion

		void ReleaseDesignerOutlets ()
		{
			if (sliderMatrix != null) {
				sliderMatrix.Dispose ();
				sliderMatrix = null;
			}
		}
    }
}
