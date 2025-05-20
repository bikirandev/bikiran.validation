# Bikiran.Validation


![NuGet Version](https://img.shields.io/nuget/v/Bikiran.Validation.svg?style=flat-square)
![License](https://img.shields.io/github/license/bikirandev/Bikiran.Validation.svg?style=flat-square)
[![API Docs](https://img.shields.io/badge/docs-API%20Reference-blue.svg)](https://github.com/bikirandev/Bikiran.Validation/wiki)

A comprehensive utility library for .NET development with debugging, API support, and configuration management

## Installation

```bash
dotnet add package Bikiran.Utils
```

A comprehensive validation library for .NET applications providing robust validation utilities for common data types and formats.

## Features

- **20+ Validation Types** (Email, Date, IP, URL, File formats, etc.)
- **Extensible Validation Framework**
- **Customizable Error Messages**
- **Regex-Powered Validation**
- **Null Safety** Handling
- **Optional Field** Support
- **Batch Validation** for collections
- **Cross-Platform** .NET Standard 2.0+ Support

## Installation
## Quick Start
## Available Validators

| Validator Class | Description           | Key Methods                                 |
|-----------------|----------------------|---------------------------------------------|
| ValEmail        | Email validation      | IsValidEmailFormat, IsValidEmailFormatAll   |
| ValDate         | Date formatting       | IsValidDateFormat                           |
| ValUser         | User credentials      | IsValidUserNameFormat, IsValidPasswordFormat|
| ValFile         | File validation       | IsValidImageFile, IsValidDocFormat, IsValidXlsxFormat |
| ValIP           | IP Address validation | IsValidIpFormat, IsValidIpFormatAll         |
| ValURL          | URL validation        | IsValidUrlFormat                            |
| ValString       | String validation     | IsValidString, IsValidLongString            |
| ValNumber       | Numeric validation    | IsValidateInt, IsValidateNumber             |
| ValBoolean      | Boolean checks        | IsEqual, IsTrue, IsFalse                    |
| ValOptions      | Option validation     | IsValidateOptions, IsValidateOptionsAll      |
| ValPath         | Path validation       | IsValidPathPattern                          |
| ValDomain       | Domain validation     | IsValidDomainFormat, IsValidDomainFormatAll  |

## Advanced Usage

### Custom Error Messages
### Batch Validation
### Optional Fields
## Validation Rules Details

### Password Requirements
- 8-32 characters
- 1 uppercase letter
- 1 lowercase letter
- 1 number
- 1 special character

### Username Requirements
- 5-20 characters
- Alphanumeric with .-@
- Starts with letter
- Ends with letter/number

### File Validation
- Images: JPEG, PNG, SVG (max 1MB)
- Documents: PDF, DOC, DOCX (max 1MB)
- Media Files: MP4, AVI, MP3, WAV (max 100MB)

## Contribution

1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## License

Distributed under the MIT License. See [LICENSE](LICENSE) for more information.

## Support

Found a bug? Please open an issue.
