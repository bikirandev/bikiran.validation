using System;
using Microsoft.AspNetCore.Http;

namespace Bikiran.Validation
{
    public class ValFile
    {
        public static StatusObj IsValidImageFile(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 1000000)
            {
                return new StatusObj { Error = true, Message = title + " should be maximum 1 MB" };
            }

            if (attachment.ContentType != "image/jpeg" && attachment.ContentType != "image/png" && attachment.ContentType != "image/svg+xml")
            {
                return new StatusObj { Error = true, Message = title + " should be in jpeg, png or svg format" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsValidDocFormat(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 1000000)
            {
                return new StatusObj { Error = true, Message = title + " should be maximum 1 MB" };
            }

            // image/*, .pdf, .doc, .docx
            if (attachment.ContentType != "application/pdf" && attachment.ContentType != "application/msword" && attachment.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document" && attachment.ContentType != "image/jpeg" && attachment.ContentType != "image/png")
            {
                return new StatusObj { Error = true, Message = title + " should be in pdf, doc, docx, jpeg or png format" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }


        public static StatusObj IsValidDocAndMediaFormat(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 100000000) // 100000000 to Mb = 100
            {
                return new StatusObj { Error = true, Message = title + " should be maximum 100 MB" };
            }

            // image/*, .pdf, .doc, .docx
            if (
                attachment.ContentType != "application/pdf"
                && attachment.ContentType != "application/msword"
                && attachment.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                && attachment.ContentType != "image/jpeg"
                && attachment.ContentType != "image/png"
                && attachment.ContentType != "video/mp4"
                && attachment.ContentType != "video/x-msvideo"
                && attachment.ContentType != "video/x-ms-wmv"
                && attachment.ContentType != "video/quicktime"
                // && attachment.ContentType != "video/x-flv"
                && attachment.ContentType != "video/3gpp"
                && attachment.ContentType != "video/3gpp2"
                && attachment.ContentType != "video/ogg"
                && attachment.ContentType != "video/webm"
                && attachment.ContentType != "audio/mpeg"
                && attachment.ContentType != "audio/mp4"
                && attachment.ContentType != "audio/ogg"
                && attachment.ContentType != "audio/wav"
                && attachment.ContentType != "audio/webm"
            )
            {
                return new StatusObj { Error = true, Message = title + " should be in pdf, doc, docx, jpeg or png format" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsValidXlsxFormat(IFormFile? xlsxFile, string title)
        {
            if (xlsxFile == null)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (xlsxFile.Length == 0)
            {
                return new StatusObj { Error = true, Message = "Please select " + title };
            }

            if (xlsxFile.Length > 1000000)
            {
                return new StatusObj { Error = true, Message = title + " should be maximum 1 MB" };
            }

            if (xlsxFile.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                return new StatusObj { Error = true, Message = title + " should be in xlsx format" };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }
    }
}
