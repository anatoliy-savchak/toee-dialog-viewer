using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace DialogViewer
{
	public class DialogFormatterDlg : IFormatter
	{
		private ISurrogateSelector surrogateSelector;
		private SerializationBinder binder;
		private StreamingContext context;

		public ISurrogateSelector SurrogateSelector { get => surrogateSelector; set => surrogateSelector = value; }
		public SerializationBinder Binder { get => binder; set => binder = value; }
		public StreamingContext Context { get => context; set => context = value; }

		public void Serialize(Stream serializationStream, object graph)
		{
			if (!(graph is Dialog))
				throw new ArgumentException();
			Dialog dialog = (Dialog)graph;
			var lines = dialog.lines.OrderBy((d) => $"{d.FileLine:000000} -- {d.Key:000000}");
			int lineIdx = -1;
			using (StreamWriter writer = new StreamWriter(serializationStream, Encoding.ASCII, 1000, true))
			{
				foreach (DialogLine line in lines)
				{
					lineIdx++;
					while (lineIdx < line.FileLine)
					{
						writer.WriteLine();
						lineIdx++;
					}
					string dlgLine = line.ToDlgLine();
					writer.WriteLine(dlgLine);
				}
				//writer.WriteLine(); // backward compatibility
			}
		}

		public object Deserialize(Stream serializationStream)
		{
			List<DialogLine> lines = null;
			using (StreamReader reader = new StreamReader(serializationStream, Encoding.ASCII, true, 1000, true))
			{
				string bracketContent = null;
				int currLine = -1;
				int currLineStart = -1;
				string pendingLine = null;
				bool GetBracketContent(bool start = false)
				{
					bracketContent = null;
					string line = pendingLine;
					while (String.IsNullOrEmpty(line))
					{
						if (reader.EndOfStream) return false;
						line = reader.ReadLine();
						currLine++;
					}
					if (start) currLineStart = currLine;
					int bracketOpen = line.IndexOf('{');
					if (bracketOpen < 0)
					{
						pendingLine = null;
						return false;
					}
					line = line.Substring(bracketOpen + 1);
					int bracketClose = line.IndexOf('}');
					if (bracketClose >= 0)
					{
						bracketContent = line.Substring(0, bracketClose);
						pendingLine = line.Substring(bracketClose + 1);
					}
					else
					{
						while (bracketClose < 0)
						{
							if (reader.EndOfStream) return false;
							string nextline = reader.ReadLine();
							bracketClose = nextline.IndexOf('}');
							currLine++;
							if (bracketClose >= 0)
							{
								bracketContent = line + '\n' + nextline.Substring(0, bracketClose);
								pendingLine = nextline.Substring(bracketClose + 1);
								break;
							}
							else
							{
								line = line + '\n' + nextline;
								pendingLine = null;
							}
						}
					}
					return true;
				};

				lines = new List<DialogLine>();
				while (!reader.EndOfStream)
				{
					if (GetBracketContent(true))
					{
						DialogLine line = new DialogLine();
						if (int.TryParse(bracketContent, out int k))
						{
							line.Key = k;
						} else
						{
							pendingLine = null;
							continue;
						}

						if (!GetBracketContent()) break;
						line.Txt = bracketContent;

						if (!GetBracketContent()) break;
						line.TxtFemale = bracketContent;

						if (!GetBracketContent()) break;
						if (!String.IsNullOrEmpty(bracketContent))
						{
							if (int.TryParse(bracketContent, out int k1))
							{
								line.MinIQ = k1;
							}
							else
							{
								pendingLine = null;
								continue;
							}
						}

						
						if (!GetBracketContent()) break;
						line.Test = bracketContent;

						if (!GetBracketContent()) break;

						if (!String.IsNullOrEmpty(bracketContent))
						{
							if (int.TryParse(bracketContent, out int k2))
							{
								line.AnswerKey = k2;
							}
							else
							{
								pendingLine = null;
								continue;
							}
						}

						if (!GetBracketContent()) break;
						line.Effect = bracketContent;

						line.FileLine = currLineStart;
						lines.Add(line);
					}
				}
			}

			Dialog result = new Dialog();
			result.lines = lines.ToArray();

			return result;
		}

		public static Dialog DeserializeFileDlg(string path)
		{
			using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				DialogFormatterDlg formatterDlg = new DialogFormatterDlg();
				return formatterDlg.Deserialize(stream) as Dialog;
			}
		}
	}
}
