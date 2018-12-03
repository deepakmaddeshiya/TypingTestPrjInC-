using System.ComponentModel;

namespace TypingTest
{
   public class PropertyClass
    {
        //Properties Declaration      
        [DefaultValue(0)]
        public string SampleText { get; set; }
        [DefaultValue(0)]
        public int Mistakes { get; set; }
        public double ErrorPercentage { get; set; }
        [DefaultValue(0)]
        public int NumberOfSeconds { get; set; }
        [DefaultValue(0)]
        public int NumberOfWords { get; set; }
        [DefaultValue(0)]
        public double TypingSpeed { get; set; }
    }
}
