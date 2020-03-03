using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Windows.Forms;

using iText.Layout;
using iText.Layout.Element;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using UnitValue = iText.Layout.Properties.UnitValue;

using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;

namespace JPEGtoPDF
{
    class Custom
    {


        static void sorting(List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            Image auxImg;
            ImageSelection auxImgSelection;
            bool isSorted = false;
            int N = currentImgs.Count();
            while(!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < N - 1; i++)
                if(currentImgsList.ElementAt(i).format=="portrait" && currentImgsList.ElementAt(i+1).format == "landscape")
                {
                        isSorted = false;

                        auxImg = currentImgs[i]; currentImgs[i] = currentImgs[i + 1]; currentImgs[i + 1] = auxImg;
                        auxImgSelection = currentImgsList[i]; currentImgsList[i] = currentImgsList[i + 1]; currentImgsList[i + 1] = auxImgSelection;
                }
                N--;
                

            }
        }

        public static Table customTable1(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
           


            float[] dim = appearance.getDimensions();
            foreach (float f in appearance.getDimensions())
                Console.WriteLine(f);
            Table table = new Table(dim, false);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            Cell cell1 = new Cell();
            Cell cell2 = new Cell(2,1);
            Cell cell3 = new Cell();




            cell1.Add(currentImgs.ElementAt(0));
            cell1.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell1.SetPaddingTop(40);
            cell1.SetPaddingBottom(40);
            cell1.SetWidth(UnitValue.CreatePercentValue(40f));


            currentImgs.ElementAt(0).SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell2.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell2.SetWidth(UnitValue.CreatePercentValue(20f));

            Cell cell4 = new Cell();
            Cell cell5 = new Cell();

            cell4.SetHeight((table.GetHeight().GetValue() - 4.666f)/2);
            cell4.SetWidth(UnitValue.CreatePercentValue(20f)); 
            
            cell5.SetHeight((table.GetHeight().GetValue() - 4.666f) / 2);
            cell5.SetWidth(UnitValue.CreatePercentValue(20f));


            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));

            cell2.Add(cell4);
            cell2.Add(cell5);

           


            cell3.SetWidth(UnitValue.CreatePercentValue(40f));
            cell3.Add(currentImgs.ElementAt(3));
            cell3.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell3.SetPaddingTop(40);
            cell3.SetPaddingBottom(40);
            cell3.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            currentImgs.ElementAt(3).SetHorizontalAlignment(HorizontalAlignment.LEFT);



            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);


            return table;
        }



        public static Table customTable2(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();
            foreach (float f in appearance.getDimensions())
                Console.WriteLine(f);
            Table table = new Table(dim, false);

            sorting(currentImgsList, currentImgs);


            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

            


            Table table2 = new Table(new float[] { 1,1},false);

            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            //table2.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            table2.UseAllAvailableWidth();
            Cell cell1 = new Cell(2,1);
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()/2));
            cell3.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()/2));
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));

            currentImgs.ElementAt(0).SetHorizontalAlignment(HorizontalAlignment.CENTER);
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            
            
            
            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell5.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 4));
            cell5.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            
            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell6.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 4));
            cell6.Add(currentImgs.ElementAt(2).SetAutoScale(true));

            table2.AddCell(cell5);
            table2.AddCell(cell6);
            
            cell1.Add(cell3);
            cell1.Add(table2);

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell2.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            table.AddCell(cell1);
            table.AddCell(cell2);
            return table;

        }


        public static Table customTable3(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {

            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

            for (int i = 0; i < appearance.getHeightRatio() + 1; i++)
            {
                for (int j = 0; j < appearance.getDimensions().Length; j++)
                {
                    Cell cell = new Cell();

                    cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio() - 4.666f);

                    

                    cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    cell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    
                    table.AddCell(cell);

                }
            }
            if(appearance.specialCond=="21x15_2P2L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));


            }
            if (appearance.specialCond == "21x15_1P3L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(3).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(2).SetAutoScale(true));


            }
            if (appearance.specialCond == "21x15_0P4L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true));


            }

            return table;
        }

        public static Table customTable4(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table1 = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));





            return table;
        }
    }
    }
