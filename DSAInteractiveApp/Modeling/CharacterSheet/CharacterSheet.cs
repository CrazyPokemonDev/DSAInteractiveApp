﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace DSAInteractiveApp.Modeling.CharacterSheet
{
    public class CharacterSheet
    {
        [JsonProperty(Required = Required.Always)]
        public Person Person { get; set; } = new Person();
    }
}