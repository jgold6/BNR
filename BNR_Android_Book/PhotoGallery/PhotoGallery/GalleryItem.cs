using System;

namespace PhotoGallery
{
	public class GalleryItem
    {
		public string Id {get; set;}
		public string Caption {get; set;}
		public string Url {get; set;}
		public string Owner {get; set;}
		public string Filename {get; set;}

		public string PhotoPageUrl{
			get {
				return String.Format("http://www.flicker.com/photos/{0}/{1}", Owner, Id);
			}
		}

		public override string ToString()
		{
			return Caption;
		}
    }

	// For deserializing the recent photos XML from Flickr

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class rsp
	{

		private rspPhotos photosField;

		private string statField;

		/// <remarks/>
		public rspPhotos photos
		{
			get
			{
				return this.photosField;
			}
			set
			{
				this.photosField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string stat
		{
			get
			{
				return this.statField;
			}
			set
			{
				this.statField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class rspPhotos
	{

		private rspPhotosPhoto[] photoField;

		private byte pageField;

		private uint pagesField;

		private byte perpageField;

		private uint totalField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("photo")]
		public rspPhotosPhoto[] photo
		{
			get
			{
				return this.photoField;
			}
			set
			{
				this.photoField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte page
		{
			get
			{
				return this.pageField;
			}
			set
			{
				this.pageField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint pages
		{
			get
			{
				return this.pagesField;
			}
			set
			{
				this.pagesField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte perpage
		{
			get
			{
				return this.perpageField;
			}
			set
			{
				this.perpageField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint total
		{
			get
			{
				return this.totalField;
			}
			set
			{
				this.totalField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class rspPhotosPhoto
	{

		private ulong idField;

		private string ownerField;

		private string secretField;

		private ushort serverField;

		private byte farmField;

		private string titleField;

		private byte ispublicField;

		private byte isfriendField;

		private byte isfamilyField;

		private string url_sField;

		private byte height_sField;

		private byte width_sField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ulong id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string owner
		{
			get
			{
				return this.ownerField;
			}
			set
			{
				this.ownerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string secret
		{
			get
			{
				return this.secretField;
			}
			set
			{
				this.secretField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort server
		{
			get
			{
				return this.serverField;
			}
			set
			{
				this.serverField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte farm
		{
			get
			{
				return this.farmField;
			}
			set
			{
				this.farmField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string title
		{
			get
			{
				return this.titleField;
			}
			set
			{
				this.titleField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte ispublic
		{
			get
			{
				return this.ispublicField;
			}
			set
			{
				this.ispublicField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte isfriend
		{
			get
			{
				return this.isfriendField;
			}
			set
			{
				this.isfriendField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte isfamily
		{
			get
			{
				return this.isfamilyField;
			}
			set
			{
				this.isfamilyField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string url_s
		{
			get
			{
				return this.url_sField;
			}
			set
			{
				this.url_sField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte height_s
		{
			get
			{
				return this.height_sField;
			}
			set
			{
				this.height_sField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte width_s
		{
			get
			{
				return this.width_sField;
			}
			set
			{
				this.width_sField = value;
			}
		}
	}
}
		