﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelevisionModel.Data;

namespace TelevisionModel
{
    public class TelevisionChannel
    {
        public string LogoPath { get; }
        
        public string Name { get; }

        public TelevisionChannel(string logoPath, string name)
        {
            LogoPath = logoPath;
            Name = name;
        }

        public string BuildLogoUrl()
        {
            return Resources.BaseUrl + LogoPath;
        }
    }
}
