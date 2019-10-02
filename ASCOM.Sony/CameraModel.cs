﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ASCOM.Utilities;

namespace ASCOM.Sony
{
    public class ShutterSpeed
    {
        public double DurationSeconds { get; private set; }
        public string Name { get; private set; }
        public ShutterSpeed(string name, double durationSeconds)
        {
            Name = name;
            DurationSeconds = durationSeconds;
        }
    }

    public class SensorSize
    {
        ///// <summary>
        ///// Total sensor width in pixels (including reserved sensor areas)
        ///// </summary>
        //public ushort RawWidth { get; set; }
        ///// <summary>
        ///// Total sensor height in pixels (including reserved sensor areas)
        ///// </summary>
        //public ushort RawHeight { get; set; }

        /// <summary>
        /// Usable sensor width in pixels
        /// </summary>
        public ushort FrameWidth { get; set; }

        /// <summary>
        /// Usable sensor height in pixels
        /// </summary>
        public ushort FrameHeight { get; set; }

        /// <summary>
        /// Camera crop width (used for JPG files)
        /// </summary>
        public ushort CropWidth { get; set; }
        /// <summary>
        /// Camera crop height (used for JPG files)
        /// </summary>
        public ushort CropHeight { get; set; }

        public ushort GetReadoutWidth(ImageFormat imageFormat)
        {
            switch (imageFormat)
            {
                case ImageFormat.CFA:
                case ImageFormat.Debayered:
                    return FrameWidth;
                case ImageFormat.JPG:
                    return CropWidth;
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageFormat), imageFormat, null);
            }
        }

        public ushort GetReadoutHeight(ImageFormat imageFormat)
        {
            switch (imageFormat)
            {
                case ImageFormat.CFA:
                case ImageFormat.Debayered:
                    return FrameHeight;
                case ImageFormat.JPG:
                    return CropHeight;
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageFormat), imageFormat, null);
            }
        }

    }

    public class CameraModel
    {
        public string ID { get; private set; }
        public string Name { get; private set; }

        public string SensorName { get; private set; }
        public SensorSize SensorSize { get; private set; }
        
        public double PixelSize { get; private set; }

        public double ExposureMin { get; private set; }

        public double ExposureMax { get; private set; }
        
        public double[] Exposures { get; private set; }

        public short[] Gains { get; private set; }

        public ShutterSpeed[] ShutterSpeeds { get; private set; }
        
        public double ElectronsPerADU { get; set; }
        public double ExposureResolution { get; set; }
        public double FullWellCapacity { get; set; }

        private static CameraModel _sltA99
        {
            get
            {
               return new CameraModel()
                {
                    ID="SLTA99",
                    Name="Sony SLT-A99",
                    SensorName= "IMX157",
                    SensorSize = new SensorSize()
                    {
                        //RawWidth = 6048,
                        //RawHeight = 4024,
                        FrameWidth = 6018,
                        FrameHeight = 4024,
                        CropWidth = 6000,
                        CropHeight = 4000
                    },
                    PixelSize=5.93,
                    ExposureMin = 1.0 / 8000,
                    ExposureMax = 3600,
                    Exposures = new[] { 1.0/8000,},
                    Gains = new short [] {50,64,80,100,125,160,200,250,320,400,500,640,800,1000,1250,1600,2000,2500,3200,4000,5000,6400,8000,10000,12800,16000,20000,25600},
                    ShutterSpeeds = new []
                    {
                        new ShutterSpeed("1/8000",1.0/8000),
                        new ShutterSpeed("1/6400", 1.0/6400), 
                        new ShutterSpeed("1/5000", 1.0/5000), 
                        new ShutterSpeed("1/4000", 1.0/4000), 
                        new ShutterSpeed("1/3200", 1.0/3200), 
                        new ShutterSpeed("1/2500", 1.0/2500), 
                        new ShutterSpeed("1/2000",1.0/2000), 
                        new ShutterSpeed("1/1600",1.0/1600), 
                        new ShutterSpeed("1/1250", 1.0/1250), 
                        new ShutterSpeed("1/1000",1.0/1000), 
                        new ShutterSpeed("1/800",1.0/800), 
                        new ShutterSpeed("1/640",1.0/640), 
                        new ShutterSpeed("1/500",1.0/500), 
                        new ShutterSpeed("1/400",1.0/400), 
                        new ShutterSpeed("1/320", 1.0/320), 
                        new ShutterSpeed("1/250",1.0/250),
                        new ShutterSpeed("1/200",1.0/200), 
                        new ShutterSpeed("1/160",1.0/160), 
                        new ShutterSpeed("1/125",1.0/250), 
                        new ShutterSpeed("1/80",1.0/80), 
                        new ShutterSpeed("1/60", 1.0/60), 
                        new ShutterSpeed("1/50", durationSeconds:1.0/50),
                        new ShutterSpeed("1/40", durationSeconds:1.0/40),
                        new ShutterSpeed("1/30", durationSeconds:1.0/30),
                        new ShutterSpeed("1/25", durationSeconds:1.0/25),
                        new ShutterSpeed("1/20", durationSeconds:1.0/20),
                        new ShutterSpeed("1/15", durationSeconds:1.0/15),
                        new ShutterSpeed("1/13", durationSeconds:1.0/13),
                        new ShutterSpeed("1/10", durationSeconds:1.0/10),
                        new ShutterSpeed("1/8", durationSeconds:1.0/8),
                        new ShutterSpeed("1/6", durationSeconds:1.0/6),
                        new ShutterSpeed("1/5", durationSeconds:1.0/5),
                        new ShutterSpeed("1/4", durationSeconds:1.0/4),
                        new ShutterSpeed("1/3", durationSeconds:1.0/3),
                        new ShutterSpeed("0.4\"", durationSeconds:0.4),
                        new ShutterSpeed("0.5\"", durationSeconds:0.5),
                        new ShutterSpeed("0.6\"", durationSeconds:0.6),
                        new ShutterSpeed("0.8\"", durationSeconds:0.8),
                        new ShutterSpeed("1\"", durationSeconds:1.0),
                        new ShutterSpeed("1.3\"", durationSeconds:1.3),
                        new ShutterSpeed("1.6\"", durationSeconds:1.6),
                        new ShutterSpeed("BULB", durationSeconds:2),
                    },
                    ElectronsPerADU = 1,
                    ExposureResolution = 0.1,
                    FullWellCapacity = short.MaxValue
                };
            }
        }

        public static CameraModel[] Models = new[] { _sltA99 };
    }
}