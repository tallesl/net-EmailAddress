<p align="center">
    <a href="#emailaddress">
        <img alt="logo" src="Assets/logo-200x200.png">
    </a>
</p>

# EmailAddress

[![][build-img]][build]
[![][nuget-img]][nuget]

[MSDN], [Reference Source], [Phil Haack] and [JStedfast] implementations on email address validation.

[build]:            https://ci.appveyor.com/project/TallesL/net-emailaddress
[build-img]:        https://ci.appveyor.com/api/projects/status/github/tallesl/net-emailaddress?svg=true
[nuget]:            https://www.nuget.org/packages/EmailAddress
[nuget-img]:        https://badge.fury.io/nu/EmailAddress.svg
[MSDN]:             https://msdn.microsoft.com/library/01escwtf
[Reference Source]: http://referencesource.microsoft.com/#System/net/System/Net/mail/MailAddressParser.cs
[Phil Haack]:       http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
[JStedfast]:        https://github.com/jstedfast/EmailValidation

## Usage

```cs
using EmailAddressLibrary;

EmailAddressValidator.Msdn("foo@bar.com");            // True
EmailAddressValidator.ReferenceSource("foo@bar.com"); // True
EmailAddressValidator.Haacked("foo@bar.com");         // True
EmailAddressValidator.JStedfast("foo@bar.com");       // True
```

## Word of warning

It's not perfect (and probably no email address validation code will ever be).

False negatives:

* MSDN:
  [1][msdn-negatives-1]
  [2][msdn-negatives-2]
  [3][msdn-negatives-3]
* Reference Source:
  [1][refsrc-negatives-1]
  [2][refsrc-negatives-2]
* Haacked:
  [1][haack-negatives-1]
  [2][haack-negatives-2]
  [3][haack-negatives-3]

False positives:

* MSDN:
  [1][msdn-positives-1]
  [2][msdn-positives-2]
* Reference Source:
  [1][refsrc-positives-1]
  [2][refsrc-positives-2]
* Haacked:
  [1][haack-positives-1]
  [2][haack-positives-2]

[msdn-negatives-1]:   Tests/CodeFool/Tests.cs#L18-L22
[msdn-negatives-2]:   Tests/SembianceEmailValidator/Tests.cs#L18-L20
[msdn-negatives-3]:   Tests/Wikipedia/Tests.cs#L18-L24
[msdn-positives-1]:   Tests/CodeFool/Tests.cs#L34-L35
[msdn-positives-2]:   Tests/SembianceEmailValidator/Tests.cs#L31-L36
[refsrc-negatives-1]: Tests/CodeFool/Tests.cs#L51-L53
[refsrc-negatives-2]: Tests/Wikipedia/Tests.cs#L45-L46
[refsrc-positives-1]: Tests/Wikipedia/Tests.cs#L65-L75
[refsrc-positives-2]: Tests/SembianceEmailValidator/Tests.cs#L57-L70 
[refsrc-positives-3]: Tests/Wikipedia/Tests.cs#L58-L61
[haack-negatives-1]:  Tests/CodeFool/Tests.cs#L91-L96
[haack-negatives-2]:  Tests/SembianceEmailValidator/Tests.cs#L86-L91
[haack-negatives-3]:  Tests/Wikipedia/Tests.cs#L77-L81
[haack-positives-1]:  Tests/CodeFool/Tests.cs#L108-L109
[haack-positives-2]:  Tests/SembianceEmailValidator/Tests.cs#L103-L106

## Reference Source

Here's what I did with the Reference Source implementation:

