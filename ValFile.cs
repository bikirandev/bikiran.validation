using System;
using Microsoft.AspNetCore.Http;

#nullable enable

namespace Bikiran.Validation
{
    /// <summary>
    /// Provides file validation methods for various file type scenarios
    /// </summary>
    public class ValFile
    {
        /// <summary>
        /// Validates an image file against format and size requirements
        /// </summary>
        /// <param name="attachment">File to validate (nullable IFormFile)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. File existence (non-null and non-empty)
        /// 2. File size ≤ 1MB
        /// 3. MIME type must be image/jpeg, image/png, or image/svg+xml
        /// Note: Validation based on ContentType header rather than file extension
        /// </remarks>
        public static ValidateStatus IsValidImageFile(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 1000000)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 1 MB" };
            }

            if (attachment.ContentType != "image/jpeg" && attachment.ContentType != "image/png" && attachment.ContentType != "image/svg+xml")
            {
                return new ValidateStatus { Error = true, Message = title + " should be in jpeg, png or svg format" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates document files against format and size requirements
        /// </summary>
        /// <param name="attachment">File to validate (nullable IFormFile)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. File existence (non-null and non-empty)
        /// 2. File size ≤ 1MB
        /// 3. Allowed formats: PDF, DOC, DOCX, JPEG, PNG
        /// Supported MIME types:
        /// - application/pdf
        /// - application/msword
        /// - application/vnd.openxmlformats-officedocument.wordprocessingml.document
        /// - image/jpeg
        /// - image/png
        /// </remarks>
        public static ValidateStatus IsValidDocFormat(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 1000000)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 1 MB" };
            }

            // image/*, .pdf, .doc, .docx
            if (attachment.ContentType != "application/pdf" && attachment.ContentType != "application/msword" && attachment.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document" && attachment.ContentType != "image/jpeg" && attachment.ContentType != "image/png")
            {
                return new ValidateStatus { Error = true, Message = title + " should be in pdf, doc, docx, jpeg or png format" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates document and media files against extended format and size requirements
        /// </summary>
        /// <param name="attachment">File to validate (nullable IFormFile)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. File existence (non-null and non-empty)
        /// 2. File size ≤ 100MB
        /// 3. Allowed formats:
        ///    - Documents: PDF, DOC, DOCX, JPEG, PNG
        ///    - Video: MP4, AVI, WMV, MOV, 3GP, 3G2, OGG, WEBM
        ///    - Audio: MPEG, MP4, OGG, WAV, WEBM
        /// Note: Error message currently doesn't reflect all allowed media types
        /// </remarks>
        public static ValidateStatus IsValidDocAndMediaFormat(IFormFile? attachment, string title)
        {
            if (attachment == null)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (attachment.Length > 100000000) // 100000000 to Mb = 100
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 100 MB" };
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
                return new ValidateStatus { Error = true, Message = title + " should be in pdf, doc, docx, jpeg or png format" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        /// <summary>
        /// Validates Excel files (XLSX format) against format and size requirements
        /// </summary>
        /// <param name="xlsxFile">File to validate (nullable IFormFile)</param>
        /// <param name="title">Field name to use in error messages</param>
        /// <returns><see cref="ValidateStatus"/> object containing validation result</returns>
        /// <remarks>
        /// Validation checks:
        /// 1. File existence (non-null and non-empty)
        /// 2. File size ≤ 1MB
        /// 3. Strict MIME type validation for application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        /// Note: Specifically validates modern Excel format (XLSX) only
        /// </remarks>
        public static ValidateStatus IsValidXlsxFormat(IFormFile? xlsxFile, string title)
        {
            if (xlsxFile == null)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (xlsxFile.Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please select " + title };
            }

            if (xlsxFile.Length > 1000000)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum 1 MB" };
            }

            if (xlsxFile.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                return new ValidateStatus { Error = true, Message = title + " should be in xlsx format" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
