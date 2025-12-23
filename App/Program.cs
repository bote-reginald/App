// File:Program.cs
using System.Diagnostics;
using System.Media;
using System.Text;

class Program
{
    private static int _count;
    private static int _nextGoalOfLines;
    private static string? _infoText;
    //private static string _in;
    private string _text = "";
    private static string _newline = Environment.NewLine;
    private readonly string _line = "";
    private readonly DateTime _startTime;
    //private readonly Dictionary<string, string> db;

    static async Task Main()
    {
        string _saveText = "C:/DB/__IN-FILE_TEXT-autosave.txt";
        DateTime _startTime;

        try
        {
            _startTime = DateTime.Now;
            // run processing on background thread and get processed lines
            List<string> processedLines = await Task.Run(static () => ReadAndProcessLines("C:/DB/", "__IN-FILE_TEXT", ".txt"));

            StreamWriter streamWriter = new(File.Open(_saveText, FileMode.Create), Encoding.UTF8);

            _count = 0;

            foreach (var line in processedLines)
            {
                _count += 1;

                string xline = DoReplace_Months_Days(line);

                streamWriter.WriteLine(xline);

                if (_count > _nextGoalOfLines)
                {
                    _infoText = _count.ToString() + ": _start;" + _startTime + ";now;" + DateTime.Now + " for reading + checking";
                    Console.WriteLine(_infoText);
                    _nextGoalOfLines += 20000;
                }
            }

            streamWriter.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Debugger.Break();
        }

        // Sound abspielen (benötigt .wav-Datei oder Resource)
        try
        {
            using var player = new SoundPlayer(@"C:\\DB\\sound001.wav");
            player.PlaySync();
            //Console.WriteLine("\nSound abgespielt!");
        }
        catch
        {
            Console.WriteLine("\nSound-Datei nicht gefunden.");
        }

        Console.WriteLine(_newline + "Press ENTER to finish !");
        Console.ReadLine();
    }

    private static string DoReplace_Months_Days(string lineString)
    {
        //_line_string = _in;

        lineString = lineString.Replace(". JAN ", ".01.");
        lineString = lineString.Replace(". FEB ", ".02.");
        lineString = lineString.Replace(". MAR ", ".03.");
        lineString = lineString.Replace(". APR ", ".04.");
        lineString = lineString.Replace(". MAY ", ".05.");
        lineString = lineString.Replace(". JUN ", ".06.");
        lineString = lineString.Replace(". JUL ", ".07.");
        lineString = lineString.Replace(". AUG ", ".08.");
        lineString = lineString.Replace(". SEP ", ".09.");
        lineString = lineString.Replace(". OCT ", ".10.");
        lineString = lineString.Replace(". NOV ", ".11.");
        lineString = lineString.Replace(". DEC ", ".12.");

        lineString = lineString.Replace("\"1.", "\"01.");
        lineString = lineString.Replace("\"2.", "\"02.");
        lineString = lineString.Replace("\"3.", "\"03.");
        lineString = lineString.Replace("\"4.", "\"04.");
        lineString = lineString.Replace("\"5.", "\"05.");
        lineString = lineString.Replace("\"6.", "\"06.");
        lineString = lineString.Replace("\"7.", "\"07.");
        lineString = lineString.Replace("\"8.", "\"08.");
        lineString = lineString.Replace("\"9.", "\"09.");

        return lineString;
    }

#pragma warning disable CA1822 // Mark members as static
    private string DoReplace_DIV(string _line_string)
#pragma warning restore CA1822 // Mark members as static
    {
        //Console.WriteLine(_br);
        //Console.WriteLine("reading= ;" + _line_string);
        //_line_string = _in;
        string _br = " <br>";
        string _newline = Environment.NewLine;

        //_line_string = _line_string.Replace("\"", "");
        _line_string = _line_string.Replace(@"/ Sr.M.", "# Sr.M.");
        _line_string = _line_string.Replace("&gt;", ">");
        _line_string = _line_string.Replace("&Auml;", "Ä");
        _line_string = _line_string.Replace("&auml;", "ä");
        _line_string = _line_string.Replace("&Ouml;", "Ö");
        _line_string = _line_string.Replace("&ouml;", "ö");
        _line_string = _line_string.Replace("&Uuml;", "Ü");
        _line_string = _line_string.Replace("&uuml;", "ü");
        _line_string = _line_string.Replace("&szlig;", "ß");
        //_line_string = _line_string.Replace("&auml;", "ä");
        //_line_string = _line_string.Replace("&ouml;", "ö");
        //_line_string = _line_string.Replace("&uuml;", "ü");
        //_line_string = _line_string.Replace("&szlig;", "ß");
        _line_string = _line_string.Replace("&amp;", "=");
        //_line_string = _line_string.Replace("\",\"", ";");
        //_line_string = _line_string.Replace("\"", "");
        //_line_string = _line_string.Replace("\\", "");
        _line_string = _line_string.Replace("?", "");
        //_line_string = _line_string.Replace("+ ", "& ");
        //_line_string = _line_string.Replace("* ", "");
        _line_string = _line_string.Replace("...", "");


        //_line_string = _line_string.Replace("um.  .", "ABT ");
        //_line_string = _line_string.Replace("ca.  .", "ABT ");
        //_line_string = _line_string.Replace("ca. ", "ABT ");
        //_line_string = _line_string.Replace("ca.", "ABT ");
        //_line_string = _line_string.Replace("in.", "ABT ");
        //_line_string = _line_string.Replace(".  .", "ABT ");
        //_line_string = _line_string.Replace(" .", "ABT ");

        _line_string = _line_string.Replace("Kiening: Genealogie  <h1>", "Kiening: Genealogie  <h1> RR ");
        _line_string = _line_string.Replace("Kiening: Genealogie  <h1> RR RR ", "Kiening: Genealogie  <h1> RR ");
        _line_string = _line_string.Replace("<meta name=\"robots\" content=\"nofollow\">"
            , "<meta name=\"robots\" content=\"nofollow\">\r\n<meta http-equiv=Content-Type content=\"text/html; charset=unicode\">");
        _line_string = _line_string.Replace("<body>", _br + "<body>" + _br);
        _line_string = _line_string.Replace("</title> ", /*_br + */"</title> " + _br);

        _line_string = _line_string.Replace("<a name=\"", "{");
        Console.WriteLine(_newline + "A " + _line_string);


        return _line_string;
    }

