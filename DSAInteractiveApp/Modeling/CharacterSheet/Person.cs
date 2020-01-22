using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DSAInteractiveApp.Modeling.Calendar;
using Newtonsoft.Json;

namespace DSAInteractiveApp.Modeling.CharacterSheet
{
    public class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Birthplace { get; set; }
        public AventurianDate Birthday { get; set; }
        public AventurianDate CurrentDate { get; set; }
        [JsonIgnore]
        public int Age { get => (CurrentDate - Birthday).Years; }
        public string Sex { get; set; }
        public string Species { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Culture { get; set; }
        public string Profession { get; set; }
        public string Title { get; set; }
        public string SocialStatus { get; set; }
        public string Characteristics { get; set; }
        public string AdditionalInformation { get; set; }
    }
}