using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ParentNotifyMouse
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[Browsable(true)]
		[Category("Mouse")]
		[Description("Occurs when a child control notifies the form that the mouse has been pressed")]
		public event MouseEventHandler ChildMouseDown;

		private System.ComponentModel.IContainer components;

		private const int WM_PARENTNOTIFY   = 0x0210;

		private const int WM_LBUTTONDOWN    = 0x0201;
		private const int WM_RBUTTONDOWN    = 0x0204;
		private const int WM_MBUTTONDOWN    = 0x0207;
		private const int WM_XBUTTONDOWN    = 0x020B;

		private const ushort XBUTTON1		= 0x0001;
		private const ushort XBUTTON2		= 0x0002;


		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton m_BackButton;
		private System.Windows.Forms.ToolBarButton m_ForwardButton;

		private UserControl CurrentView = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.ChildMouseDown += new MouseEventHandler(Form1_ChildMouseDown);
		}

		#region Disposer
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.m_BackButton = new System.Windows.Forms.ToolBarButton();
			this.m_ForwardButton = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.m_BackButton,
																						this.m_ForwardButton});
			this.toolBar1.ButtonSize = new System.Drawing.Size(65, 24);
			this.toolBar1.Divider = false;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(292, 26);
			this.toolBar1.TabIndex = 6;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.Wrappable = false;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// m_BackButton
			// 
			this.m_BackButton.Enabled = false;
			this.m_BackButton.Text = "Back";
			// 
			// m_ForwardButton
			// 
			this.m_ForwardButton.ImageIndex = 0;
			this.m_ForwardButton.Text = "Forward";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.toolBar1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		protected void OnChildMouseDown( MouseButtons button, int x, int y )
		{
			if ( ChildMouseDown != null )			
				ChildMouseDown( this, new MouseEventArgs( button, 0, x, y, 0 ) );			
		}

		protected override void WndProc(ref Message m)
		{
			if ( m.Msg == WM_PARENTNOTIFY )
			{
				MouseButtons button = MouseButtons.None;

				switch ( LOWORD( m.WParam.ToInt32() ) )
				{
					case WM_LBUTTONDOWN:
						button = MouseButtons.Left;
						break;
					case WM_RBUTTONDOWN:
						button = MouseButtons.Right;
						break;
					case WM_MBUTTONDOWN:
						button = MouseButtons.Middle;
						break;
					case WM_XBUTTONDOWN:
						if ( HIWORD(m.WParam.ToInt32()) == XBUTTON1 )
							button = MouseButtons.XButton1;
						else if ( HIWORD(m.WParam.ToInt32()) == XBUTTON2 )
							button = MouseButtons.XButton2;
						break;
				}

				if ( button != MouseButtons.None )
					OnChildMouseDown( button, LOWORD( m.LParam.ToInt32() ), HIWORD( m.LParam.ToInt32() ) );
			}

			base.WndProc (ref m);
		}

		private ushort LOWORD( int l ){ return (ushort)(l); }
		private ushort HIWORD( int l ){ return (ushort)(((int)(l) >> 16) & 0xFFFF); }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_ChildMouseDown(object sender, MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.XButton1 )
				NavigateToView1();

			else if ( e.Button == MouseButtons.XButton2 )
				NavigateToView2();
		}

		private void NavigateToView1()
		{
			GotoView( typeof( UserControl1 ) );
			m_BackButton.Enabled = false;
			m_ForwardButton.Enabled = true;
		}

		private void NavigateToView2()
		{
			GotoView( typeof( UserControl2 ) );
			m_BackButton.Enabled = true;
			m_ForwardButton.Enabled = false;
		}

		private void GotoView( Type t )
		{
			if ( CurrentView != null && CurrentView.GetType() == t )
				return;

			SuspendLayout();
			Controls.Remove( CurrentView );
			if ( CurrentView != null )
				CurrentView.Dispose();
			CurrentView = (UserControl)System.Activator.CreateInstance( t );
			CurrentView.Dock = DockStyle.Fill;
			Controls.Add( CurrentView );
			ResumeLayout();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Image button = imageList1.Images[0];
			button.RotateFlip( RotateFlipType.Rotate180FlipNone );
			imageList1.Images.Add( button );
			m_BackButton.ImageIndex = 1;

			NavigateToView1();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ( e.Button == m_BackButton )
				NavigateToView1();
			else if ( e.Button == m_ForwardButton )
				NavigateToView2();	
		}

	}
}
