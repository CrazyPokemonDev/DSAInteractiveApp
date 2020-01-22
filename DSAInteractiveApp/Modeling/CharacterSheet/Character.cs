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
    public class Character
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Birthplace { get; set; }
        public AventurianDate Birthday { get; set; }
        public AventurianDate CurrentDate { get; set; }
        [JsonIgnore]
        public int Age { get => (CurrentDate - Birthday).Years; }
    }
}