    private string DoReplace_aname(string lineString)
    {
        //_line_string = _in;
        string _newline = Environment.NewLine;

        string aname = "{";
        string anameString;
        string _nr;// = "";
        int _length;
        int _length1;
        int _begin = 0;
        if (lineString.Contains(aname))
        {
            //Console.WriteLine(_newline + "A " + _line_string);
            string _introText = lineString.Substring(0, _begin);
            //string errortext; = "";
            int firstblank = 0;
            int secondblankOrEnd;
            int thirdblankOrEnd;

            //_line_string = _line_string.Replace(", ", "");

            if (lineString.Contains('{')) firstblank = lineString.IndexOf('{');

            // SecondBlankOrEnd
            int start = firstblank + 1;
            int stopp = lineString.Length - start - 1;
            if (stopp < 1) { stopp = 0; }
            secondblankOrEnd = lineString.Substring(start, stopp).IndexOf('{');

            anameString = lineString.Substring(firstblank, lineString.Length - start/* - 1*/);
            _length = anameString.IndexOf('"') - 1;

            _nr = lineString.Substring(firstblank + 1, _length);

            // 3rd
            start = firstblank + secondblankOrEnd + 2;
            stopp = lineString.Length - start - 1;
            thirdblankOrEnd = lineString.Substring(start, stopp).IndexOf('{');
            if (thirdblankOrEnd == -1) { thirdblankOrEnd = 0; }

            if (secondblankOrEnd < 2)
                secondblankOrEnd = lineString.Length - 2;

#pragma warning disable CA1845 // Use span-based 'string.Concat'
            lineString = _introText + lineString.Substring(_begin, secondblankOrEnd + 2);
#pragma warning restore CA1845 // Use span-based 'string.Concat'

            lineString = lineString.Replace("{", "  K" + _nr + " <a name=\"");

            //_line_string = _line_string.Replace("_", " ");
            _text = _count + " > "
                + "firstblank =" + firstblank
                + ", =" + secondblankOrEnd
                + ", =" + thirdblankOrEnd + _newline
                + ", " + lineString
                //+ ", " + _line_string
                ;
            //Console.WriteLine(_newline + _text);
            //Console.WriteLine(_newline + _introText);



            //Console.WriteLine("A " + _line_string);
            _length1 = lineString.IndexOf('{');

            if (lineString.Length < _length1)
                anameString = lineString.Substring(1, _length1);

            _length = anameString.IndexOf('"');
            _nr = anameString.Substring(0, _length) ;
            lineString = lineString.Replace("{", "Kxx" + _nr /*+ _br + _newline*/ + " " + aname);

            //_line_string = _line_string + "K" + _nr + _br;
            lineString = lineString.Replace("{", "<a name=\"");
            lineString = lineString.Replace("Kxx", "K");
            Console.WriteLine("B " + lineString);


        }
        return lineString;
    }
    // New: Read and process lines without UI calls
    private static List<string> ReadAndProcessLines(string path, string file, string extension)
    {
        var result = new List<string>();

        //string _nowREAD;
        string infoText;// = _nowREAD;
        infoText = "______________start;" + DateTime.Now + ": starting >> input: " + path + file + extension;
        Console.WriteLine(infoText);
        //AddError("0000000", "INFO", infoText);

        DateTime _startTime = DateTime.Now;
        int lastPeListIndex = 0;

        string fullPath = Path.Combine(path, file + extension);
        if (!File.Exists(fullPath))
        {
            _infoText = "Input-File not found >> " + path + file + extension;
            Console.WriteLine(_infoText);
            //_ = MessageBox.Show("Input-File not found", "BEWARE", MessageBoxButtons.OK);
            //return result;
        }

        //db = new Dictionary<string, string>();

        using (var streamReader = new StreamReader(fullPath, Encoding.UTF8))
        {
            _count = 0;
            _nextGoalOfLines = 10000;
            while (streamReader.Peek() != -1)
            {
                _count++;
                if (_count > _nextGoalOfLines)
                {
                    infoText = _count + ": _start;" + _startTime + ";now;" + DateTime.Now + " for reading + checking";
                    Console.WriteLine(infoText);
                    _nextGoalOfLines += 50000;
                }

                string? line = streamReader.ReadLine();
                if (line == null) continue;

                // perform replacements (reuse existing method)
                line = DoReplace_Months_Days(line);

                string key = _count.ToString();
                //db.Add(key, _line);
                result.Add(line);

                int lastPeListIndex_DONE = lastPeListIndex - 1;
                lastPeListIndex = 1 + lastPeListIndex - 1 + 1;
            }
        }

        infoText = "___________________________________________________start;" + _startTime + ";now;" + DateTime.Now + ";END";
        Console.WriteLine(infoText);
        //AddError("8888888", "INFO", infoText);

        _count = 0;
        _nextGoalOfLines = 20000;

        //_places = new Dictionary<string, int>();

        return result;
    }

}
