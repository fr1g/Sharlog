namespace Sharlog.SharSkript
{
    public class Skript
    {
        public string SkriptName;
        public string SkriptContent;
        public string SkriptDesc;

        private FileInfo _sk;
        private Compiler _compiler;

        public Dictionary<string, object>? localVariables = new();
        public Dictionary<int, string>? EachSentence; // int: the level of spacing; string: inner command that this line of skript will execute.

        public void RunCompile() 
        {
            
            EachSentence = new Dictionary<int, string>();
            var contents = this.SkriptContent.Split('\n');
            foreach (string sk in contents) 
            {
                if (string.IsNullOrEmpty(sk) || sk.StartsWith("#")) continue; // I DONT WANT TO SUPPORT THOSE COMMENTS AFTER A SENTENCE
                var spaceBeforeCount = 0;
                foreach (var inner in sk.ToCharArray()) 
                {
                    if (inner.Equals(' ')) spaceBeforeCount++;
                    else break;
                }
                EachSentence.Add((int)(spaceBeforeCount / 4), _compiler.Compile(sk));
            }

        }
        public Skript(FileInfo sk, Compiler c)
        {
            if (!sk.Name.Split(".")[(sk.Name.Split(".").Length) - 1].Equals("sk") || sk.Name.StartsWith("--"))
            {
                return; // this may prevent while found this file.
            }
            _sk = sk;
            _compiler = c;
            this.SkriptName = sk.Name;
            // this.SkriptContent = ();
            using (StreamReader sr = new(sk.FullName)) 
            {
                while (!sr.EndOfStream) 
                {
                    string? line = sr.ReadLine();
                    if (line is null) continue;
                    else if (line.Contains("@Description")) this.SkriptDesc = line;
                    else this.SkriptDesc = "No Description";
                    this.SkriptContent += line;
                }
                sr.Close();
            }

        }
    }
}
