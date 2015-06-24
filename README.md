# EmailAddressValidator

[![][build-image]][build]
[![][nuget-image]][nuget]

[build]:       https://ci.appveyor.com/api/projects/status/github/tallesl/EmailAddressValidator
[build-image]: https://ci.appveyor.com/project/TallesL/EmailAddressValidator

[nuget]:       http://badge.fury.io/nu/EmailAddressValidator
[nuget-image]: https://badge.fury.io/nu/EmailAddressValidator.png

Quick and dirty email address validation.

## Usage

```csharp
using EmailAddressValidation;

EmailAddressValidator.IsValid("invalid");     // false
EmailAddressValidator.isValid("foo@bar.com"); // true
```

## Rationale

For a very simple CLI utility of mine I had to ask for some email address as input.
Being a good boy as I am I decided to validate that.

Headed to [NuGet][nuget] for a package to validate email addresses and nothing there.
Dang.

Searching around for an email validation *code* I found [this MSDN page][msdn].
The code is a little *ugly*, but works good enough for my intentions.
[Now there's a NuGet package for it][package] :grinning:

[nuget]:   https://nuget.org
[msdn]:    https://msdn.microsoft.com/library/01escwtf.aspx
[package]: https://nuget.org/packages/EmailAddressValidator

## *Quick and dirty*

100% RFC compliant email address validation is extremely difficult, almost an utopia. [¹][1] [²][2] [³][3]

And, as you may already tell, this code have it's own problems in this matter (here are some [false positives][positives] and [false negatives][negatives]).
Consider that before using it.

[1]:         http://stackoverflow.com/q/201323
[2]:         http://regular-expressions.info/email.html
[3]:         http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
[positives]: https://github.com/tallesl/EmailAddressValidator/blob/master/EmailAddressValidator.Tests/Tests.cs#L84-89
[negatives]: https://github.com/tallesl/EmailAddressValidator/blob/master/EmailAddressValidator.Tests/Tests.cs#L45-48
