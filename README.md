# EmailAddressValidator

[![build](https://ci.appveyor.com/api/projects/status/github/tallesl/EmailAddressValidator)](https://ci.appveyor.com/project/TallesL/EmailAddressValidator)
[![nuget package](https://badge.fury.io/nu/EmailAddressValidator.png)](http://badge.fury.io/nu/EmailAddressValidator)

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

Headed to [NuGet](https://nuget.org) for a package to validate email addresses and nothing there.
Dang.

Searching around for an email validation *code* I found [this MSDN page](https://msdn.microsoft.com/library/01escwtf.aspx).
The code is a little *ugly*, but works good enough for my intentions.
[Now there's a NuGet package for it](https://nuget.org/packages/EmailAddressValidator) :grinning:

## *Quick and dirty*

100% RFC compliant email address validation is extremely difficult, almost an utopia [\*](http://stackoverflow.com/q/201323)[\*](http://www.regular-expressions.info/email.html)[\*](http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx)

And, as you may already tell, this code have it's own problems in this matter (here are some [false positives](https://github.com/tallesl/EmailAddressValidator/blob/master/EmailAddressValidator.Tests/Tests.cs#L84) and [false negatives](https://github.com/tallesl/EmailAddressValidator/blob/master/EmailAddressValidator.Tests/Tests.cs#L45)).
Consider that before using it.
