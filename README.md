# CertPen
A simple application for signing code quickly without having to use the command line.

This application calls the [signing tool](https://msdn.microsoft.com/en-us/library/windows/desktop/aa387764.aspx) included with Visual Studio. It accepts a number of parameters, listed below.

| Name | Description |
| ---- | ----------- |
| Cert Path | The path to your code signing certificate |
| Code Path | The path to the file that you want to code sign |
| Sign Tool | The path to your code signing Tool |
| Timestamp Location | A Timestamp service used to timestamp the code signing |
| Password | The password for your code signing certificate |

Once you've filled out all of the fields, you can click "Sign Code" - You will know if it was successful based on the message that pops up.

You can also click "Save Settings" to save the following settings:

- Cert Path
- Sign Tool
- Timestamp Location
- Password

I hope you find this tool useful.
