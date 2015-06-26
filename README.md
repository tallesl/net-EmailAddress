# EmailAddressValidator

[![][build-img]][build]
[![][nuget-img]][nuget]

[build]:     https://ci.appveyor.com/project/TallesL/EmailAddressValidator
[build-img]: https://ci.appveyor.com/api/projects/status/github/tallesl/EmailAddressValidator

[nuget]:     http://badge.fury.io/nu/EmailAddressValidator
[nuget-img]: https://badge.fury.io/nu/EmailAddressValidator.png

```cs
using EmailAddressValidation;

EmailAddressValidator.IsValid("no email for you"); // false
EmailAddressValidator.isValid("foo@bar.com");      // true
```

## Word of warning

It's not *perfect* (and probably no email address validation code will ever be). Here are some false positives ([1][falsepositive-1] [2][falsepositive-2] [3][falsepositive-3] [4][falsepositive-4]) and negatives ([1][falsenegative]).

[falsenegative]: EmailAddressValidator.Tests/CodeFool.cs#L46

[falsepositive-1]: EmailAddressValidator.Tests/CodeFool.cs#L54
[falsepositive-2]: EmailAddressValidator.Tests/Msdn.cs#L28
[falsepositive-3]: EmailAddressValidator.Tests/SembianceEmailValidator.cs#L59
[falsepositive-4]: EmailAddressValidator.Tests/Wikipedia.cs#L44

## Dear Diary

### No <del>soup</del> package for you

To validate an email address... should be easy, right?
C'mon, we saw those everywhere.

[![][invalid]](#)

I bet there's a great NuGet package out there waiting for me.

*(searches NuGet)*

Okay, no package.
That was a let down.

[invalid]: invalid.png

### Fuck it, we'll do it live

Let's make one, how hard could it be?
After all an address is just *local part + @ + domain part*.
And I'm going *man up* straight to [the RFC][rfc], no *Wikipedia* or *Stack Overflow*, that's kid stuff.

*(reads RFC)*

Shit.
A email with a space is valid if you preced it a backslash.
Same for an *at sign*.
Now you are telling me that I can surround part of the local part with quotes, where there's no need for backslash.

`"dear programmer, good luck h@h@"@somedomain.com` is valid.
I'm out.

And looks like I'm not alone: [1][notalone-1] [2][notalone-2] [3][notalone-3].
Ah, and by the way, here is [one regex I found][regex]:

```
/^(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5C\x22]\x22?)){255,})(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5C\x22]\x22?)){65,}@)(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22))(?:\.(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22)))*@(?:(?:(?!.*[^.]{64,})(?:(?:(?:xn--)?[a-z0-9]+(?:-[a-z0-9]+)*\.){1,126}){1,}(?:(?:[a-z][a-z0-9]*)|(?:(?:xn--)[a-z0-9]+))(?:-[a-z0-9]+)*)|(?:\[(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){7})|(?:(?!(?:.*[a-f0-9][:\]]){7,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?)))|(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){5}:)|(?:(?!(?:.*[a-f0-9]:){5,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3}:)?)))?(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))(?:\.(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))){3}))\]))$/iD 
```

[rfc]:        https://tools.ietf.org/html/rfc3696#section-3
[notalone-1]: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
[notalone-2]: http://girders.org/blog/2013/01/31/dont-rfc-validate-email-addresses
[notalone-3]: http://regular-expressions.info/email.html
[regex]:      https://fightingforalostcause.net/content/misc/2006/compare-email-regex.php

### Where do you want to go today?

Searching around for an algorithm I found [this MSDN snippet][msdn].
MSDN is Microsoft, these guys probably know what they're doing.

*(reads code)*

Yuck, look at that.
The thing isn't even thread safe: there's an `invalid` field being read/written by each call (*state* is bad, mmkay?).

But hey, nobody's perfect.
Since it's just for this little utility of mine (and not a production system), let's fix the thread safety, create the package and call it a day.

[Version 1.0][1.0], done. 

[msdn]: https://msdn.microsoft.com/library/01escwtf.aspx
[1.0]:  https://github.com/tallesl/EmailAddressValidator/releases/tag/1.0.0

### Strike two

Guess what?
Now I have to use the thing in a production system™.
And, to my surprise, there's a [first issue][#1] (!).
Of course, the surprise is not that there's an issue with the code (not at all), it's that there's someone beside me using this little thing.

That MSDN code is bad and I'm not in the mood of writing such a beast of a parser.
What now?

Wait a second.
[MailAddress][MailAddress] does this already (throws when it's invalid).
I even forgot that [I've grumbled about it before on my blog][blog].

Ah, [open source][referencesource] is a beautiful thing.
There's an internal class called [MailAddressParser][MailAddressParser] just for that.
Let's borrow it.

*(reads MailAddressParser.cs)*

Sadly, it interfaces with outside code through exceptions ([FormatException][FormatException] to be more precise).
It's bad from the *optmization* side, since exception handling is not very performatic (when used with high volume stuff might be an issue) and also bad from the *philosophical* side, after all finding format errors is the whole point of the class (nothing *exceptional* there).

But that's just me being picky.
[Version 2.0][2.0], done.

### Wait a second

*Cool story kid, but are you telling me that you did all this to in the end have the same effect of trying to construct a MailAddress and catch FormatException?*

Yep.

*And why would I ever use this package instead?*

Here are some possible reasons, but I'm not trying to convince anyone:

* If you aren't going to use MailAddress, it makes your intention clearer;
* It doesn't rely on System.Net.Mail, just System (but I don't know when this is ever useful);
* Hey, it's community code™ (if you can call such humble repository a *community*).

[#1]:                https://github.com/tallesl/EmailAddressValidator/issues/1
[MailAddress]:       https://msdn.microsoft.com/library/system.net.mail.mailaddress.aspx
[blog]:              https://blog.talles.me/just-put-it-in-the-framework.html
[referencesource]:   http://referencesource.microsoft.com
[MailAddressParser]: http://referencesource.microsoft.com/#System/net/System/Net/mail/MailAddressParser.cs
[FormatException]:   https://msdn.microsoft.com/library/system.formatexception.aspx
[2.0]:               https://github.com/tallesl/EmailAddressValidator/releases/tag/2.0.0
