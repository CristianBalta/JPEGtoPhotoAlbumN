using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoPDF
{
    enum AppearanceType { Portrait, Landscape, Magic }
     class Appearance
    {
        private AppearanceType type { get; set; }

        private Format format { get; set; }
        public String specialCond = "";

        private float[] dimensions;

        
        private int imgNumber { get; set; }
        private int heightRatio { get; set; }

        public Appearance(AppearanceType appearanceType, Format format, int imgNumber)
        {
            this.type = appearanceType;
            this.imgNumber = imgNumber;
            this.format = format;


            
            init(type, this.imgNumber);
        }
        public Appearance(AppearanceType appearanceType, Format format, int imgNumber,int nrLandscape, int nrPortrait)
        {
            
            this.imgNumber = imgNumber;
            this.format = format;



            init2(this.imgNumber, nrLandscape, nrPortrait);
        }

        public float [] getDimensions()
        {
            return dimensions;
        }

        public int getImgNumber()
        {
            return imgNumber;
        }
        public AppearanceType getAppearanceType()
        {
            return type;
        }

        public int getHeightRatio()
        {
            return heightRatio;
        }

        public void init(AppearanceType appearanceType, int imgNumber)
        {
            if (imgNumber == 1 )
            {
                this.dimensions = new float[] {1};
                this.heightRatio = 1;
                return;
            }

            if (imgNumber == 4 && ((appearanceType==AppearanceType.Landscape)||(appearanceType == AppearanceType.Portrait)))
            {
                this.dimensions = new float[] { 1, 1 };
                this.heightRatio = 2;
                return;
            }

            if(appearanceType == AppearanceType.Portrait && imgNumber == 6)
            {
                this.dimensions = new float[] { 1, 1, 1 };
                this.heightRatio = 2;
                return;
            }
            if (appearanceType == AppearanceType.Portrait && imgNumber == 3)
            {
                this.dimensions = new float[] { 1, 1, 1 };
                this.heightRatio = 1;
                return;
            }

            if (appearanceType == AppearanceType.Landscape && imgNumber == 6)
            {
                this.dimensions = new float[] {1, 1};
                this.heightRatio = 3;
                return;
            }

            if (appearanceType == AppearanceType.Landscape && imgNumber == 3)
            {
                this.dimensions = new float[] {1};
                this.heightRatio = 3;
                return;
            }

            if (appearanceType == AppearanceType.Magic && imgNumber == 4 && format.formatValue=="21x30 (cm)")
            {
                this.dimensions = new float[] { 1 };
                this.heightRatio = 4;
                return;
            }

            if (appearanceType == AppearanceType.Magic && imgNumber == 6 && format.formatValue == "21x30 (cm)")
            {
                this.dimensions = new float[] { 1 };
                this.heightRatio = 6;
                return;
            }

            if (appearanceType == AppearanceType.Magic && format.formatValue == "21x15 (cm)")
            {
                this.dimensions = new float[] {1, 1, 1, 1};
                this.heightRatio = 1;
                return;
            }
        }
        public void init2( int imgNumber, int nrLandscape,int nrPortrait)
        {
            Console.WriteLine(format.formatValue);
            if (format.formatValue== "21x15 (cm)" && imgNumber==4 && nrLandscape ==0 && nrPortrait == 4)
            {
                
                this.dimensions = new float[] {1,1,1,1,1};
                this.heightRatio = 2;
                this.specialCond = "21x15_4P0L";
            }

            if (format.formatValue == "21x15 (cm)" && imgNumber == 4 && nrLandscape == 1 && nrPortrait == 3)
            {
                Console.WriteLine("3 portrete 1 landscape");
                this.dimensions = new float[] {2,2};
                this.heightRatio = 2;
                this.specialCond = "21x15_3P1L";
            }

            if (format.formatValue == "21x15 (cm)" && imgNumber == 4 && nrLandscape == 2 && nrPortrait == 2)
            {
                Console.WriteLine("2 portrete 2 landscape");
                this.dimensions = new float[] { 1, 1 };
                this.heightRatio = 2;
                this.specialCond = "21x15_2P2L";
            }


            if (format.formatValue == "21x15 (cm)" && imgNumber == 4 && nrLandscape == 3 && nrPortrait == 1)
            {
                Console.WriteLine("2 portrete 2 landscape");
                this.dimensions = new float[] { 1, 1 };
                this.heightRatio = 2;
                this.specialCond = "21x15_1P3L";
            }

            if (format.formatValue == "21x15 (cm)" && imgNumber == 4 && nrLandscape == 4 && nrPortrait == 0)
            {
                Console.WriteLine("2 portrete 2 landscape");
                this.dimensions = new float[] { 1, 1 };
                this.heightRatio = 2;
                this.specialCond = "21x15_0P4L";
            }
        }
    }
}
