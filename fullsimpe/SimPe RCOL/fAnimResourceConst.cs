using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Zusammenfassung für fAnimResourceConst.
	/// </summary>
	public class fAnimResourceConst : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TabControl tabControl1;
		internal System.Windows.Forms.TabPage tAnimResourceConst;
		private System.Windows.Forms.GroupBox groupBox12;
		internal System.Windows.Forms.TextBox tb_arc_ver;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TreeView tv;
		private System.Windows.Forms.PropertyGrid pg;
		private System.Windows.Forms.LinkLabel llAdd;
		private System.Windows.Forms.LinkLabel llExport;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fAnimResourceConst()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			llAdd.Visible = Helper.WindowsRegistry.HiddenMode;
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tAnimResourceConst = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.tv = new System.Windows.Forms.TreeView();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.tb_arc_ver = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.llAdd = new System.Windows.Forms.LinkLabel();
			this.llExport = new System.Windows.Forms.LinkLabel();
			this.tabControl1.SuspendLayout();
			this.tAnimResourceConst.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tAnimResourceConst);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 288);
			this.tabControl1.TabIndex = 2;
			// 
			// tAnimResourceConst
			// 
			this.tAnimResourceConst.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tAnimResourceConst.Controls.Add(this.llExport);
			this.tAnimResourceConst.Controls.Add(this.groupBox2);
			this.tAnimResourceConst.Controls.Add(this.groupBox12);
			this.tAnimResourceConst.Controls.Add(this.llAdd);
			this.tAnimResourceConst.Location = new System.Drawing.Point(4, 22);
			this.tAnimResourceConst.Name = "tAnimResourceConst";
			this.tAnimResourceConst.Size = new System.Drawing.Size(792, 262);
			this.tAnimResourceConst.TabIndex = 6;
			this.tAnimResourceConst.Text = "AnimResourceConst";
			this.tAnimResourceConst.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.pg);
			this.groupBox2.Controls.Add(this.tv);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(136, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(648, 248);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Content";
			// 
			// pg
			// 
			this.pg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pg.CommandsBackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pg.CommandsVisibleIfAvailable = true;
			this.pg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pg.LargeButtons = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(312, 24);
			this.pg.Name = "pg";
			this.pg.Size = new System.Drawing.Size(328, 216);
			this.pg.TabIndex = 1;
			this.pg.Text = "pg";
			this.pg.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pg.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// tv
			// 
			this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tv.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tv.FullRowSelect = true;
			this.tv.HideSelection = false;
			this.tv.ImageIndex = -1;
			this.tv.Location = new System.Drawing.Point(8, 24);
			this.tv.Name = "tv";
			this.tv.SelectedImageIndex = -1;
			this.tv.Size = new System.Drawing.Size(296, 216);
			this.tv.TabIndex = 0;
			this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.tb_arc_ver);
			this.groupBox12.Controls.Add(this.label30);
			this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox12.Location = new System.Drawing.Point(8, 8);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(120, 72);
			this.groupBox12.TabIndex = 12;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Settings";
			// 
			// tb_arc_ver
			// 
			this.tb_arc_ver.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tb_arc_ver.Location = new System.Drawing.Point(16, 40);
			this.tb_arc_ver.Name = "tb_arc_ver";
			this.tb_arc_ver.Size = new System.Drawing.Size(88, 21);
			this.tb_arc_ver.TabIndex = 24;
			this.tb_arc_ver.Text = "0x00000000";
			this.tb_arc_ver.TextChanged += new System.EventHandler(this.tb_arc_ver_TextChanged);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label30.Location = new System.Drawing.Point(8, 24);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(52, 17);
			this.label30.TabIndex = 23;
			this.label30.Text = "Version:";
			// 
			// llAdd
			// 
			this.llAdd.Enabled = false;
			this.llAdd.Location = new System.Drawing.Point(32, 88);
			this.llAdd.Name = "llAdd";
			this.llAdd.Size = new System.Drawing.Size(96, 16);
			this.llAdd.TabIndex = 2;
			this.llAdd.TabStop = true;
			this.llAdd.Text = "Add Frame";
			this.llAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAdd_LinkClicked);
			// 
			// llExport
			// 
			this.llExport.Enabled = false;
			this.llExport.Location = new System.Drawing.Point(32, 112);
			this.llExport.Name = "llExport";
			this.llExport.Size = new System.Drawing.Size(96, 16);
			this.llExport.TabIndex = 40;
			this.llExport.TabStop = true;
			this.llExport.Text = "Export";
			this.llExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExport_LinkClicked);
			// 
			// fAnimResourceConst
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 350);
			this.Controls.Add(this.tabControl1);
			this.Name = "fAnimResourceConst";
			this.Text = "fAnimResourceConst";
			this.tabControl1.ResumeLayout(false);
			this.tAnimResourceConst.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		

		private void tv_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			llAdd.Enabled = false;
			llExport.Enabled = false;
			pg.SelectedObject = null;
			if (e==null) return;
			if (e.Node==null) return;
			if (e.Node.Tag==null) return;

			pg.SelectedObject = e.Node.Tag;


			if (e.Node.Tag is AnimBlock1) 
			{
				llExport.Enabled = true;
			}
			if (e.Node.Tag.GetType()==typeof(AnimationFrame[])) 
			{
				llAdd.Enabled = true;
				#if DEBUG
				AnimationFrame[] afs = (AnimationFrame[])e.Node.Tag;

				

				System.IO.StreamWriter sw = System.IO.File.CreateText(@"G:\anim.txt");
				try 
				{

					sw.WriteLine(afs.Length.ToString());
					for (int i=0; i<afs.Length; i++) {
						if (afs[0].Type == FrameType.Translation) 
							sw.WriteLine((i+1).ToString()+" "+
								(afs[i].Float_X * -1 * Helper.WindowsRegistry.ImportExportScaleFactor).ToString("N12", System.Globalization.CultureInfo.InvariantCulture)+" "+
								(afs[i].Float_Z * Helper.WindowsRegistry.ImportExportScaleFactor).ToString("N12", System.Globalization.CultureInfo.InvariantCulture)+" "+
								(afs[i].Float_Y * Helper.WindowsRegistry.ImportExportScaleFactor).ToString("N12", System.Globalization.CultureInfo.InvariantCulture));
						else
							sw.WriteLine((i+1).ToString()+" "+
								(afs[i].Float_X * -1 ).ToString("N12", System.Globalization.CultureInfo.InvariantCulture)+" "+
								(afs[i].Float_Z).ToString("N12", System.Globalization.CultureInfo.InvariantCulture)+" "+
								(afs[i].Float_Y).ToString("N12", System.Globalization.CultureInfo.InvariantCulture));
					}			
				} 
				finally
				{
					sw.Close();
					sw.Dispose();
					sw = null;
				}
				#endif
			}

		}

		private void tb_arc_ver_TextChanged(object sender, System.EventArgs e)
		{
			if (this.tb_arc_ver.Tag==null) return;
			try 
			{
				AbstractRcolBlock arb = (AbstractRcolBlock)this.tAnimResourceConst.Tag;

				arb.Version = Convert.ToUInt32(tb_arc_ver.Text, 16);
				arb.Changed = true;
			} 
			catch (Exception) 
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void llAdd_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AnimBlock2 ab2 = (AnimBlock2)tv.SelectedNode.Parent.Tag;
			
			if (ab2.Part3Count!=3) return;

			for (int i=0; i<ab2.Part3Count; i++)
			{
				AnimBlock3 b = ab2.Part3[i];
			
				short[] s = new short[b.AddonTokenSize];
				s[0] = -1;
				b.AddData(s);
			}	
		
			AnimResourceConst arc = (AnimResourceConst)tAnimResourceConst.Tag;
			arc.Refresh();
		}

		private void llExport_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AnimBlock1 ab1 = (AnimBlock1)tv.SelectedNode.Tag;
			GenericRcol gmdc = ab1.FindUsedGMDC(ab1.FindDefiningCRES());
			if (gmdc!=null) 
			{

			}
		}
	}
}
