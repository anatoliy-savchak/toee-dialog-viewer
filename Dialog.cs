using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;

namespace DialogViewer
{
	[Serializable]
	[XmlType(TypeName = "dialog")]
	[XmlRootAttribute("dialog", Namespace = "http://www.co8.org/xsd/v1/dialog100", IsNullable = false)]

	public class Dialog
	{
		private Dictionary<int, DialogLine> linesByKey = new Dictionary<int, DialogLine>();

		[XmlIgnore()]
		public Dictionary<int, DialogLine> LinesByKey => linesByKey;

		//[XmlElementAttribute(ElementName ="lines", Form = System.Xml.Schema.XmlSchemaForm.)]
		public DialogLine[] lines {
			get { return linesByKey.Values.ToArray(); }
			set
			{
				linesByKey.Clear();
				if (value == null) return;
				foreach(DialogLine line in value)
				{
					if (!linesByKey.ContainsKey(line.Key))
					{
						linesByKey.Add(line.Key, line);
					}
				}
			}
		}

		public int GetKeyIndex(int key)
        {
			if (lines != null)
				for (int i = 0; i < lines.Length; i++)
					if (lines[i].Key == key) return i;
			return -1;
        }
	}
}
