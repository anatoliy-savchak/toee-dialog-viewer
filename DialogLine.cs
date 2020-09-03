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
	[XmlType(TypeName = "line")]
	[XmlRootAttribute("line", Namespace = "http://www.co8.org/xsd/v1/dialog-line100", IsNullable = false)]

	public class DialogLine
	{
		private int key = 0;
		private string txt;
		private string txtFemale;
		private int minIQ = 0;
		private string test;
		private int answerKey = -1;
		private string effect;
		private int fileLine = -1;

		[XmlAttribute("key")]
		public int Key { get => key; set => key = value; }
		[XmlElementAttribute(ElementName = "text")]
		public string Txt { get => txt; set => txt = value; }
		[XmlElementAttribute(ElementName = "text-female")]
		public string TxtFemale { get => txtFemale; set => txtFemale = value; }
		[XmlAttribute("min-iq"), DefaultValue((int)0)]
		public int MinIQ { get => minIQ; set => minIQ = value; }
		[XmlElementAttribute(ElementName = "test")]
		public string Test { get => test; set => test = value; }
		[XmlAttribute("answer-key"), DefaultValue((int)-1)]
		public int AnswerKey { get => answerKey; set => answerKey = value; }
		[XmlElementAttribute(ElementName = "effect")]
		public string Effect { get => effect; set => effect = value; }

		[XmlIgnore()]
		public bool IsPCLine { get => this.minIQ != 0; }
		[XmlAttribute("file-line"), DefaultValue((int)-1)]
		public int FileLine { get => fileLine; set => fileLine = value; }

		public bool TxtSpecified { get => !String.IsNullOrEmpty(txt); }
		public bool TxtFemaleSpecified { get => !String.IsNullOrEmpty(txtFemale); }
		public bool TestSpecified { get => !String.IsNullOrEmpty(test); }
		public bool EffectSpecified { get => !String.IsNullOrEmpty(effect); }

		public string ToDlgLine()
		{
			string sMinIQ =( MinIQ != 0) ? $"{MinIQ}" : null;
			string sAnswerKey = (AnswerKey != -1) ? $"{AnswerKey}" : null;
			return $"{{{Key}}}{{{Txt}}}{{{TxtFemale}}}{{{sMinIQ}}}{{{Test}}}{{{sAnswerKey}}}{{{Effect}}}";
		}
	}
}