1. [Downloaded Reference Source]&nbsp;(version 4.5.2)
1. Copied [MailAddressParser.cs] and its dependencies:
 * [DomainLiteralReader.cs]
 * [DotAtomReader.cs]
 * [QuotedPairReader.cs]
 * [QuotedStringFormatReader.cs]
 * [WhitespaceReader.cs]
 * [MailBnfHelper.cs]&nbsp;(curiously, this is the only class that isn't in namespace System.Net.Mail)
1. Adapted the `MailAddressParser` class:
 * Changed its access to `public`
 * Changed `MailAddressParser(string data)` to `public`
 * Removed `ParseMultipleAddresses(string data)`
 * Changed both `ParseAddress(string data)` and `ParseAddress(string data, bool expectMultipleAddresses, ref int index)` to void
1. Fixed missing `SR`:
 * Created a resource named `SR` from [`corefx/src/System.Net.Http/src/Resources/Strings.resx`][Strings.resx]
 * Replaced `SR.GetString` for `string.Format`

[Downloaded Reference Source]: http://referencesource.microsoft.com/download.html
[MailAddressParser.cs]:        http://referencesource.microsoft.com/#System/net/System/Net/mail/MailAddressParser.cs
[DomainLiteralReader.cs]:      http://referencesource.microsoft.com/#System/net/System/Net/mail/DomainLiteralReader.cs
[DotAtomReader.cs]:            http://referencesource.microsoft.com/#System/net/System/Net/mail/DotAtomReader.cs
[MailAddressParser.cs]:        http://referencesource.microsoft.com/#System/net/System/Net/mail/MailAddressParser.cs
[QuotedPairReader.cs]:         http://referencesource.microsoft.com/#System/net/System/Net/mail/QuotedPairReader.cs
[QuotedStringFormatReader.cs]: http://referencesource.microsoft.com/#System/net/System/Net/mail/QuotedStringFormatReader.cs
[WhitespaceReader.cs]:         http://referencesource.microsoft.com/#System/net/System/Net/mail/WhitespaceReader.cs
[MailBnfHelper.cs]:            http://referencesource.microsoft.com/#System/net/System/Net/mail/MailBnfHelper.cs
[Strings.resx]:                https://github.com/dotnet/corefx/blob/master/src/System.Net.Http/src/Resources/Strings.resx
[EmailAddressValidator.cs]:    EmailAddressValidator/EmailAddressValidator.cs

## Dear Diary

**No <del>[soup]</del> package for you**

To validate an email address... should be easy, right?
C'mon, we saw those everywhere.

![][invalid]

I bet there's a great NuGet package out there waiting for me.

(searches NuGet)

Okay, no package.
That was a let down.

[soup]:    https://youtube.com/watch?v=ryNxl-lpOME
[invalid]: Assets/invalid.png

**[Fuck it, we'll do it live]**

Let's make one, how hard could it be?
After all an address is just "local part + @ + domain part".
And I'm going to man up and go straight to the [RFC], no Wikipedia or Stack Overflow, that's kid stuff.

(reads RFC)

Shit.
A email with a space is valid if you precede it with a backslash.
Same for an "at" sign.
Now you are telling me that I can surround part of the local part with quotes, where there's no need for backslash.

`"dear programmer, good luck h@h@"@somedomain.com` is valid.
I'm out.

And looks like I'm not alone: [1][notalone-1] [2][notalone-2] [3][notalone-3].
Ah, and by the way, here is [one regex I found]:

```
/^(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5C\x22]\x22?)){255,})(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5
C\x22]\x22?)){65,}@)(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\
x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22))(?:\.(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:
\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22)))*@(?:(?:(?!.*[^.]{64,})(?:(?:(?:xn
--)?[a-z0-9]+(?:-[a-z0-9]+)*\.){1,126}){1,}(?:(?:[a-z][a-z0-9]*)|(?:(?:xn--)[a-z0-9]+))(?:-[a-z0-9]+)*)|(?:\[(?:(?:IPv6:
(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){7})|(?:(?!(?:.*[a-f0-9][:\]]){7,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?::(?:[a
-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?)))|(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){5}:)|(?:(?!(?:.*[a-f0-9]:){5,})
(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3}:)?)))?(?:(?:25[0-5])|(?:2[0-4][0-9])|
(?:1[0-9]{2})|(?:[1-9]?[0-9]))(?:\.(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))){3}))\]))$/iD 
```

[Fuck it, we'll do it live]: https://youtube.com/watch?v=2tJjNVVwRCY
[RFC]:                       https://tools.ietf.org/html/rfc3696#section-3
[notalone-1]:                http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
[notalone-2]:                http://girders.org/blog/2013/01/31/dont-rfc-validate-email-addresses
[notalone-3]:                http://regular-expressions.info/email.html
[one regex I found]:         https://fightingforalostcause.net/content/misc/2006/compare-email-regex.php

**[Strike one]**

Searching around for an algorithm I found [this MSDN snippet].
MSDN is Microsoft, these guys probably know what they're doing.

(reads code)

Yuck, look at that.
The thing isn't even thread safe: there's an `invalid` field being read/written in each call (state is bad, mmkay?).

But hey, nobody's perfect.
Since it's just for this little utility of mine (and not a production system), let's fix the thread safety, create the
package and call it a day.

[Strike one]:                     https://github.com/tallesl/EmailAddressValidator/releases/tag/1.0.0
[Where do you want to go today?]: https://youtube.com/watch?v=ynbKWBnjrL0
[this MSDN snippet]:              https://msdn.microsoft.com/library/01escwtf.aspx

**[Strike two]**

Guess what?
Now I have to use the thing in a production system™.
And, to my surprise, there's a [first issue] (!).
Of course, the surprise is not that there's an issue with the code (not at all), it's that there's someone else besides
me using this little thing.

That MSDN code is bad and I'm not in the mood of writing such a beast of a parser.
What now?

Wait a second.
[MailAddress] does this already (throws when it's invalid).
I even forgot that I've grumbled about it before [on my blog].

Ah, [open source] is a beautiful thing.
There's an internal class called [MailAddressParser] just for that.
Let's borrow it.

(reads MailAddressParser.cs)

Sadly, it interfaces with outside code through exceptions ([FormatException] to be more precise).
It's bad from the optimization side, since exception handling is not very performatic (when used with high volume stuff
might be an issue) and also bad from the philosophical side, after all finding format errors is the whole point of the
class (nothing exceptional there).
But that's just me being picky.

[Strike two]:        https://github.com/tallesl/EmailAddressValidator/releases/tag/2.0.0
[first issue]:       https://github.com/tallesl/EmailAddressValidator/issues/1
[MailAddress]:       https://msdn.microsoft.com/library/system.net.mail.mailaddress.aspx
[on my blog]:        https://blog.talles.me/just-put-it-in-the-framework.html
[open source]:       http://referencesource.microsoft.com
[MailAddressParser]: http://referencesource.microsoft.com/#System/net/System/Net/mail/MailAddressParser.cs
[FormatException]:   https://msdn.microsoft.com/library/system.formatexception.aspx

**[Strike three, I'm out]**

So there's a [second issue].
Yep, validating email address is a lost battle.

So in this (last) version I've put several implementations for you to choose, the first one (MSDN), the second one
(Reference Source) and also [Phil Haack] and [JStedfast] implementations.

[Strike three, I'm out]: https://github.com/tallesl/EmailAddressValidator/releases/tag/3.0.0
[second issue]:          https://github.com/tallesl/EmailAddressValidator/issues/2
