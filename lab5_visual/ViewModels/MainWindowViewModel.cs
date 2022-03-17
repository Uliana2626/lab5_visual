using System;
using System.Text.RegularExpressions;
using ReactiveUI;


namespace lab5_visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text;
        string regExp;
        string result;
        public string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }

        public string Regex
        {
            get => regExp;
            set => regExp = value;
        }

        public string Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }

        public string Regex_Result() => FindRegexInText(text, Regex);

        public static string FindRegexInText(string Text, string CurrentRegex)
        {
            if (CurrentRegex == String.Empty || CurrentRegex == null)
            {
                return "Exception";
            }

            string Result = "";

            Regex regex = new Regex(CurrentRegex);

            MatchCollection match = regex.Matches(Text);

            foreach (Match x in match)
            {
                Result += (x.Value + "\n");
            }

            return Result;
        }
    }
}
