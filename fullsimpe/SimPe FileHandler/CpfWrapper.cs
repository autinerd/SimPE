/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.Xml;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads 
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Cpf
		: AbstractWrapper				//Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
		, IFileWrapper					//This Interface is used when loading a File
		, IFileWrapperSaveExtension		//This Interface (if available) will be used to store a File
		//,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		byte[] id;	
	
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public byte[] Id 
		{
			get { return id; }
		}

		

		/// <summary>
		/// Contains all available Items
		/// </summary>		
		private CpfItem[] items;

		/// <summary>
		/// Returns/Sets the Constants
		/// </summary>
		public CpfItem[] Items
		{
			get { return items;	}			
			set { items = value; }
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Cpf() : base()
		{		
			id = this.FileSignature;
			items = new CpfItem[0];
		}

		/// <summary>
		/// returns the Item with the given Name o rnull if not found
		/// </summary>
		/// <param name="name"></param>
		/// <returns>null or the Item</returns>
		public CpfItem GetItem(string name) 
		{
			foreach (CpfItem item in this.items)
				if (item.Name == name) return item;

			return null;
		}

		/// <summary>
		/// returns the Item with the given Name or null if not found
		/// </summary>
		/// <param name="name"></param>
		/// <returns>the Item</returns>
		public CpfItem GetSaveItem(string name) 
		{
			CpfItem res = GetItem(name);
			if (res==null)	return new CpfItem();
			else return res;
		}
		
		#region IWrapper member
		public override bool CheckVersion(uint version) 
		{
			if ( (version==0009) //0.00
				|| (version==0010) //0.10
				) 
			{
				return true;
			}

			return false;
		}
		#endregion
		
		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.CpfUI(null);
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"CPF Wrapper",
				"Quaxi",
				"---",
				5
				);   
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected void UnserializeXml(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			System.Xml.XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(reader.BaseStream);

			XmlNodeList XMLData = xmlfile.GetElementsByTagName("cGZPropertySetString");
			ArrayList list = new ArrayList();

			//Process all Root Node Entries
			for (int i=0; i<XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);																
												
				foreach (XmlNode subnode in node) 
				{
					CpfItem item = new CpfItem();

					if (subnode.LocalName.Trim().ToLower() == "anyuint32") 
					{
						item.Datatype = Data.MetaData.DataTypes.dtUInteger;
						if (subnode.InnerText.IndexOf("-")!=-1)item.UIntegerValue = (uint)Convert.ToInt32(subnode.InnerText);
						else if (subnode.InnerText.IndexOf("0x")==-1)item.UIntegerValue = Convert.ToUInt32(subnode.InnerText);
						else item.UIntegerValue = Convert.ToUInt32(subnode.InnerText, 16);
					} 
					else if ((subnode.LocalName.Trim().ToLower() == "anyint32") || (subnode.LocalName.Trim().ToLower() == "anysint32"))
					{
						item.Datatype = Data.MetaData.DataTypes.dtInteger;
						if (subnode.InnerText.IndexOf("0x")==-1)item.IntegerValue = Convert.ToInt32(subnode.InnerText);
						else item.IntegerValue = Convert.ToInt32(subnode.InnerText, 16);
					}
					else if (subnode.LocalName.Trim().ToLower() == "anystring") 
					{
						item.Datatype = Data.MetaData.DataTypes.dtString;
						item.StringValue = subnode.InnerText;
					}
					else if (subnode.LocalName.Trim().ToLower() == "anyfloat32") 
					{
						item.Datatype = Data.MetaData.DataTypes.dtSingle;
						item.SingleValue = Convert.ToSingle(subnode.InnerText);
					}
					else if (subnode.LocalName.Trim().ToLower() == "anyboolean") 
					{
						item.Datatype = Data.MetaData.DataTypes.dtBoolean;
						if (subnode.InnerText.Trim().ToLower()=="true") 
						{
							item.BooleanValue = true;
						} 
						else if (subnode.InnerText.Trim().ToLower()=="false") 
						{
							item.BooleanValue = false;
						} 
						else 
						{
							item.BooleanValue = (Convert.ToInt32(subnode.InnerText)!=0);
						}
					} 
					else if  (subnode.LocalName.Trim().ToLower() == "#comment") 
					{
						continue;
					}
					/*else 
					{
						item.Datatype = (Data.MetaData.DataTypes)Convert.ToUInt32(subnode.Attributes["type"].Value, 16);
					}*/

					try 
					{
						item.Name = subnode.Attributes["key"].Value;
						list.Add(item);	
					} 
					catch {}
				}
			}//for i

			items = new CpfItem[list.Count];
			list.CopyTo(items);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			id = reader.ReadBytes(0x06);
			if (id[0]!=0xE0) 
			{
				id = this.FileSignature;
				this.UnserializeXml(reader);
				return;
			}
			items = new CpfItem[reader.ReadUInt32()];

			for(int i=0; i<items.Length; i++)
			{
				items[i] = new CpfItem();
				items[i].Unserialize(reader);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on 
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{			
			writer.Write(id);
			writer.Write((uint)items.Length);

			for(int i=0; i<items.Length; i++)
			{
				items[i].Serialize(writer);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member		
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature
		{
			get
			{
				Byte[] sig = {
								 0xE0,
								 0x50,
								 0xE7,
								 0xCB,
								 0x02,
								 0x00
							 };
				return sig;
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public virtual uint[] AssignableTypes
		{
			get
			{
				uint[] types = {
								   	0xEBCF3E27, //Property Set
									0x0C560F39, //Binary Index
									//0x4C697E5A, //MMAT
									0xEBFEE33F
							   };
			
				return types;
			}
		}

		#endregion		
	}
}
