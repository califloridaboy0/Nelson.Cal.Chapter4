using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;

namespace Nelson.Cal.Chapter4.Pages
{
    [BindProperties]
    public class PerformHTMLElementOperationsModel : PageModel
    {
        /* Upload File constructor and variables */
        private readonly IWebHostEnvironment IWebHostEnvironment;
        public PerformHTMLElementOperationsModel(IWebHostEnvironment IWHE)
        {
            IWebHostEnvironment = IWHE;
        }
        public IFormFile UploadFile { get; set; }


        /* checkbox variables */
        public bool RedChk { get; set; }
        public bool WhiteChk { get; set; }
        public bool BlueChk { get; set; }

        public string RedStyle;
        public string WhiteStyle;
        public string BlueStyle;

        public string MessageStr = "Message: ";
        

        public void OnGet()
        {
        }

        /* checkboxes */

        public void OnPostColor()
        {
           if(RedChk)
            {
                RedStyle = "red";
            }

           if(WhiteChk)
            {
                WhiteStyle = "white";
            }

           if(BlueChk)
            {
                BlueStyle = "blue";
            }
        }

        /* select a date */

        public DateTime DateSlctd { get; set; } = DateTime.Now;
        public string DateLabel;

        public void OnPostDate()
        {
            DateLabel = DateSlctd.ToShortDateString();
            MessageStr += "You chose " + DateLabel;
            
        }


        /* Upload File */

        public void OnPostFile()
        {
           if(UploadFile != null)
            {
                //upload the file
                string strImagesPath = Path.Combine(IWebHostEnvironment.WebRootPath, "images");
                string strFileName = Path.GetFileName(UploadFile.FileName);
                string strFilePath = Path.Combine(strImagesPath, strFileName);
                FileStream objFileStream = new FileStream(strFilePath, FileMode.Create);
                UploadFile.CopyTo(objFileStream);
                objFileStream.Close();
                //set the message
                MessageStr += "File was successfully uploaded";
            } else
            {
                MessageStr += "Please select an image file to upload and try again.";
            }

           // MessageStr = "File was successfully uploaded";
        }

        public string Hidden { get; set; }
        public void OnPostSetHidden()
        {
            Hidden = "Cal";
            MessageStr += "You have revealed " + Hidden;

        }

        public DateTime Month { get; set; } = DateTime.Now;
        public string MonthSlct;

        public void OnPostMonthHndl()
        {
            MonthSlct = Month.ToString("MMMM, yyyy");
            MessageStr += "You chose " + MonthSlct;
        }

        /* US State radio buttons */
        public string UsState { get; set; }

        public void OnPostDispState()
        {
            if(UsState == "Indiana")
            {
                MessageStr += "You chose Indiana.";
            } else if(UsState == "Illinois")
            {
                MessageStr += "You chose Illinois.";
            } else if(UsState == "Florida")
            {
                MessageStr += "You chose Florida";
            } else
            {
                MessageStr = "Please, select a state.";
            }
        }


        /* time selector */
        public DateTime SlctdTime { get; set; } = DateTime.Now;
        public string ShowTime;

        public void OnPostDisplayTime()
        {
            ShowTime = SlctdTime.ToShortTimeString();

            MessageStr += "You chose " + ShowTime;
        }


        /* dropdown menu */
        public string DropColor { get; set; }

        public void OnPostDropdown()
        {
            MessageStr = "You chose ";

            if(DropColor == "R")
            {
                DropColor = "red";
                MessageStr += DropColor + ".";
            } else if(DropColor == "W")
            {
                DropColor = "white";
                MessageStr += DropColor + ".";
            } else if(DropColor == "B")
            {
                DropColor = "blue";
                MessageStr += DropColor + ".";
            }
        }

        public string Text { get; set; }
        public void OnPostFreeText()
        {
            
            if(Text.Length > 0)
            {
                MessageStr = "You successfully entered \"" + Text + "\"";
            } else
            {
                MessageStr = "Please enter at least one character";
            }
        }
    }
}
