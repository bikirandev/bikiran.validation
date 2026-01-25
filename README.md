# Bikiran.Validation

![NuGet Version](https://img.shields.io/nuget/v/Bikiran.Validation.svg?style=flat-square)
![License](https://img.shields.io/github/license/bikirandev/Bikiran.Validation.svg?style=flat-square)
[![API Docs](https://img.shields.io/badge/docs-API%20Reference-blue.svg)](https://github.com/bikirandev/Bikiran.Validation/wiki)

A comprehensive validation library for .NET applications providing robust validation utilities for common data types and formats including emails, URLs, IP addresses, user credentials, files, phone numbers, server names, and more.

## Features

- **15+ Validation Types** (Email, Date, IP, URL, File formats, Phone, Server names, etc.)
- **Extensible Validation Framework**
- **Customizable Error Messages**
- **Regex-Powered Validation**
- **Null Safety** Handling
- **Optional Field** Support
- **Batch Validation** for collections
- **Cross-Platform** .NET Standard 2.0+ Support

## Installation

```bash
dotnet add package Bikiran.Validation
```

## Quick Start

```csharp
using Bikiran.Validation;

// Validate an email
var emailResult = ValEmail.IsValidEmailFormat("user@example.com", "Email Address");
if (emailResult.Error)
{
    Console.WriteLine(emailResult.Message); // Display error
}

// Validate a password
var passwordResult = ValUser.IsValidPasswordFormat("SecurePass123!", "Password");
if (!passwordResult.Error)
{
    Console.WriteLine("Password is valid!");
}

// Validate a server name
var serverResult = ValServer.IsValidServerNameFormat("web-server-01", "Server Name");
if (!serverResult.Error)
{
    Console.WriteLine("Server name is valid!");
}
```

## Available Validators

| Validator Class | Description           | Key Methods                                                         |
| --------------- | --------------------- | ------------------------------------------------------------------- |
| ValEmail        | Email validation      | IsValidEmailFormat, IsValidEmailFormatAll                           |
| ValDate         | Date formatting       | IsValidDateFormat                                                   |
| ValUser         | User credentials      | IsCleanUserNameFormat, IsValidUserNameFormat, IsValidPasswordFormat |
| ValFile         | File validation       | IsValidImageFile, IsValidDocFormat, IsValidXlsxFormat               |
| ValIP           | IP Address validation | IsValidIpFormat, IsValidIpFormatAll                                 |
| ValURL          | URL validation        | IsValidUrlFormat                                                    |
| ValString       | String validation     | IsValidString, IsValidLongString                                    |
| ValNumber       | Numeric validation    | IsValidateInt, IsValidateNumber                                     |
| ValBoolean      | Boolean checks        | IsEqual, IsTrue, IsFalse                                            |
| ValOptions      | Option validation     | IsValidateOptions, IsValidateOptionsAll                             |
| ValPath         | Path validation       | IsValidPath                                                         |
| ValDomain       | Domain validation     | IsValidDomainFormat, IsValidDomainFormatAll                         |
| ValGit          | Git URL validation    | IsValidGitRepoSsh                                                   |
| ValPhone        | Phone validation      | IsValidPhoneNumberFormat                                            |
| ValServer       | Server validation     | IsValidServerNameFormat                                             |

## Advanced Usage

### Custom Error Messages

```csharp
// Customize the field name in error messages
var result = ValEmail.IsValidEmailFormat(email, "Work Email Address");
// Error message will be: "Please enter valid Work Email Address"
```

### Optional Fields

```csharp
// Use isOptional parameter for optional fields
var phoneResult = ValPhone.IsValidPhoneNumberFormat(phoneNumber, "Phone Number", isOptional: true);
if (!phoneResult.Error || phoneResult.Message == "Optional")
{
    // Field is either valid or empty (which is acceptable)
}
```

### Customizable Length Constraints

```csharp
// Customize min/max lengths
var usernameResult = ValUser.IsValidUserNameFormat(username, "Username", min: 3, max: 30);
var serverResult = ValServer.IsValidServerNameFormat(serverName, "Server", min: 3, max: 50, specialCharacter: "-_.");
```

## Validation Rules Details

### Password Requirements

- 8-32 characters
- 1 uppercase letter
- 1 lowercase letter
- 1 number
- 1 special character

### Username Requirements

**IsCleanUserNameFormat** (Strict alphanumeric):

- 5-20 characters (customizable)
- Only alphanumeric characters (a-z, A-Z, 0-9)
- Must start with a letter or digit
- Must end with a letter or digit

**IsValidUserNameFormat** (Allows special characters):

- 5-20 characters (customizable)
- Alphanumeric with .-@ allowed
- Must start with a letter or digit
- Must end with a letter or digit

### Server Name Requirements

**IsValidServerNameFormat**:

- 5-32 characters (customizable)
- Alphanumeric (a-z, A-Z, 0-9) with customizable special characters (default: -\_)
- Must start with a letter or digit
- Must end with a letter or digit
- Special characters allowed only in the middle

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
